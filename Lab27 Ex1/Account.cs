using System;
using System.Collections.Generic;
using System.Text;

namespace Lab27_Ex1
{
    class Account
    {
        public delegate void AccountStateHandler(string message);

        public event AccountStateHandler Withdrowed;
        public event AccountStateHandler Added;

        int _sum;
        int _percentage;

        public Account(int sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;
        }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Put(int sum)
        {
            _sum += sum;
            if (Added != null) Added("На счет поступило " + sum);
        }
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                if (Withdrowed != null) Withdrowed("Сумма " + sum + " снята со счета");
            }
            else
            {
                if (Withdrowed != null) Withdrowed("Недостаточно денег на счете");
            }
        }
        public int Percentage
        {
            get { return _percentage; }
        }
    }
}