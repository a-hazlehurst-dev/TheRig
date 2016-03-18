using System;
using TheRig.Core.Managers;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;

namespace TheRig.UI.Pages.Menus
{
    public class MarketingMenuPage : IPage
    {
        private readonly GameController _gameController;
        private readonly AdvertisingManager _advertisingManager;
        private readonly HypeManager _hypeManager;

        public MarketingMenuPage(GameController gameController)
        {
            _gameController = gameController;
            _advertisingManager = _gameController.Player.Advertising;
            _hypeManager = _gameController.Player.HypeManager;
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
