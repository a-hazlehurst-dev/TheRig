using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;

namespace TheRig.UI.Pages.Menus
{
    public class MarketingMenuPage : IPage
    {
        private readonly GameController _gameController;

        public MarketingMenuPage(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Draw()
        {
            Console.WriteLine("Active Advertising Campaigns");
            Console.WriteLine("------------------------");

        }

        public void Title()
        {
            Console.WriteLine("Marketing Main Menu");
            Console.WriteLine("--------------------------");
        }

        public void Back()
        {
            _gameController.GoToMainMenu();
        }
    }
}
