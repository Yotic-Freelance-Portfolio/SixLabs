using System;
using System.Collections.Generic;
using System.Text;

namespace Lab27_Ex2
{
    public class Station
    {
        public Station(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public delegate void Event(string name);
        public event Event NewEvent;

        public void InvokeEvent()
        {
            NewEvent?.Invoke(Name);
        }
    }
}