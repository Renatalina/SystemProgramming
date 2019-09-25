using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SistemProgramming
{
    public unsafe struct OsVersionInfo
    {
        public uint osVersionInfoSize;
        public uint majorVersion;
        public uint minorVersion;
        public uint buildNumber;
        public uint platformId;
        public fixed byte servicePackVersion[128];
    }

    class DllImportExample
    {
        [DllImport("user32")]
        public static extern int MessageBoxA(IntPtr hWnd,
            string text, string caption, uint type);



        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetUserName(StringBuilder builder,
            ref int len);


        [DllImport("Kernel32.dll", EntryPoint = "GetVersionEx")]
        public static extern bool GetVersion(ref OsVersionInfo versionInfo);


        [DllImport("SimpleCulc_C++.dll")]
        public static extern int add(int a, int b);

        [DllImport("SimpleCulc_C++.dll")]
        public static extern int sub(int a, int b);
        [DllImport("SimpleCulc_C++.dll")]
        public static extern int mult(int a, int b);

        [DllImport("SimpleCulc_C++.dll")]
        public static extern int div(int a, int b);


    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Zero -текущее окно, Text example -нашу сообщение 
            //Test - заголовок сообщения 
            //0- это значение перечислений
            DllImportExample.MessageBoxA(IntPtr.Zero, "Text example",
                "Test", 0);
            */


            /*
            //эти библиотека Dll не возможно все узнать, нужно их просто искать
            int len = 20;
            StringBuilder builder = new StringBuilder(len);

            DllImportExample.GetUserName(builder, ref len);
            WriteLine($"User name: {builder}");
            */

            /*
            OsVersionInfo versionInfo = new OsVersionInfo();
            versionInfo.osVersionInfoSize = (uint)Marshal.SizeOf(versionInfo);

            bool result = DllImportExample.GetVersion(ref versionInfo);

            if (result)
            {
                WriteLine($"Assembly identifier: {versionInfo.buildNumber}");
            }

            //usafe-это участок не безопасного кода
            unsafe
            {
                int number = 12;
                int* ptr = &number;
                WriteLine(*ptr);

            }*/

            /*
            //здесь применили библиотеку из С++
            try
            {
                WriteLine(DllImportExample.add(23, 67));
                WriteLine(DllImportExample.mult(11, 12));
                WriteLine(DllImportExample.div(144, 12));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }*/

            Student student = new Student {
                id = new Random().Next(),
                FirstName="John",
                LastName="Doe",
                BirthDate=new DateTime(1997, 4,12)
            };

            WriteLine(student);
            ReadLine();
        }
    }
}
