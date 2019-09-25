using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"{Id} {LastName} {BirthDate}";
        }

        public int Summ(int x, int y)
        {
            return x + y;
        }
    }
}
