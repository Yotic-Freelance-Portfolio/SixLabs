using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab25_Ex2
{
    public class Program
    {
        public static void Main()
        {
            Car car = new Car("Ford Mustang", "культовый автомобиль класса Pony Car производства Ford Motor Company. На автомобиле размещается не эмблема Ford, а специальная эмблема Mustang. рядный, 6-цилиндр. 120 л.");
            Console.WriteLine("Объект создан");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, car);
                Console.WriteLine("Объект сериализован");
            }
        }
    }
}