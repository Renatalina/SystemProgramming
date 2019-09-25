using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssebly
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine($"Name: {assembly.FullName}");
            Console.WriteLine($"Location: {assembly.Location}");

            FileStream[] files = assembly.GetFiles();
            foreach (FileStream item in files)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n++++++++++++++++++\n");

            foreach (Module item in assembly.GetLoadedModules())
            {
                Console.WriteLine(item.Name);
            }*/

            /*Assembly assembly = Assembly.Load("mscorlib");

            foreach (Type item in assembly.GetTypes())
            {
                if (item.IsPrimitive)
                {
                    Console.WriteLine($"Type name: {item.Name}");

                    if (item.BaseType!=null)
                    {
                        Console.WriteLine($"Base type: {item.BaseType.Name}");
                    }
                }
                Console.WriteLine("\n--------\n");
            }*/

            Assembly assembly = Assembly.Load("PersonLibrary");

            Console.WriteLine("\n--------\n");

            foreach (Type item in assembly.GetTypes())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n--------\n");

            Type type = assembly.GetType("PersonLibrary.Person");

            object obj = Activator.CreateInstance(type);

            Console.WriteLine("\n--------\n");

            foreach (MethodInfo item in type.GetMethods())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n--------\n");

            MethodInfo method = type.GetMethod("ToString");

            Console.WriteLine(method.Invoke(obj, null));

            Console.WriteLine("\n--------\n");

            method = type.GetMethod("Summ");

            Console.WriteLine(method.Invoke(obj, new object[] { 34, 12 }));


            Console.ReadLine();
        }
    }
}
