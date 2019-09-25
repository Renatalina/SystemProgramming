using System;
using System.Threading;

namespace ConsoleGame
{
    internal class Master
    {
        DateTime time;
        Random random;
        public Master()
        {
            random = new Random();
        }
        internal void Signal()
        {
            Thread.Sleep(random.Next()%899+100);
            Console.WriteLine($"SIGNAL!!!");
            time = DateTime.Now;
        }

        internal void PrintResult(User user)
        {
            if (user.TimeClick > time)
            {
                DateTime dt = new DateTime(user.TimeClick.Ticks - time.Ticks);
                Console.WriteLine($"{dt.ToString("mm:ss:fff")}");
            }
            else
            {
                Console.WriteLine("You press key to early");
            }
        }
    }
}