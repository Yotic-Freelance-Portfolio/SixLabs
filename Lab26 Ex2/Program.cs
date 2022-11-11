using System;

namespace Lab26_Ex2
{
    public class Program
    {
        public static void Main()
        {
            InvokeFewMethodByOneDelegate();
        }

        private delegate void MyDelegate(string s);

        private static void InvokeFewMethodByOneDelegate()
        {
            MyDelegate write = Write;
            MyDelegate writeline = WriteLine;

            write.Invoke("Write");
            writeline.Invoke("Write new Line");

            void WriteLine(string s)
            {
                Console.WriteLine(s);
            }

            void Write(string s)
            {
                Console.Write(s);
            }
        }

        private static void InvokeMultiDelegate() 
        {
            MyDelegate multi = new MyDelegate(Write);

            multi += new MyDelegate(Write);
            multi += new MyDelegate(WriteLine);

            multi.Invoke("a few write methods.");

            void WriteLine(string s)
            {
                Console.WriteLine(s);
            }

            void Write(string s)
            {
                Console.Write(s);
            }
        }
    }
}
