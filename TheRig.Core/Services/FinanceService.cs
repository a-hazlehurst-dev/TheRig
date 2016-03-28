using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRig.Core.Services
{
    public class FinanceService
    {
        private List<BankAccount> _bankAccounts;
        public FinanceService(decimal startFunds)
        {
            _bankAccounts =new List<BankAccount>();
        }

        public void CreateBankAccount(int player, decimal staringFunds)
        {
           _bankAccounts.Add(new BankAccount
           {
               Owner = player,
               Funds = staringFunds
           });
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
