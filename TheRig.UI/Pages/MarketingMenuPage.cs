using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using TheRig.Core;
using TheRig.UI.Controller;
using TheRig.UI.Helper;

namespace TheRig.UI.Pages
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
            UiTitleHelper.DrawAdvertismentTitle(_gameController);
            Console.WriteLine("Active Campaigns");
            Console.WriteLine("------------------------");
            foreach (var advertisingCampaign in _advertisingManager.Active)
            {
                Console.WriteLine("Status:\t\t" +advertisingCampaign.Status );
                Console.WriteLine("Start:\t\t" + advertisingCampaign.StartDate.ToString("D"));
                Console.WriteLine("End:\t\t" + advertisingCampaign.EndDate.ToString("D"));
                Console.WriteLine("Primary:\t" + advertisingCampaign.Primary.Name);
                Console.Write("Secondary:\t");
                
                foreach (var name in advertisingCampaign.Secondary)
                {
                    Console.Write(name.Name+", ");
                }
                Console.WriteLine("");
                
            }
            Console.WriteLine("");
            Console.WriteLine("Hype Meters");
            Console.WriteLine("---------------------");
            foreach (var meter in _hypeManager.HypeMeters)
            {
                Console.WriteLine(meter.Name + " { Hype: " + meter.Current.ToString("0.00") + " }");
            }
            Console.WriteLine();

            Console.WriteLine("X: Main Menu.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.X)
            {
                _gameController.GoToMainMenu();
            }

        }
    }
}
