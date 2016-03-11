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

        public Player(DateTime datetime)
        {
            Blueprints = new List<Blueprint>();
            ComputerPool = new List<Computer>();
            HypeManager = new HypeManager();
            Advertising = new AdvertisingManager();
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
}