using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Managers;
using TheRig.Models;
using TheRig.Models.Components;

namespace TheRig.Core
{
    public class Player
    {
        public string ActiveComputerName { get; set; }
        public List<Computer> ComputerPool { get; set; }

        public BlueprintManager BlueprintManager { get; set; }

        public AdvertisingManager Advertising { get; set; }
        public HypeManager HypeManager { get; set; }

        public CustomerManager CustomerManager { get; set; }
        public FinanceManager FinanceManager { get; set; }

        public Player(DateTime datetime)
        {
            ComputerPool = new List<Computer>();
            HypeManager = new HypeManager();
            Advertising = new AdvertisingManager();
            BlueprintManager = new BlueprintManager();
            FinanceManager = new FinanceManager(1000.0M);
            Advertising.AddAdvertisingCampaign(new AdvertisingCampaign
            {
                StartDate = datetime.AddDays(7),
                EndDate = datetime.AddMonths(6),
                Primary = new Demographic { Name ="Youths"},
                Secondary = new List<Demographic>
                {
                    new Demographic { Name ="Kids" }
                }
            });
            Advertising.AddAdvertisingCampaign(new AdvertisingCampaign
            {
                StartDate = datetime.AddDays(7),
                EndDate = datetime.AddMonths(8),
                Primary = new Demographic { Name = "Adults" },
                Secondary = new List<Demographic>
                {
                    new Demographic { Name ="Kids" },
                    new Demographic { Name ="Retired" },
                    new Demographic { Name ="Youths" },
                }
            });
            ActiveComputerName = "Not Set.";
            CustomerManager = new CustomerManager(HypeManager);
        }

        public Computer GetComputer(string name)
        {
            return ComputerPool.SingleOrDefault(x => x.Name.Equals(name));
        }

        public Computer GetActiveComputer()
        {
            return ComputerPool.SingleOrDefault(x => x.Name.Equals(ActiveComputerName));
        }

        public void Turn(DateTime gameDate)
        {
            Advertising.Turn(gameDate);
            HypeManager.Turn(gameDate, Advertising.Active);
            CustomerManager.Turn(gameDate);

        }
    }

    public class FinanceManager
    {
        private decimal _funds = 0.0M;
        public FinanceManager(decimal startFunds)
        {
            CreditFunds(startFunds);
        }


        public void CreditFunds(decimal funds)
        {
            _funds += funds;
        }

        public void DebitFunds(decimal funds)
        {
            _funds -= funds;
        }

        public decimal GetFunds()
        {
            return _funds;
        }
    }
}