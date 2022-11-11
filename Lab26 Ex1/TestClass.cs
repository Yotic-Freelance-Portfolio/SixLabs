using System;
using System.Collections.Generic;
using System.Text;

namespace Lab26_Ex1
{
    class TestClass
    {
        public delegate void CustomDel(string s);
        public static void Hello(string s)
        {
            Console.WriteLine($"  Hello, {s}!");
        }
        public static void Goodbye(string s)
        {
            Console.WriteLine($"  Goodbye, {s}!");
        }
    }
}
