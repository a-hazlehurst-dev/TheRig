using TheRig.UI.Controller;
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
                var page = (FinanceMenuPage)GameController.GamePages.Pages["FinanceMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("B") || key.Equals("b"))
            {
                var page = (CityMenuPage)GameController.GamePages.Pages["CityMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("C") || key.Equals("c"))
            {
                var page = (SupplyMenuPage)GameController.GamePages.Pages["SupplyMenu"];
                GameController.GamePages.ActivePage = page;
            }
            if (key.Equals("Z") || key.Equals("z"))
            {
                GameController.Turn();
            }
        }
    }
}
