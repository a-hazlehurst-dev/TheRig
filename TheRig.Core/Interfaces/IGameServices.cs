using TheRig.Core.Services;

namespace TheRig.Core.Interfaces
{
    public interface IGameServices
    {
        MarketingService Marketing { get; set; }
        BlueprintService Blueprint { get; set; }
        CityService City { get; set; }
        FinanceService Finance { get; set; }
        HypeService Hype { get; set; }
        InventoryService Inventory { get; set; }
        PlayerService PlayerService { get; set; }
    }

}
