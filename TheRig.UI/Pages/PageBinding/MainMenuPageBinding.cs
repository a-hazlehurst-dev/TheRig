using TheRig.UI.Controller;
using TheRig.UI.Pages.Inventory;
using TheRig.UI.Pages.Menus;

namespace TheRig.UI.Pages.PageBinding
{
    public class MainMenuPageBinding : IPageBinding
    {
        public MainMenuPageBinding()
        {
        }

        public GameController GameController { get; set;}



        public void ExecuteInput(string key)
        {
            if (key.Equals("A") || key.Equals("a"))
            {
                var page = (AssemblyMenuPage)GameController.GamePages.Pages["AssemblyMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("B") || key.Equals("b"))
            {
                var page = (MarketingMenuPage)GameController.GamePages.Pages["MarketingMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("C") || key.Equals("c"))
            {
                var page = (PurchasingMenuPage)GameController.GamePages.Pages["PurchasingMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("D") || key.Equals("d"))
            {
                var page = (InventoryMenuPage)GameController.GamePages.Pages["InventoryMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("E") || key.Equals("e"))
            {
                var page = (FinanceMenuPage)GameController.GamePages.Pages["FinanceMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("F") || key.Equals("f"))
            {
                var page = (CityMenuPage)GameController.GamePages.Pages["CityMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("Z") || key.Equals("z"))
            {
                GameController.Turn();
            }

        }
    }
}
