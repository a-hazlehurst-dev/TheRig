using System.Collections.Generic;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Finance;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Inventory;
using TheRig.UI.Pages.Menus;
using TheRig.UI.Pages.Purchasing;

namespace TheRig.UI.Pages
{
    public class GamePages
    {
        public Dictionary<string, IPage> Pages { get; set; }
        public IPage ActivePage { get; set; }

        private readonly GameController _displayController;
        public GamePages(GameController displayController)
        {
            _displayController = displayController;
            Pages = new Dictionary<string, IPage>();
            Pages.Add("MainMenu", new MainMenuPage(_displayController));
            Pages.Add("Credits", new CreditsPage());
            Pages.Add("AssemblyMenu", new AssemblyMenuPage(_displayController));
            Pages.Add("MarketingMenu", new MarketingMenuPage(_displayController));
            Pages.Add("PurchasingMenu", new PurchasingMenuPage(_displayController));
            Pages.Add("Create-Blueprint", new CreateBlueprint(_displayController));
            Pages.Add("InventoryMenu", new InventoryMenuPage(_displayController));
            Pages.Add("FinanceMenu", new FinanceMenuPage(_displayController));

            Pages.Add("Select-BlueprintComponents", new SelectMenuComponentsPage(_displayController));
            Pages.Add("Purchase-BlueprintSupplies", new PurchaseBlueprintSupplies(_displayController));

            Pages.Add("Purchase-BulkItems", new PurchaseBulkItems(_displayController));
            Pages.Add("Transactions", new TransactionPage(_displayController));


            ActivePage = Pages["MainMenu"];
        }

    }

    
}