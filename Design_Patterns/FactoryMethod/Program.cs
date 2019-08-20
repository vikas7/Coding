using System;

namespace FactoryMethod
{
    public abstract class ISavingAccount
    {
        public decimal Balance { get; set; }
    }

    class CitiSavingAcct : ISavingAccount
    {
        public CitiSavingAcct()
        {
            Balance = 500;
        }
    }
    class NationalSavingAcct : ISavingAccount
    {
        public NationalSavingAcct()
        {
            Balance = 2000;
        }
    }
    interface ICreditUnionFactory
    {
        ISavingAccount GetSavingsAccount(string acctNo);
    }
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITI"))
            {
                return new CitiSavingAcct();
            }
            else if (acctNo.Contains("NATIONAL"))
            {
                return new NationalSavingAcct();
            }
            else
            {
                throw new ArgumentException("Invalid account number");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Factory = new SavingsAcctFactory() as ICreditUnionFactory;
            var citiAcct = Factory.GetSavingsAccount("CITI-321");
            var nationalAcct = Factory.GetSavingsAccount("NATIONAL-987");
            Console.WriteLine($"My citi balance is ${citiAcct.Balance} " + $" and national balance is ${nationalAcct.Balance}");
        }
    }
}
