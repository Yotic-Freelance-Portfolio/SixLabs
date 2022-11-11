using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab27_Ex1
{
	public class Human
	{
		public delegate void HumanDelegate(Human h);

		public enum Sex { Male, Female };
		private Sex p;
		private string name;
		private string surname;
		private int age;

		public Human()
		{
			name = surname = "Нет Данных";
			age = 0;
			p = Sex.Male;
		}

		public static void OnRun(string msg)
		{
			Console.WriteLine("В OnRun:" + msg);
		}
		public static void OnStop(string msg)
		{
			Console.WriteLine("В OnStop:" + msg);
		}
		public static void OnRun2(string msg)
		{
			Console.WriteLine("В OnRun2:" + msg);
		}

		public Human(string name, string surname, int age, Sex p)
		{
			this.name = name;
			this.surname = surname;
			this.age = age;
			this.p = p;
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Surname
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public int Age
		{
			get
			{
				return age;
			}
			set
			{
				age = value;
			}
		}

		public Sex RealSex
		{
			get
			{
				return p;
			}
			set
			{
				p = value;
			}
		}
	}

	class Firm
	{
		ArrayList people = new ArrayList();
		public Firm()
		{
			people.Add(new Human());
			people.Add(new Human("Вася", "Иванов", 80, Human.Sex.Male));
			people.Add(new Human("Катерина", "Маркова", 25, Human.Sex.Female));
		}

		public void AnalyzePeople(Human.HumanDelegate ptr)
		{
			Console.WriteLine("Будем выполнять действия над человеком !!!");
			foreach (Human obj in people)
				ptr(obj);
		}
	}
}