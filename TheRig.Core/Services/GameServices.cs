using System;
using System.Threading.Tasks;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale.Builders;

namespace TheRig.Core.Services
{
    public class GameServices : IGameServices
    {
        public MarketingService Marketing { get; set; }
        public BlueprintService Blueprint { get; set; }
        public CityService City { get; set; }
        public FinanceService Finance { get; set; }
        public HypeService Hype { get; set; }
        public InventoryService Inventory { get; set; }
        public PlayerService PlayerService { get; set; }

        public GameServices()
        {
            Marketing = new MarketingService();
            Blueprint = new BlueprintService();
            City = new CityService(new CityBuilder(new RegionBuilder()));
            Finance = new FinanceService(1000M);
            Hype = new HypeService();
            Inventory = new InventoryService();
            PlayerService = new PlayerService();
        }

        public void Build(IGameConfiguration config)
        {
            City.BuildNewCity(config.GameplayConfiguration.CityConfiguration);
        }
    }
}
