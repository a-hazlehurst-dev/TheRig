using System.Collections.Generic;
using TheRig.UI.Controller;

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
            Pages.Add("CreateComputer", new NewComputerPage(_displayController));
            Pages.Add("ComputerDisplay", new ComputerDescriptionPage(_displayController));
            Pages.Add("SelectComputer", new FindComputersPage(_displayController));
            Pages.Add("AddComponents", new PickComputerComponents(_displayController));
            Pages.Add("AdvertisingPage", new MarketingMenuPage(_displayController));
            ActivePage = Pages["MainMenu"];
        }

    }
}