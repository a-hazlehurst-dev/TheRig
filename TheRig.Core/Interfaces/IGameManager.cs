using System;
using System.Collections.Generic;
using TheRig.Core.Configuration;
using TheRig.Core.Managers;
using TheRig.Core.Services;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces
{
    public interface IGameManager
    {
       
        GamePreferences GameConfiguration { get; set; }
        IGameState GameState { get; set; }
        IUnitOfWork UnitOfWork { get;  }
        CityService CityService { get;  }
        void Start();
        void End();
        void Turn();
    }

    public class Managers
    {
        public List<Computer> ComputerPool { get;  }
        public BlueprintManager BlueprintManager { get; }
        public AdvertisingManager Advertising { get; }
        public HypeManager HypeManager { get;  }
        public CustomerManager CustomerManager { get; }
        public FinanceManager FinanceManager { get;  }
        public PurchasingManager PurchasingManager { get; }
        public InventoryManager InventoryManager { get;  }

        public Managers()
        {
            ComputerPool = new List<Computer>();
            BlueprintManager = new BlueprintManager();
            Advertising = new AdvertisingManager();
            HypeManager = new HypeManager();
            CustomerManager = new CustomerManager(HypeManager);
            FinanceManager = new FinanceManager(2000);
            InventoryManager = new InventoryManager();
            PurchasingManager = new PurchasingManager(FinanceManager, InventoryManager);
        }
    }

    public interface IGameState
    {
        int ActivePlayerId { get; set; }
        Managers Managers { get; set; }
        List<Player> Players { get; set; }
        void Initialise();
        void Turn();
    }

    public class GameState : IGameState
    {

        public GameState()
        {
            Initialise();
        }

        public int ActivePlayerId { get; set; }
        public Managers Managers { get; set; }
        public List<Player> Players { get; set; }
        public DateTime GameDateTime { get; set; }
        public void Initialise()
        {
            Managers = new Managers();
            Players = new List<Player>();
            GameDateTime = new DateTime(1990, 1, 6);
            ActivePlayerId = 1;
        }

        public void Turn()
        {
            throw new System.NotImplementedException();
        }
    }

    
}
