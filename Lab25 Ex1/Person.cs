using System;
using System.Collections.Generic;
using System.Text;

namespace Lab25_Ex1
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Person(string name, int year) 
        {
            Name = name;
            Year = year;
        }
    }
}
