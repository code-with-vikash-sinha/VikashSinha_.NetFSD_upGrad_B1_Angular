using System;
using System.Threading;

class BankAccount
{
    private int Balance = 1000;
    private readonly object lockObj = new object();

    public void Withdraw(int amount)
    {
        lock (lockObj)
        {
            if (Balance >= amount)
            {
                Console.WriteLine($"Withdrawing {amount}");
                Thread.Sleep(100);
                Balance -= amount;
                Console.WriteLine($"Remaining Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        Thread t1 = new Thread(() => acc.Withdraw(700));
        Thread t2 = new Thread(() => acc.Withdraw(700));
        Thread t3 = new Thread(() => acc.Withdraw(700));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }
}