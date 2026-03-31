using System;

// Custom Exception
public class CheckBalanceException : Exception
{
    public CheckBalanceException(string message) : base(message) { }
}

// BankAccount Class
public class BankAccount
{
    public int AccountNumber { get; set; }
    public string Name { get; set; }
    public static double Balance { get; private set; } = 500; // minimum balance
    public char TransactionType { get; set; }
    public double TransactionAmount { get; set; }

    public BankAccount(int accountNumber, string name)
    {
        AccountNumber = accountNumber;
        Name = name;
    }

    public void PerformTransaction(char type, double amount)
    {
        TransactionType = type;
        TransactionAmount = amount;

        if (type == 'd') // deposit
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount} | Current Balance: {Balance}");
        }
        else if (type == 'c') // withdraw
        {
            if (Balance - amount < 500)
            {
                throw new CheckBalanceException("Withdrawal denied! Balance cannot go below 500.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn: {amount} | Current Balance: {Balance}");
            }
        }
        else
        {
            Console.WriteLine("Invalid transaction type!");
        }
    }
}

// Example Usage
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(101, "Alice");

        try
        {
            account.PerformTransaction('d', 1000); // deposit
            account.PerformTransaction('c', 800);  // withdrawal
            account.PerformTransaction('c', 300);  // should throw exception
        }
        catch (CheckBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
