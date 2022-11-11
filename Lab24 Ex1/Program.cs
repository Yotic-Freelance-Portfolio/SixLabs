using System;
using System.IO;
using System.Text;

namespace Lab24_Ex1
{
    public class Program
    {
        public static void Main()
        {
            TestReadAndWrite();
            TestFileStream();
            TestStreamClose();
            TestWaysToReadFile();
            TestStreamWriter();
            TestBinaryReader();
            TestFileExceptions();
        }

        private static void TestReadAndWrite()
        {
            using (FileStream fstream = new FileStream(@"C:\note.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes("test");
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            using (FileStream fstream = File.OpenRead(@"C:\note.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("Текст из файла: {0}", textFromFile);
            }
        }

        private static void TestFileStream()
        {
            string text = "hello world";
            using (FileStream fstream = new FileStream(@"D:\note.dat", FileMode.OpenOrCreate))
            {
                byte[] input = Encoding.Default.GetBytes(text);
                fstream.Write(input, 0, input.Length);
                Console.WriteLine("Текст записан в файл");
                fstream.Seek(-5, SeekOrigin.End);
                byte[] output = new byte[4];
                fstream.Read(output, 0, output.Length);
                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine("Текст из файла: {0}", textFromFile);
                string replaceText = "house";
                fstream.Seek(-5, SeekOrigin.End);
                input = Encoding.Default.GetBytes(replaceText);
                fstream.Write(input, 0, input.Length);
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine("Текст из файла: {0}", textFromFile);
            }
        }

        private static void TestStreamClose()
        {
            FileStream fstream = null;
            try
            {
                fstream = new FileStream(@"D:\note3.dat", FileMode.OpenOrCreate);
            }
            catch { }
            finally
            {
                if (fstream != null)
                    fstream.Close();
            }
        }

        private static void TestWaysToReadFile()
        {
            string path = @"C:\note.txt";
            try
            {
                Console.WriteLine("******считываем весь файл********");
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                Console.WriteLine();
                Console.WriteLine("******считываем построчно********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("******считываем блоками********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    char[] array = new char[4];
                    sr.Read(array, 0, 4);
                    Console.WriteLine(array);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private static void TestStreamWriter()
        {
            string readPath = @"C:\notepad.txt";
            string writePath = @"C:\notepad2.txt";

            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Дозапись");
                    sw.Write(4.5);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private static void TestBinaryReader()
        {
            State[] states = new State[2];
            states[0] = new State("Германия", "Берлин", 357168, 80.8);
            states[1] = new State("Франция", "Париж", 640679, 64.7);
            string path = @"C:\states.dat";
            try
            { 
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (State s in states)
                    {
                        writer.Write(s.name);
                        writer.Write(s.capital);
                        writer.Write(s.area);
                        writer.Write(s.people);
                    }
                }
                
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        string capital = reader.ReadString();
                        int area = reader.ReadInt32();
                        double population = reader.ReadDouble();
                        Console.WriteLine("Страна: {0}  столица: {1}  площадь {2} кв. км   численность населения: {3} млн. чел.", name, capital, area, population);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.ReadLine();
        }

        public static void TestFileExceptions()
        {
            try
            {
                FileStream f = new FileStream(@"d:\C#\text.txt",
                    FileMode.Open, FileAccess.Read);
	            f.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Проверьте правильность имени файла! ");
                return;
            }
            catch (Exception e) 
            { 
                Console.WriteLine("Error: " + e.Message); 
                return;
            }
        }
    }
}