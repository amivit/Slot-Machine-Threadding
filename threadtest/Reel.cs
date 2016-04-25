using System;

namespace threadtest
{
    internal class Reel
    {
        private readonly Random _rnd;
        private readonly string _name;
        public int Resultat { get; set; }
        public bool Run { get; set; }

        public Reel(Random rnd, string name)
        {
            _rnd = rnd;
            _name = name;
            Run = true;
            StartReel();
        }

        public void StartReel()
        {
            while (Run)
            {
                for (int i = 0; i <= 4; i++)
                {
                    if (i == 4)
                    {
                        Console.WriteLine("{0} finished at: {1}", _name, Resultat);
                        Run = false;
                    }
                    Resultat = _rnd.Next(1, 9);
                }
            }
        }
    }
}