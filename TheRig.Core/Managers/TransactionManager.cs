
using System;
using System.Collections.Generic;

namespace TheRig.Core.Managers
{
    public class TransactionManager
    {
        public List<Transaction> Transactions { get;private  set; }

        public TransactionManager()
        {
            Transactions = new List<Transaction>();
        }

        public void Add(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
    }


    public class Transaction
    {
        public int Owner { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
