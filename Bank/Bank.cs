using System;

namespace Bank
{
    /// <summary>
    ///  Bank account demo class.
    ///  </summary>
    public class BankAccount    
    {
        public const string DebetAmountExceedsBalanceMessage = "Debet amount exceedsbalance";
        public const string DebetAmountLessThanZeroMessage = "Debet amount is less thanzero";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName        
        {
            get { return m_customerName; }
        }

        public void Debet(double amount)
        {
            if (amount > m_balance)
            { 
                throw new System.ArgumentOutOfRangeException("amount", amount, DebetAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            { 
                throw new System.ArgumentOutOfRangeException("amount", amount, DebetAmountLessThanZeroMessage);
            }
            m_balance -= amount; // intentionally correct code
        }

        public double Balance        
        {
            get { return m_balance; }
        }

        public void Credit(double amount) 
        { 
            if (amount < 0) 
            { 
                throw new ArgumentOutOfRangeException("amount"); 
            } 
            m_balance += amount; 


        }
    }
    
}