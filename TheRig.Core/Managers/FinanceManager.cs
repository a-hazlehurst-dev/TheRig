using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRig.Core.Managers
{
    public class FinanceManager
    {
        private List<BankAccount> _bankAccounts;
        public TransactionManager TransactionManager { get; private set; }
        public FinanceManager(decimal startFunds)
        {
            _bankAccounts =new List<BankAccount>();
            TransactionManager = new TransactionManager();
            CreditFunds(new Transaction { Name = "Start up", Value = startFunds, DateCreated =DateTime.Now, Quantity = 1 });
        }

        public void CreateBankAccount(int player, decimal staringFunds)
        {
           _bankAccounts.Add(new BankAccount
           {
               Owner = player,
               Funds = staringFunds
           });
        }

        public void CreditFunds(Transaction transaction)
        {
            var bankAccount = _bankAccounts.SingleOrDefault(x => x.Owner == transaction.Owner);
            bankAccount.Funds+= transaction.Value;
            TransactionManager.Add(transaction);
        }

        public void DebitFunds(Transaction transaction)
        {
            var bankAccount = _bankAccounts.SingleOrDefault(x => x.Owner == transaction.Owner);
            bankAccount.Funds += transaction.Value;
            TransactionManager.Add(transaction);
        }

        public decimal GetFunds(int id)
        {
            return  _bankAccounts.SingleOrDefault(x => x.Owner == id).Funds;
        }
    }

    public class BankAccount
    {
        public int Owner { get; set; }
        public decimal Funds { get; set; }
    }
}
