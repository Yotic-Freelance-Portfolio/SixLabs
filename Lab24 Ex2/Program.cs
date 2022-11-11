using System;
using System.IO;

namespace Lab24_Ex2
{
    public class Program
    {
        public static void Main()
        {
            string[] senteces = ReadSenteces(@"C:\note.txt", 3);
            Array.Reverse(senteces);
            foreach(string line in senteces)
                Console.WriteLine(line);
        }

        private static string[] ReadSenteces(string path, int count)
        {
            string[] allSenteces = new string[0];
            try
            {
                allSenteces = File.ReadAllText(path).Split('.');
            } catch (Exception ex) { Console.WriteLine($"При чтении файла произошло исключение {ex.GetType()}: {ex.Message}"); }             
            string[] sentences = new string[count];

            for (int i = 0; i < count; i++)
                sentences[i] = allSenteces[i];

            return sentences;
        }
    }
}