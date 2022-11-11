using System;
using System.IO;

namespace Lab23_Ex2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.CreateDirectory("TEMP1");
            Directory.CreateDirectory("TEMP2");
            Directory.Move("TEMP1", "TEMP2\\TEMP1");
        }
    }
}
