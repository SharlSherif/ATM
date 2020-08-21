using System;


class Account
{
    public string[] Types = {
        "Savings",
        "Checking"
    };

    public string Type;
    public int Balance;
    public Account(int pinNumber)
    {
        // getting that specific user balance from db
        Balance = 10;
        Type = Types[1];
    }
}
class ATM
{
    private Account account;
    
    public ATM (int pinNumber)
    {
        account = new Account(pinNumber);
        getCurrentBalance();
    }
    public void Deposit (int amount)
    {
        account.Balance += amount;
        Console.WriteLine(amount + " was deposited successfully");
        getCurrentBalance();
    }

    public int getCurrentBalance()
    {
        Console.WriteLine("Current balance is " + account.Balance);
        return account.Balance;
    }
    public int Withdraw (int amount)
    {
        // if it's a savings account, they cannot withdraw
        if(account.Type == account.Types[0])
        {
            Console.WriteLine("This account is a savings account, you cannot withdraw from it");
            return -1;
        }
        else if (amount > account.Balance)
        {
            Console.WriteLine("Current balance is not sufficient to complete the transaction");
            return -1;
        }else
        {
            account.Balance -= amount;
            Console.WriteLine("Withdrawn "+amount);
            getCurrentBalance();
            return amount;
        }
    }
}

namespace OOP_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATM(2312);
            atm.Deposit(1200000);
            atm.Withdraw(200);
        }
    }
}
