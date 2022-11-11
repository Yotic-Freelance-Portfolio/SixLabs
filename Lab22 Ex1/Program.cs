using System;

namespace Lab22_Ex1
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.Write("n = ");
                int n = int.Parse(Console.ReadLine());
                long num = FoundSumOfNaturalNumbers(n);
                Console.WriteLine($"sum = {num}");
            }
            catch (Exception ex) { Console.WriteLine($"Было вызвано необработанное исключение {ex.GetType()}: {ex.Message}"); }
        }

        private static long FoundSumOfNaturalNumbers(int n)
        {
            try
            {
                long result = 0;

                for (int i = 5; i < n * 5; i += 5)
                    result += i;

                return result;
            }
            catch (OverflowException ex) { Console.WriteLine($"Возникло арифметическое переполнение."); }
            catch (Exception ex) { Console.WriteLine($"Было вызвано необработанное исключение {ex.GetType()}: {ex.Message}"); }

            return -1;
        }
    }
}
