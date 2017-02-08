using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BBParadise_Server.BBParadise;

namespace BBParadise_Server
{
    internal class GameRoom
    {
        static int MAX_PLAYER = 2;
        internal List<MatchModel> playerList = new List<MatchModel>();
		internal List<MatchModel> team1List = new List<MatchModel>();
		internal List<MatchModel> team2List = new List<MatchModel>();
        internal ArcaletScene scene = null;

        internal bool addPlayer(MatchModel model)
        {
            lock (playerList)
            {
                Console.WriteLine("playerList.Count() = " + playerList.Count());
                if (playerList.Count() >= MAX_PLAYER)
                {
                	Console.WriteLine("return false");
                	return false;
                }
                playerList.Add(model);
				Console.WriteLine("playerList.Count = " + playerList.Count);
				if (playerList.Count > (MAX_PLAYER / 2))
				{
					Console.WriteLine("add to team2");
					team2List.Add(model);
				}
				else
				{
					Console.WriteLine("add to team1");
					team1List.Add(model);
				}
                return true;
            }
        }

		internal void setGameScene(ArcaletScene sn)
		{
			scene = sn;
		}

		void handleDeathMsg(string msg)
		{
			string[] m = msg.Split('/');
			int cnt = 0;
			foreach (MatchModel data in team1List)
	        {
                Console.WriteLine("team1 member:" + data.account + " , msg = " + m[0]);
	            if (data.account == m[0])
	            {
	                data.death = true;
	            }
				if (data.death == true)
					cnt++;
	        }

			if (cnt >= (MAX_PLAYER >> 1))
			{
				Console.WriteLine("bb_over:team1 GGGGGGGGGGGG");
				scene.Send("bb_over:team1");
                DialogResult result;
                string caption = "Message Box";
                string show_text = "bb_over:team1";
                result = MessageBox.Show(show_text, caption, MessageBoxButtons.OK);
            }

			cnt = 0;
            foreach (MatchModel data in team2List)
	        {
                Console.WriteLine("team2 member:" + data.account + " , msg = " + m[0]);
                if (data.account == m[0])
	            {
	                data.death = true;
	            }
				if (data.death == true)
					cnt++;
	        }
			if (cnt >= (MAX_PLAYER >> 1))
			{
                scene.Send("bb_over:team2");
                DialogResult result;
                string caption = "Message Box";
                string show_text = "bb_over:team2";
                result = MessageBox.Show(show_text, caption, MessageBoxButtons.OK);
            }
		}

		internal void handleGameMessage(string msg)
		{
			Console.WriteLine("handleGameMessage: " + msg);
			string[] cmds = msg.Split(':');
			switch (cmds[0])
            {
                case "bb_death":
					handleDeathMsg(cmds[1]);
                    break;
				default:
             		break;
			}
		}

		internal void sendUserInfoToAllUser()
		{
			lock (playerList)
			{
				Console.WriteLine("sensUserInfoToAllUser");
				string msg = "UserInfo/" + playerList.Count;
				for (int i=0; i<playerList.Count; i++)
				{
					msg += "/" + playerList[i].account;
				}
				
			}
		}

		internal void sendGameSceneToAllUser(ArcaletGame ag)
		{
			lock (playerList)
			{
				Console.WriteLine("sendGameSceneToAllUser");
				for (int i=0; i<playerList.Count; i++)
					ag.PrivacySend("dp_room:" + scene.sid + "/" + playerList[i].matchCode + "/" + playerList[i].account, playerList[i].poid);
			}
		}
		
    }
}
