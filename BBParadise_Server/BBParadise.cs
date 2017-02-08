using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBParadise_Server
{
    public partial class BBParadise : Form
    {
        string gguid = "7245577f-4961-7642-a64c-ba5bb008892c";
        string sguid = "52a06444-ff13-654b-bfa1-29da9f7124dd";

        string iguid_player = "2a0ccd1d-f564-f74f-b1c6-d2a6157b8b59";
        string sguid_game = "c4345a29-310f-d241-b95c-77928bf819c6";
        string lguid = "";

        byte[] certificate = {0x43, 0x13, 0xbd, 0x25, 0x4e, 0x7b, 0xa3, 0x4b, 0x86, 0x13, 0xa8, 0xa5, 0x49,
                            0xcf, 0xd1, 0x5e, 0x58, 0x34, 0x2c, 0xda, 0xb, 0x9f, 0xc, 0x41, 0x8a, 0x3e,
                            0xd4, 0x71, 0x5a, 0xb, 0x3d, 0x41, 0x57, 0x1c, 0x53, 0xed, 0xf, 0x52, 0x70,
                            0x47, 0x93, 0xb5, 0x9f, 0x27, 0xe3, 0xa0, 0x66, 0x2d, 0x86, 0x55, 0x5b, 0x9c,
                            0x4b, 0x33, 0xd8, 0x40, 0xbb, 0x66, 0xf1, 0x8c, 0x67, 0x19, 0x8a, 0x4, 0x1a,
                            0x14, 0x28, 0xa7, 0x67, 0x95, 0x72, 0x4c, 0x8c, 0xfb, 0xa, 0xf5, 0x4a, 0x12,
                            0x49, 0x53, 0x6d, 0xf7, 0xa0, 0xd4, 0x73, 0x96, 0x52, 0x43, 0x8e, 0x54, 0x79,
                            0xfa, 0x48, 0xeb, 0x5b, 0xaf, 0xd1, 0x64, 0x20, 0x3d, 0x49, 0xa5, 0xbc, 0x40,
                            0x89, 0xa2, 0xb6, 0xc5, 0x6f, 0xd6, 0xac, 0xfe, 0x2f, 0x92, 0x4d, 0xbc, 0x3f,
                            0xbd, 0x4b, 0x4d, 0x90, 0xf8, 0x50, 0xf2, 0x2, 0x16, 0x75, 0xd4};

        public ArcaletGame ag = null;

        string m_username = "su000001132119";
        string m_password = "vhGujAMr";

        public BBParadise()
        {
            InitializeComponent();
            login();
			Online_People.Text = "Online Player = 0";
			match_people.Text = "Match Player = 0";
			GameRoom.Text = "Game room = 0";
        }

        void login()
        {
            lable_status.Text = "Prepare Login";
            ag = new ArcaletGame(m_username, m_password, gguid, sguid, certificate);
            ag.onMessageIn += MainMessageIn;
            ag.onPrivateMessageIn += PrivateMessageIn;
            ag.onStateChanged += OnStateChanged;
            ag.onCompletion += CB_Login;
            ag.Launch();
        }

        void MainMessageIn(string msg, int delay, ArcaletGame game)
        {
            try
            {
                Console.WriteLine("MainMessageIn: " + msg);
                string[] cmds = msg.Split(':');
                switch (cmds[0])
                {
                    case "new": PlayerNew(cmds[1].Split('/')); break;
                    case "quit": PlayerQuit(cmds[1]); break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        void PrivateMessageIn(string msg, int delay, ArcaletGame game)
        {
            try
            {
                Console.WriteLine("PrivateMessageIn: " + msg);
                string[] cmds = msg.Split(':');
                switch (cmds[0])
                {
                    case "match": DP_Match(cmds[1]); break;
                //    case "cancel": CancelMatchCheck(int.Parse(cmds[1])); break;
                }
            }
            catch (Exception) { }
        }

        void GameMessageIn(string msg, int delay, ArcaletScene scene)
        {
            
            try
            {
                Console.WriteLine("GameMessageIn: " + msg);
                GameRoom room = scene.token as GameRoom;
                string[] cmds = msg.Split(':');


                if (cmds[0] == "dp_draw" || cmds[0] == "dp_gameover" || cmds[0] == "dp_timeup")
                {
                //    room.GameOver();
               //     room.LeaveScene();
                }

                //if (room.gameover)
                //    return;

                switch (cmds[0])
                {
                    case "bb_ready": PlayerReady(cmds[1], room); return;
                    case "bb_over": RemoveRoomList(room); break;
                }

				/* if msg doesn't handle, send to room's message-center */
				room.handleGameMessage(msg);
            }
            catch (Exception) { }
        }

        void OnStateChanged(int state, int code, ArcaletGame game)
        {
            if (state >= 900)
                lable_status.Text = "Disconnection: " + code;
        }

        void CB_Login(int code, ArcaletGame game)
        {
            if (code == 0)
                lable_status.Text = "Login Successed";
            else
                lable_status.Text = "Login Failed " + code;
        }
    }
}
