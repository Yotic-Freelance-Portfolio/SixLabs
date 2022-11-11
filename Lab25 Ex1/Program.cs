using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab25_Ex1
{
    public class Program
    {
        public static void Main()
        {
            TestSerializeClassInFile();
            TestSerializeArrayInFile();
            TestSerializeAllClassDataInFile();
        }

        private static void TestSerializeClassInFile()
        {
            Person person = new Person("Tom", 29);
            Console.WriteLine("Объект создан");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, DateTime.Now.Year - newPerson.Year);
            }
        }

        private static void TestSerializeArrayInFile()
        {
            Person[] people = new Person[] { new Person("Angrew", 2020), new Person("Gabe", 2002) };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);

                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);

                foreach (Person p in deserilizePeople)
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, DateTime.Now.Year - p.Year);
            }
        }

        private static void TestSerializeAllClassDataInFile()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }
        }
    }
}