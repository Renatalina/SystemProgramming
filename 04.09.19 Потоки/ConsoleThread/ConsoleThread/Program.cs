using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThread
{
    delegate int MyDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {

            /*
            ThreadStart threadStart = new ThreadStart(Method);
            Thread thread = new Thread(threadStart);
            //вот этот метод старт запускает поток
            thread.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"\t\tMain " +
                    $"{Thread.CurrentThread.ManagedThreadId}");
            }*/


            /*
            Thread thread1 = new Thread(ParameterizedMethod);
            thread1.Priority = ThreadPriority.Highest;
            thread1.Start("\tOne");

            Thread thread2 = new Thread(ParameterizedMethod);
            thread2.Priority = ThreadPriority.Lowest;
            thread2.Start("\t\tTwo");
            */

            /*
            Thread thread = new Thread(Method);

            //IsBackground этот метод сделал поток фоновым, тру!
            thread.IsBackground = true;

            //вот этот метод старт запускает поток
            thread.Start();

            //
            thread.Join();

            /*
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"\t\tMain " +
                    $"{Thread.CurrentThread.ManagedThreadId}");
            }*/

            /*
            Random random = new Random();
            for (int i=0;i<10; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadPoolMethod,
                    random.Next(10));
            }
            Console.WriteLine("Main");
            */
            /*
            MyDel myDel = Summ;
            IAsyncResult result= myDel.BeginInvoke(45,6,null,null);

            while (result.IsCompleted == false)
            {
                Thread.Sleep(500);
                Console.WriteLine("Waiting..");
            }
            int summ=myDel.EndInvoke(result);

            Console.WriteLine(summ);
            */

            MyDel myDel = Summ;
            IAsyncResult result = myDel.BeginInvoke(45, 6, SummCallback, null);
            


            Console.ReadKey();

            
        }

        private static void SummCallback(IAsyncResult ar)
        {
            MyDel myDel = ar.AsyncState as MyDel;
            int summ = myDel.EndInvoke(ar);
            Console.WriteLine($"Summ:{summ}");
        }

        private static int Summ(int x, int y)
        {
            Thread.Sleep(3000);
            return x + y;
        }

        private static void ThreadPoolMethod(object state)
        {
            Console.WriteLine($"\t\t{state}" +
                $"{Thread.CurrentThread.ManagedThreadId}" +
                $"{Thread.CurrentThread.Priority}");
            Thread.Sleep(1000);
        }

        private static void ParameterizedMethod(object obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                 Console.WriteLine($"\t\t{obj} " +
                    $"{Thread.CurrentThread.ManagedThreadId} " +

                    //вот здесь выводим приоритет потока CurrentThread.Priority
                    $"{Thread.CurrentThread.Priority}");

            }
        }

        private static void Method()
        {

           for (int i=0; i<100; i++)
            {
                if (i == 53)
                {
                    Console.WriteLine($"Thread Abort");
                    //метод аборт прекращает работу потока
                    Thread.CurrentThread.Abort();
                }
                //Thread.CurrentThread это текущий поток!!!!!!!  ManagedThreadId   а это ай ди текущего потока
                Console.WriteLine($"\t\tMethod {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
