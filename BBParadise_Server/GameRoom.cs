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
        internal List<MatchModel> matchList = new List<MatchModel>();
        internal ArcaletScene scene = null;

        internal bool addPlayer(MatchModel model)
        {
            lock (matchList)
            {
                Console.WriteLine("matchList.Count() = " + matchList.Count());
                if (matchList.Count() >= MAX_PLAYER)
                {
                	Console.WriteLine("return false");
                	return false;
                }
                matchList.Add(model);
                return true;
            }
        }
    }
}
