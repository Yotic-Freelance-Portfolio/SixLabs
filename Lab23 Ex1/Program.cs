using System;
using System.IO;

namespace Labs23_Ex1
{
    public class Program
    {
        public static void Main()
        {
            GetDriversInfoByDriveInfo();
            GetBaseDirectoriesByDirectory("C:\\");
            TestDirectoryCreate();
            TestGetDirInfo();
            TestDeleteDir();
            TestMoveDir();
            TestGetFileInfo();
            TestDeleteFile();
            TestMoveFile();
            TestCopyFile();
        }

        private static void GetDriversInfoByDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Название: {0}", drive.Name);
                Console.WriteLine("Тип: {0}", drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                    Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
        }

        private static void GetBaseDirectoriesByDirectory(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }

        private static void TestDirectoryCreate()
        {
            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
                dirInfo.Create();
            dirInfo.CreateSubdirectory(subpath);
        }

        private static void TestGetDirInfo()
        {
            string dirName = "C:\\Program Files";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine("Название каталога: {0}", dirInfo.Name);
            Console.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
            Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
            Console.WriteLine("Корневой каталог: {0}", dirInfo.Root);
        }

        private static void TestDeleteDir()
        {
            string dirName = @"C:\SomeFolder";
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                dirInfo.Delete(true);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private static void TestMoveDir()
        {
            string oldPath = @"C:\SomeFolder";
            string newPath = @"C:\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
                dirInfo.MoveTo(newPath);
        }

        private static void TestGetFileInfo()
        {
            string path = @"C:\apache\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
        }
        
        private static void TestDeleteFile()
        {
            string path = @"C:\apache\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
        
        private static void TestMoveFile()
        {
            string path = @"C:\apache\hta.txt";
            string newPath = @"C:\SomeDir\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
            }
        }

        private static void TestCopyFile()
        {
            string path = @"C:\apache\hta.txt";
            string newPath = @"C:\SomeDir\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
                fileInf.CopyTo(newPath, true);
        }
    }
}