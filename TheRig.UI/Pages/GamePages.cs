using System.Collections.Generic;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages
{
    public class GamePages
    {
        public Dictionary<string, IPage> Pages { get; set; }
        public IPage ActivePage { get; set; }

        private readonly DisplayController _displayController;
        public GamePages(DisplayController displayController)
        {
            _displayController = displayController;
            Pages = new Dictionary<string, IPage>();
            Pages.Add("MainMenu", new MainMenuPage(_displayController));
            Pages.Add("Credits", new CreditsPage());
            Pages.Add("CreateComputer", new NewComputerPage(_displayController));
            Pages.Add("ComputerDisplay", new ComputerDescriptionPage(_displayController));
            Pages.Add("SelectComputer", new FindComputersPage(_displayController));
            Pages.Add("AddComponents", new PickComputerComponents(_displayController));
            ActivePage = Pages["MainMenu"];
        }

    }
}