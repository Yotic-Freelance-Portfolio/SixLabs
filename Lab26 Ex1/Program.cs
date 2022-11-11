using System;
using static Lab26_Ex1.TestClass;

namespace Lab26_Ex1
{
    public class Program
    {
        public static void Main()
        {
            TestCustomDelegate();
            TestMultiDelegate();
            TestMultiDelegateWithNative();
        }

        private static void TestCustomDelegate()
        {
            CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;

            hiDel = Hello;

            byeDel = Goodbye;

            multiDel = hiDel + byeDel;

            multiMinusHiDel = multiDel - hiDel;

            Console.WriteLine("Вызывающий delegate hiDel:");
            hiDel("A");
            Console.WriteLine("Вызывающий delegate byeDel:");
            byeDel("B");
            Console.WriteLine("Вызывающий delegate multiDel:");
            multiDel("C");
            Console.WriteLine("Вызывающий delegate multiMinusHiDel:");
            multiMinusHiDel("D");
        }

        private static void TestMultiDelegate()
        {

            MyClass example = new MyClass();
            double x = Math.PI;
            double res = double.NaN;

            MyClass.MyTypeDelegate obDelegate;

            Console.WriteLine("До вызова объекта делегата res={0}", res);

            obDelegate = new MyClass.MyTypeDelegate(example.PrintSin);
            obDelegate += new MyClass.MyTypeDelegate(example.PrintCos);
            obDelegate += new MyClass.MyTypeDelegate(example.PrintSin);

            obDelegate(x, ref res);
            Console.WriteLine("После вызова объекта делегата res={0}", res);
            obDelegate -= new MyClass.MyTypeDelegate(example.PrintSin);
            obDelegate(x, ref res);

            Console.WriteLine("После вызова объекта делегата res={0}", res);
        }

        private static void TestMultiDelegateWithNative()
        {
            StringContainer container = new StringContainer();
            container.AddString("This");
            container.AddString("is");
            container.AddString("a");
            container.AddString("multicast");
            container.AddString("delegate");
            container.AddString("example");

            StringContainer.CheckAndDisplayDelegate conStart = StringExtensions.ConStart;
            StringContainer.CheckAndDisplayDelegate vowelStart = StringExtensions.VowelStart;

            Delegate[] delegateList = conStart.GetInvocationList();
            Console.WriteLine("conStart contains {0} delegate(s).", delegateList.Length);
            delegateList = vowelStart.GetInvocationList();
            Console.WriteLine("vowelStart contains {0} delegate(s).\n", delegateList.Length);

            if (conStart is MulticastDelegate && vowelStart is MulticastDelegate)
                Console.WriteLine("conStart and vowelStart are derived from MulticastDelegate.\n");

            Console.WriteLine("Выполнение программы conStart delegate:");
            container.DisplayAllQualified(conStart);
            Console.WriteLine();
            Console.WriteLine("Выполнение программы vowelStart delegate:");
            container.DisplayAllQualified(vowelStart);
            Console.WriteLine();

            StringContainer.CheckAndDisplayDelegate multipleDelegates =
                  (StringContainer.CheckAndDisplayDelegate)Delegate.Combine(conStart, vowelStart);

            delegateList = multipleDelegates.GetInvocationList();
            Console.WriteLine("\nmultipleDelegates contains {0} delegates.\n",
                              delegateList.Length);

            Console.WriteLine("Выполнение программы multipleDelegate delegate.");
            container.DisplayAllQualified(multipleDelegates);

            multipleDelegates = (StringContainer.CheckAndDisplayDelegate)Delegate.Remove(multipleDelegates, vowelStart);
            multipleDelegates = (StringContainer.CheckAndDisplayDelegate)Delegate.Combine(multipleDelegates, conStart);

            Console.WriteLine("\n Выполнение программы multipleDelegate delegate with two conStart delegates: ");
      
            container.DisplayAllQualified(multipleDelegates);

        }
    }
}