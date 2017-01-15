using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBParadise_Server
{
    public partial class BBParadise
    {
        int onlinePlayerNumber = 0;

        void PlayerNew(string[] msg)
        {
            string user = msg[0];
            int poid = int.Parse(msg[1]);
            ArcaletItem.suGetItemInstance(ag, user, iguid_player, true, CB_PlayerItemCheck, poid);
        }

        void CB_PlayerItemCheck(int code, object data, object token)
        {
            int poid = (int)token;

            if (code == 0)
            {
                onlinePlayerNumber++;
                Console.WriteLine("onlinePlayerNumber = " + onlinePlayerNumber);
                ag.PrivacySend("dp_new:" + ag.poid, poid);
            }
            else
            {
                Console.WriteLine("CB_PlayerItemCheck Failed");
            }
        }

        void PlayerQuit(string msg)
        {
            string[] m = msg.Split('/');
            int poid = int.Parse(m[1]);
            //CancelMatchCheck(poid);

            onlinePlayerNumber--;
            Console.WriteLine("onlinePlayerNumber = " + onlinePlayerNumber);
        }
    }
}
    