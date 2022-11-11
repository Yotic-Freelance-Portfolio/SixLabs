using System;

namespace Lab27_Ex2
{
    public class Program
    {
        public static void Main()
        {
            Station station1 = new Station("Harison");
            Station station2 = new Station("Freeholand");
            Person person = new Person();

            station1.NewEvent += person.StartEvent;
            station2.NewEvent += person.StartEvent;

            station1.InvokeEvent();
            station2.InvokeEvent();
        }
    }
}
