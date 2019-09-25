using AssemblyExampleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleOneLibrary
{
    public class ClassOne : IAssemblyExample
    {
        public string SomeMethod(int number)
        {
            return $"ModuleOne: {number}";
        }
    }
}
