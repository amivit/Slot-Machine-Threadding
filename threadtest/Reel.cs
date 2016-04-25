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
            //StartReel();
        }

        public void StartReel()
        {
            Run = true;
            Resultat = _rnd.Next(1, 9);
            Console.WriteLine("{0} finished at: {1}", _name, Resultat);
        }
    }
}