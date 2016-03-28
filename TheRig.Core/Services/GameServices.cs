using TheRig.Core.Interfaces;

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
    }
}
