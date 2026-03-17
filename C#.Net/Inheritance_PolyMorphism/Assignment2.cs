using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Account
    {
        public int AccountNumber;
        public int Balance;

        public void CalculateInterest()
        {
            Console.WriteLine("Base Account interest Calculation");
        }
    }

    class SavingsAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Saving Account interest Calculation");
        }
    }

    class CurrentAccount : Account
    {
        public new void CalculateInterest()
        {
            Console.WriteLine("Base Account interest Calculation");
        }
    }
    }
