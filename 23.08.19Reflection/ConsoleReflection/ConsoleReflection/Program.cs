using AssemblyExampleLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                //Environment.CurrentDirectory

                List<Type> types = new List<Type>();

                foreach (string item in Directory.GetFiles(path,"*.dll"))
                {
                    Assembly assembly = Assembly.LoadFrom(item);
                    foreach (Type t in assembly.GetExportedTypes())
                    {
                        if (!t.IsClass | !typeof(IAssemblyExample).IsAssignableFrom(t))
                        {
                            continue;
                        }

                        types.Add(t);
                    }
                }

                Console.Write($"Enter number: ");
                int number = int.Parse(Console.ReadLine());

                foreach (Type item in types)
                {
                    Console.WriteLine(
                        (Activator.CreateInstance(item) as IAssemblyExample).SomeMethod(number)
                        );
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
