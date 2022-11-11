using System;
using System.Collections.Generic;
using System.Text;

namespace Lab26_Ex1
{
    class StringContainer
    {
        public delegate void CheckAndDisplayDelegate(string str);

        private List<string> container = new List<string>();

        public void AddString(string str)
        {
            container.Add(str);
        }

        public void DisplayAllQualified(CheckAndDisplayDelegate displayDelegate)
        {
            foreach (var str in container)
                displayDelegate(str);
        }
    }

    class StringExtensions
    {

        public static void ConStart(string str)
        {
            if (!(str[0] == 'a' || str[0] == 'e' || str[0] == 'i' || str[0] == 'o' || str[0] == 'u'))
                Console.WriteLine(str);
        }

        public static void VowelStart(string str)
        {
            if ((str[0] == 'a' || str[0] == 'e' || str[0] == 'i' || str[0] == 'o' || str[0] == 'u'))
                Console.WriteLine(str);
        }
    }

}
