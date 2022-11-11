using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab23_Ex4
{
    public class Program
    {
        private static void Ex1(string path, int n, int k)
        {
            StreamWriter w = new StreamWriter(path, false, Encoding.Default);
            string s = new string('*', k);
            for (int i = 1; i <= n; i++)
                w.WriteLine(s);
            w.Close();
        }

        private static void Ex2(string path, int N)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StreamWriter w = new StreamWriter(path, false, Encoding.Default);
            for(int i = 0; i < N; i++)
            {
                string line = "";
                for (int o = 0; o < i; o++)
                    line += alphabet[o];
                w.WriteLine(line);
            }
            w.Close();
        }

        private static void Ex3(string path, int N)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StreamWriter w = new StreamWriter(path, false, Encoding.Default);
            for (int i = 0; i < N; i++)
            {
                string line = "";
                for (int o = 0; o < i; o++)
                    line += alphabet[o];
                line += new string('*', N - i);
                w.WriteLine(line);
            }
            w.Close();
        }

        private static void Ex4(string path)
        {
            StreamReader r = new StreamReader(path, Encoding.Default);
            int nc = 0, ns = 0;
            while (r.Peek() != -1)
            {
                if ((char)r.Peek() != '\r')
                {
                    r.Read();
                    nc++;
                }
                else
                {
                    r.ReadLine();
                    ns++;
                }
            }
            r.Close();
            Console.WriteLine($"В файле {nc} символов");
            Console.WriteLine($"В файле {ns} строк");
        }

        private static void Ex5(string path, string line)
        {
            File.AppendAllText(path, line);
        }

        private static void Ex6(string pathFrom, string pathTo)
        {
            string text = File.ReadAllText(pathFrom);
            File.AppendAllText(pathTo, text);
        }

        private static void Ex7(string path, string line)
        {
            string text = line + File.ReadAllText(path);
            File.WriteAllText(path, text);
        }

        private static void Ex8(string path1, string path2)
        {
            string file1 = File.ReadAllText(path1);
            string file2 = File.ReadAllText(path2);
            File.WriteAllText(path1, file2 + file1);
        }

        private static void Ex9(string path, int K)
        {
            string[] lines = File.ReadAllLines(path);
            if(K < lines.Length)
            {
                File.Delete(path);
                StreamWriter file = new StreamWriter(File.Create(path));
                for (int i = 0; i < K; i++)
                    file.WriteLine(lines[i]);
                file.Write('\n');
                for (int i = K; i < lines.Length; i++)
                    file.WriteLine(lines[i]);
            }
        }

        private static void Ex10(string path, int K)
        {
            string[] lines = File.ReadAllLines(path);
            if (K < lines.Length)
            {
                File.Delete(path);
                StreamWriter file = new StreamWriter(File.Create(path));
                for (int i = 0; i <= K; i++)
                    file.WriteLine(lines[i]);
                file.Write('\n');
                for (int i = K + 1; i < lines.Length; i++)
                    file.WriteLine(lines[i]);
            }
        }

        private static void Ex11(string path)
        {
            string[] lines = File.ReadAllLines(path);
            File.Delete(path);
            StreamWriter file = new StreamWriter(File.Create(path));
            for (int i = 0; i <= lines.Length; i++)
            {
                if (lines[i] == string.Empty)
                    file.Write('\n');
                file.WriteLine(lines[i]);
            }
        }

        private static void Ex12(string path, string line)
        {
            string[] lines = File.ReadAllLines(path);
            File.Delete(path);
            StreamWriter file = new StreamWriter(File.Create(path));
            for (int i = 0; i <= lines.Length; i++)
            {
                if (lines[i] == string.Empty)
                    file.Write(line);
                else file.WriteLine(lines[i]);
            }
        }

        private static void Ex13(string path)
        {
            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Skip(1));
        }

        private static void Ex14(string path)
        {
            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(lines.Length - 1));
        }

        private static void Ex15(string path, int K)
        {
            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(K - 1).Skip(1).Take(lines.Length - K));
        }

        private static void Ex16(string path)
        {
            string[] original = File.ReadAllLines(path);
            List<string> lines = new List<string>();
            for(int i = 0; i < original.Length; i++)
                if (original[i] != string.Empty)
                    lines.Add(original[i]);
            File.WriteAllLines(path, lines);
        }

        private static void Ex17(string file1, string file2)
        {
            string[] lines1 = File.ReadAllLines(file1);
            string[] lines2 = File.ReadAllLines(file2);

            int shortestLength = Math.Min(lines1.Length, lines2.Length);

            string[] lines = new string[shortestLength];
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines1[i] + lines2[i];

            File.WriteAllLines(file1, lines);
        }

        private static void Ex18(int K, string path)
        {
            string[] original = File.ReadAllLines(path);

            string[] lines = new string[original.Length];
            for (int i = 0; i < original.Length; i++)
                lines[i] = new string(original[i].Skip(K).ToArray());

            File.WriteAllLines(path, lines);
        }

        private static void Ex19(string path)
        {
            string origin = File.ReadAllText(path);
            string result = "";
            foreach (char c in origin)
                result += char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c);
            File.WriteAllText(path, result);
        }

        private static void Ex20(string path)
        {
            string text = File.ReadAllText(path).Trim();
            File.WriteAllText(path, text);
        }

        private static void Ex21(string path)
        {
            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(lines.Length - 3));
        }

        private static void Ex22(string path, int K)
        {
            string[] lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(lines.Length - K));
        }

        private static void Ex23(string from, string to, int K)
        {
            string[] lines = File.ReadAllLines(from);
            File.WriteAllLines(to, lines.Skip(K));
        }

        private static int Ex24(string path)
        {
            string text = File.ReadAllText(path).Trim('\n');
            return text.Count(z => z == '\n');
        }

        private static void Ex25(int K, string path)
        {
            string text = File.ReadAllText(path);
            string[] parts = text.Split("\n     ");
            File.WriteAllText(path, string.Join("\n     ", parts.Take(K-1).Skip(1).TakeWhile(z => true)));
        }

        private static int Ex26(string path)
        {
            string text = File.ReadAllText(path);
            string changed = text.Replace("\n     ", "№");
            return changed.Count(z => z == '№');
        }

        private static void Ex27(int K, string path)
        {
            string text = File.ReadAllText(path);
            string changed = text.Replace("\n     ", "№");
            int startIndex = 0;
            int foundCount = 0;
            for(int i = 0; i < changed.Length; i++)
                if (changed[i] == '№')
                {
                    foundCount++;
                    if(foundCount == K)
                    {
                        startIndex = i + 5 * K;
                        break;
                    }
                }

            int endIndex = 0;
            for(int i = startIndex; i < text.Length; i++)
                if (text[i] == '\n')
                {
                    endIndex = i;
                    break;
                }

            File.WriteAllText(path, new string(text.Take(startIndex).Skip(endIndex - startIndex).TakeWhile(z => true).ToArray()));
        }

        private static void Ex28(string path)
        {
            string origin = File.ReadAllText(path);
            string text = "";
            for(int i = 0; i < origin.Length; i++)
            {
                if (i > 0 && i + 5 < origin.Length)
                    if (origin[i] == ' ' && origin[i + 1] == ' ' && origin[i + 2] == ' ' && origin[i + 3] == ' ' && origin[i + 4] == ' ')
                        text += '\n';
                text += origin[i];
            }
        }

        private static string Ex29(string path)
        {
            string text = File.ReadAllText(path);
            string[] words = text.Split(' ');
            return words.OrderBy(z => -z.Length).ToArray()[0];
        }

        private static string Ex30(string path)
        {
            string text = File.ReadAllText(path);
            string[] words = text.Split(' ');
            return words.OrderBy(z => z.Length).Last();
        }

        private static void Ex31(string from, string to, int K)
        {
            string text = File.ReadAllText(from);
            string[] words = text.Split(' ');
            List<string> right = new List<string>();
            foreach(string word in words)
                if(word.Length == K)
                    right.Add(word);
            File.WriteAllText(to, string.Join(' ', right));
        }

        private static void Ex32(string from, string to)
        {
            string text = File.ReadAllText(from);
            string[] words = text.Split(' ');
            List<string> right = new List<string>();
            foreach (string word in words)
                if (char.ToUpper(word[0]) == 'С')
                    right.Add(word);
            File.WriteAllText(to, string.Join(' ', right));
        }

        private static void Ex33(string from, string to)
        {
            string text = File.ReadAllText(from);
            string[] words = text.Split(' ');
            List<string> right = new List<string>();
            foreach (string word in words)
                if (word.ToUpper().Contains('С'))
                    right.Add(word);
            File.WriteAllText(to, string.Join(' ', right));
        }

        private static void Ex34(string path)
        {
            string[] lines = File.ReadAllLines(path);
            for(int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].PadRight(50, ' ');
            File.WriteAllLines(path, lines);
        }

        private static void Ex35(string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].PadLeft(50, ' ');
            File.WriteAllLines(path, lines);
        }

        private static void Ex36(string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                int needDelete = (lines.Length - lines[i].TrimStart(' ').Length) / 2;
                lines[i] = new string(lines[i].Skip(needDelete).TakeWhile(z => true).ToArray());
            }
            File.WriteAllLines(path, lines);
        }

        private static void Ex37(string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != string.Empty)
                {
                    int length = lines[i].Length;
                    lines[i] = lines[i].PadLeft((50 - length) / 2 + length, ' ').PadRight(50, ' ');
                }
            }
            File.WriteAllLines(path, lines);
        }

        private static void Ex38(int K, string from, string to)
        {
            string text = File.ReadAllText(from);
            string nlcated = text.Replace("\n\n", "\n");
            string[] nls = nlcated.Split('\n');
            string result = "";
            for(int i = 0; i < nls.Length; i++)
            {
                for(int c = 0; c < nls[i].Length - 1; c++)
                {
                    result += nls[i][c];
                    if (c == K)
                        result += '\n';
                }
                result += '\n';
            }
            File.WriteAllText(to, result);
        }

        private static void Ex39(int K, string from, string to)
        {
            string text = File.ReadAllText(from);
            string nlcated = text.Replace("\n     ", "\n");
            string[] nls = nlcated.Split('\n');
            string result = "";
            for (int i = 0; i < nls.Length; i++)
            {
                for (int c = 5; c < nls[i].Length - 1; c++)
                {
                    result += nls[i][c];
                    if (c == K-5 || c == K)
                        result += '\n';
                }
            }
            File.WriteAllText(to, result.Replace("\n", "\n     "));
        }
    }
}