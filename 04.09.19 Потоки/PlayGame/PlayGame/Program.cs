using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart param = new ParameterizedThreadStart(PressKey);
            Thread thread = new Thread(param);
            Random rand = new Random();
            char ch = (char)rand.Next(97, 123);
            Console.WriteLine(ch);
            thread.Start(ch);
            thread.Join();

            Console.WriteLine();

            Console.ReadLine();
        }
        static void PressKey(object obj)
        {
            char ch = (char)obj;
            DateTime start = DateTime.Now;
            Console.WriteLine("Enter key");
            for (; ; )
            {

                if (obj is char)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.KeyChar == ch)
                    {
                        DateTime finish = DateTime.Now;
                        Console.Write("\n" + (finish - start).Minutes);
                        Console.Write(" : " + (finish - start).Seconds);
                        Console.WriteLine(" : " + (finish - start).Milliseconds);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nNo!");
                    }
                }
            }
        }
    }
}
