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
        public PurchasingManager PurchasingManager { get; set; }
        public InventoryManager InventoryManager { get; set; }

        public Player(DateTime datetime)
        {
            
            ComputerPool = new List<Computer>();
            HypeManager = new HypeManager();
            Advertising = new AdvertisingManager();
            BlueprintManager = new BlueprintManager();
            FinanceManager = new FinanceManager(1000.0M);
            InventoryManager = new InventoryManager();
            PurchasingManager = new PurchasingManager(FinanceManager, InventoryManager);
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
            CustomerManager.Turn(gameDate);
        }
    }

    
}