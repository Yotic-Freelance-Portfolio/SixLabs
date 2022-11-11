using System;
using System.Collections.Generic;
using System.Text;

namespace Lab26_Ex1
{

    public class MyClass
    {
        public delegate void MyTypeDelegate(double x, ref double res);

        public void PrintCos(double x, ref double res)
        {
            res = Math.Cos(x);
            Console.WriteLine("cos({0})={1}", x, res);
        }
        public void PrintSin(double x, ref double res)
        {
            res = Math.Sin(x);
            Console.WriteLine("sin({0})={1}", x, res);
        }
    }
}
