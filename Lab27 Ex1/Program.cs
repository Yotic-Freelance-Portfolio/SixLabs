using System;

namespace Lab27_Ex1
{
    public class Program
    {
        public static void Main()
        {
            TestEvents();
            TestClassEvents();
            TestDelegates();
        }
        public delegate void MyDelegate();

        #region Test1
        class Источник
        {
            public event MyDelegate My_event;
            public void Создать_событие()
            {
                Console.WriteLine("Событие создано!!!");

                if (My_event != null) My_event();
            }
        }
        class Наблюдатель1
        {
            public void Do_Event_1()
            { Console.WriteLine("ВИЖУ, что произошло событие!!!"); }
        }
        class Наблюдатель2
        {
            public static void Do_Event_2()
            { Console.WriteLine("Я тоже ВИЖУ, что произошло событие!!!"); }
        }

        private static void TestEvents()
        {
            Источник A = new Источник();
            Наблюдатель1 B = new Наблюдатель1();
            Наблюдатель1 С = new Наблюдатель1();
            A.My_event += new MyDelegate(B.Do_Event_1);
            A.My_event += new MyDelegate(С.Do_Event_1);
            A.My_event += new MyDelegate(Наблюдатель2.Do_Event_2);
            A.Создать_событие();
            A.My_event -= new MyDelegate(B.Do_Event_1);
            A.Создать_событие();
            Console.ReadKey();

        }
        #endregion

        #region Test2
        private static void TestClassEvents()
        {
            Account account = new Account(200, 6);

            account.Added += Show_Message;
            account.Withdrowed += Show_Message;

            account.Withdraw(100);
            account.Withdrowed -= Show_Message;

            account.Withdraw(50);
            account.Put(150);
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
        #endregion

        private static void TestDelegates()
        {
            Console.WriteLine("Пример работы Делегата");
            Firm firm = new Firm();
            Human.HumanDelegate sex = new Human.HumanDelegate(AnalyzeSex);
            Human.HumanDelegate age = new Human.HumanDelegate(AnalyzeAge);

            firm.AnalyzePeople(sex + age);
            Console.WriteLine("\n\n");
            firm.AnalyzePeople(age + sex);
            Console.WriteLine("\n\n");
            firm.AnalyzePeople((Human.HumanDelegate)Delegate.Combine(sex, age));
            MulticastDelegate del = age + sex;
            firm.AnalyzePeople((Human.HumanDelegate)del);
            Delegate onlysex = MulticastDelegate.Remove(del, age);
            Console.WriteLine("\n\n************************************\n\n");
            firm.AnalyzePeople((Human.HumanDelegate)onlysex);

            void AnalyzeSex(Human h)
            {
                if (h.RealSex == Human.Sex.Male)
                {
                    Console.WriteLine("Мужчина");
                }
                else
                {
                    Console.WriteLine("Женщина");
                }
            }
            void AnalyzeAge(Human h)
            {
                if (h.Age > 65)
                {
                    Console.WriteLine("Больше 65 лет");
                }
                else
                {
                    Console.WriteLine("Меньше или равно 65 лет");
                }
            }

        }
    }
}