using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BBParadise_Server.BBParadise;

namespace BBParadise_Server
{
    internal class GameRoom
    {
        static int MAX_PLAYER = 6;
        internal List<MatchModel> playerList = new List<MatchModel>();
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
                return true;
            }
        }

		internal void handleGameMessage(string msg)
		{
			Console.WriteLine("handleGameMessage: " + msg);
			string[] cmds = msg.Split(':');
			
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
