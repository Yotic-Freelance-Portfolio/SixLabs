using System;
using System.Collections.Generic;
using System.Text;

namespace Lab24_Ex1
{
    public struct State
    {
        public string name;
        public string capital;
        public int area;
        public double people;

        public State(string n, string c, int a, double p)
        {
            name = n;
            capital = c;
            people = p;
            area = a;
        }
    }
}