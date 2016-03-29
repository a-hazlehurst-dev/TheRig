using System.Collections.Generic;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus;
using TheRig.UI.Pages.PageBinding;
using TheRig.UI.Pages.Supply;

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
            Pages.Add("GameMenu", new GameMenuPage(_displayController));
            Pages.Add("MainMenu", new MainMenuPage(_displayController, new MainMenuPageBinding()));
            Pages.Add("Credits", new CreditsPage());
            Pages.Add("ManufacturersViewPage", new ManufacturersViewPage(_displayController, new ManufacturerViewPageBinding()));
            Pages.Add("SupplyMenu", new SupplyMenuPage(_displayController, new SupplyPageBinding()));
            Pages.Add("FinanceMenu", new FinanceMenuPage(_displayController));
            Pages.Add("CityMenu", new CityMenuPage(_displayController, new CityMenuPageBinding()));
            Pages.Add("CityView", new CityViewPage(_displayController, new CityViewPageBinding()));

            ActivePage = Pages["GameMenu"];
        }

    }

    
}