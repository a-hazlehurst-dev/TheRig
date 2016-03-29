using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Configuration;
using TheRig.Core.Interfaces;
using TheRig.Models.Finance;

namespace TheRig.Core.Services
{
    public class FinanceService
    {
        private readonly List<BankAccount> _bankAccounts;
        public FinanceService(decimal startFunds)
        {
            _bankAccounts =new List<BankAccount>();
        }

        public void Build(GameplayConfiguration gameConfiguration)
        {
            for (int i = 0; i < gameConfiguration.Players; i++)
            {
                _bankAccounts.Add(new BankAccount
                {
                    Owner = i+1,
                    Funds = gameConfiguration.StartingFunds
                });
            }
        }

        public decimal GetFunds(int id)
        {
            return  _bankAccounts.Single(x => x.Owner == id).Funds;
        }

        public void CreditAccount(int playerId, decimal value)
        {
            var playerFunds = GetFunds(playerId);
            playerFunds += value;
        }

        public void DebitAccount(int playerId, decimal value)
        {
            var playerFunds = GetFunds(playerId);
            playerFunds -= value;
        }

    }

  
}
