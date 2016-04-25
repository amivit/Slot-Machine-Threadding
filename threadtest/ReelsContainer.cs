using System.Collections.Generic;
using System.Threading;

namespace threadtest
{
    internal class ReelsContainer
    {
        private static List<Reel> _reelsList;
        private static List<Thread> _threadsList;

        public ReelsContainer(List<Reel> reelsList, List<Thread> threadsList)
        {
            _threadsList = threadsList;
            _reelsList = reelsList;
        }

        public bool CheckJackpot()
        {
            bool jackpot = false;
            foreach (Reel reels in _reelsList)
            {
                if (!reels.Run)
                {
                    for (int i = 1; i < _reelsList.Count; i++)
                    {
                        Reel reel = _reelsList[i];
                        int tmp = reel.Resultat;
                        jackpot = _reelsList[0].Resultat == tmp;
                    }
                }
            }
            return jackpot;
        }

        public void StartThreads()
        {
            foreach (Thread thread in _threadsList)
            {
                if (!thread.IsAlive)
                {
                    foreach (Reel reel in _reelsList)
                    {
                        reel.StartReel();
                    }
                }
            }
        }
    }
}