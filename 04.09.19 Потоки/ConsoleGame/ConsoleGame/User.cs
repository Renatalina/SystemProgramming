using System;

namespace ConsoleGame
{
    internal class User
    {

        public DateTime TimeClick { get; private set; }
        internal void PressKey()
        {
            Console.ReadKey(true);
            TimeClick = DateTime.Now;
        }
    }
}