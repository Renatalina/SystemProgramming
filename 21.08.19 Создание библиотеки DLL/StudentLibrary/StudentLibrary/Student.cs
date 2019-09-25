using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class Student
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            //ToLongDateString выведет мне без времени
            return $"{id}{LastName} {FirstName} {BirthDate.ToLongDateString()}"; 
            
        }

    }
}
