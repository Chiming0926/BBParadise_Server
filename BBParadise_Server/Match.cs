using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBParadise_Server
{
    public partial class BBParadise
    {
        List<MatchModel> matchList = new List<MatchModel>();
        List<GameRoom> roomList = new List<GameRoom>();

		private static int MAX_PLAYER = 6; /* just for testing */

		void SendMatchMessage()
		{
			string msg = "bb_match_data:";
			/* parse the message */
			foreach (MatchModel md in matchList)
                msg += md.fbId + "/";
			/* send to all clients */
			foreach (MatchModel md in matchList)
	            ag.PrivacySend(msg, md.poid);
		}

        void DP_Match(string msg)
        {
            string[] m = msg.Split('/');
            string acc = m[0];
            int poid = int.Parse(m[1]);
            string nick = m[2];
            string code = m[3];
			string fbId = m[4];

            MatchModel model = new MatchModel();

            model.account = acc;
            model.poid = poid;
            model.nickname = nick;
            model.matchCode = code;
			model.fbId = fbId;
            SearchTarget(model);
        }

        void SearchTarget(MatchModel self)
        {
            try
            {
                lock (matchList)
                {
					if (matchList.Count < (MAX_PLAYER-1))
					{
                        matchList.Add(self);
						match_people.Text = "Match Player = " + matchList.Count;
						SendMatchMessage();
                    }
                    else
                    {
						matchList.Add(self);
                        GameRoom go = new GameRoom();
                        Console.WriteLine("before matchList.Count = " + matchList.Count);
                        for (int i=0; i< matchList.Count; i++)
                        {
                            if (go.addPlayer(matchList[i]) == false)
                                break;
                        }
                        DoMatch(go);
                        matchList.Clear();
                        match_people.Text = "Match Player = " + matchList.Count;
                        Console.WriteLine("after Wait for Match User" + matchList.Count);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        void DoMatch(GameRoom go)
        {
            ArcaletScene sn = new ArcaletScene(ag, sguid_game);
            sn.onMessageIn += GameMessageIn;
            sn.onCompletion += CB_EnterGameRoom;

            GameRoom room = go;
            room.scene = sn;
            sn.token = room;
            sn.Launch();
        }

        void CB_EnterGameRoom(int code, ArcaletScene scene)
        {
            try
            {
                GameRoom room = scene.token as GameRoom;
                if (code == 0)
                {
                    Console.WriteLine("CB_EnterGameRoom Success: ");
                    room.sendGameSceneToAllUser(ag);
                    foreach (MatchModel model in room.playerList)
                    {
                        //RoomPlayerinfoToken token = new RoomPlayerinfoToken();
                        //token.account = model.account;
                        //token.poid = model.poid;
                        //token.room = room;
                        //ArcaletItem.suGetItemInstance(ag, model.account, iguid_player, CB_GetPlayerInfomations, token);
                    }
                    AddRoomList(room);
                }
                else
                {
                    Console.WriteLine("CB_EnterGameRoom Error: " + code);
                }
            }
            catch (Exception) { }
        }

        void CB_GetPlayerInfomations(int code, object data, object token)
        {
            try
            {
      //          RoomPlayerinfoToken info = token as RoomPlayerinfoToken;
                if (code == 0)
                {
                    List<Hashtable> list = data as List<Hashtable>;
                    List<Hashtable> attr_ht = list[0]["attr"] as List<Hashtable>;
                    MatchModel model = new MatchModel();

                    int itemID = int.Parse(list[0]["id"].ToString());
                    foreach (Hashtable attr in attr_ht)
                    {
                        if (attr["name"].ToString() == "Win")
                            model.win = int.Parse(attr["value"].ToString());

                        else if (attr["name"].ToString() == "Lose")
                            model.lose = int.Parse(attr["value"].ToString());

                        else if (attr["name"].ToString() == "Draw")
                            model.draw = int.Parse(attr["value"].ToString());
                    }

                    //GameRoom room = info.room;
                    //foreach (MatchModel md in info.room.model)
                    //{
                    //    if (md.poid == info.poid)
                    //    {
                    //        md.win = model.win;
                    //        md.lose = model.lose;
                    //        md.draw = model.draw;
                    //        md.itemID = itemID;
                    //        md.getData = true;
                    //        GameStartCheck(info.room);
                    //        break;
                    //    }
                    //}
                }
                else
                {
                    //if (info.retry <= 0)
                    //    return;

                    //info.retry--;
                    //ArcaletItem.suGetItemInstance(ag, info.account, iguid_player, CB_GetPlayerInfomations, info);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.StackTrace.ToString());
            }
        }

        void PlayerReady(string msg, GameRoom room)
        {
			string[] m = msg.Split('/');
            int poid = int.Parse(m[1]);
            foreach (MatchModel md in room.playerList)
            {
                if (md.poid == poid)
                {
                    md.ready = true;
                    GameStartCheck(room);
                    break;
                }
            }
        }

        void GameStartCheck(GameRoom room)
        {
            bool start = true;
            foreach (MatchModel md in room.playerList)
            {
                if (!md.ready) start = false;
            }
            if (start)
                GameStart(room);
        }

        void GameStart(GameRoom room)
        {
        //    room.aTimer.Enabled = false;
        //    room.bTimer.Enabled = true;
        //    room.turn = 1;
        //    room.scene.Send("dp_start:" + room.model[0].poid);
            foreach (MatchModel m in room.playerList)
            {
                room.scene.Send("bb_player:" + m.poid + "/" + m.account + "/" + m.nickname + "/" + m.win + "/" + m.lose + "/" + m.draw);
        	}
        }

        void CancelMatchCheck(int poid)
        {
            lock (matchList)
            {
                foreach (MatchModel model in matchList)
                {
                    if (model.poid == poid)
                    {
                        matchList.Remove(model);
                        match_people.Text = "Match Player = " + matchList.Count;
                        return;
                    }
                }
            }

            lock (roomList)
            {
                foreach (GameRoom room in roomList)
                {
                    foreach (MatchModel model in room.playerList)
                    {
                        if (model.poid == poid)
                            model.cancelMatch = true;
                    }
                }
            }
        }

        void AddRoomList(GameRoom r)
        {
            lock (roomList)
            {
                roomList.Add(r);
                GameRoom.Text = "Game room = " + roomList.Count;
            }
        }

        internal void RemoveRoomList(GameRoom r)
        {
            lock (roomList)
            {
                foreach (GameRoom room in roomList)
                {
                    if (room == r)
                    {
                        roomList.Remove(room);
						GameRoom.Text = "Game room = " + roomList.Count;
                        return;
                    }
                }
            }
        }
    }

    //internal class RoomPlayerinfoToken
    //{
    //    internal string account = "";
    //    internal int poid = 0;
    //    internal int retry = 5;
    //    internal GameRoom room = null;
    //}

    internal class MatchModel
    {
        internal string account = "";
        internal int poid = 0;
        internal int itemID = 0;
        internal string nickname = "";
        internal string matchCode = "";
		internal string fbId = "";
		
        internal int win = 0;
        internal int lose = 0;
        internal int draw = 0;

		internal bool death = false;
        internal bool getData = false;
        internal bool ready = false;
        internal bool cancelMatch = false;
    }
}

