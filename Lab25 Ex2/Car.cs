using System;
using System.Collections.Generic;
using System.Text;

namespace Lab25_Ex2
{
    [Serializable]
    public class Car
    {
        public Car(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}