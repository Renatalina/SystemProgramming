using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Master master = new Master();
            User user = new User();
            Thread threadMaster = new Thread(master.Signal);
            Thread threadUser = new Thread(user.PressKey);
            threadMaster.IsBackground = true;
            threadMaster.Start();
            threadUser.Start();

            threadMaster.Join();
            threadUser.Join();
            master.PrintResult(user);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);



        }
    }
}
