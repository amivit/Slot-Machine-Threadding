using System;
using System.Collections.Generic;
using System.Threading;

namespace threadtest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rnd = new Random(); // Creat rnd objects in main, so threads don't generate same random numbers

            var reel1 = new Reel(rnd, "reel1"); // Create my objects
            var reel2 = new Reel(rnd, "reel2");
            var reel3 = new Reel(rnd, "reel3");
            var reelsList = new List<Reel> { reel1, reel2, reel3 }; // Throw them into a list

            var thread1 = new Thread(reel1.StartReel); // Create threads
            var thread2 = new Thread(reel2.StartReel);
            var thread3 = new Thread(reel3.StartReel);
            var threadsList = new List<Thread> { thread1, thread2, thread3 }; // Throw them into a list

            var slotMachine = new ReelsContainer(reelsList, threadsList); // Throw list and threads into slot machine
            StartSlotMachine(slotMachine, reelsList); // Begin!
        }

        private static void StartSlotMachine(ReelsContainer slotMachine, List<Reel> reelsList)
        {
            //            slotMachine.StartThreads();
            while (true)
            {
                Thread.Sleep(1000);
                // Without sleep, cpu goes to 100%. Instead, check for jackpot every 1000ms
                // Proper solution is to rewrite everything using "Tasks")
                if (slotMachine.CheckJackpot())
                {
                    Console.WriteLine("JACKPOT! Press any key to start new threads and play again");
                    Console.ReadLine();
                    foreach (var reel in reelsList)
                    {
                        reel.StartReel();
                    }
                }
                else
                {
                    Console.WriteLine("No jackpot. Press any key to start new threads and try again");
                    Console.ReadLine();
                    foreach (var reel in reelsList)
                    {
                        reel.StartReel();
                    }
                }
            }
        }
    }
}