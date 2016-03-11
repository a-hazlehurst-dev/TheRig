﻿using System;
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
                Console.WriteLine("------------------------");


            }
            Console.WriteLine("");
            Console.WriteLine("Hype Meters");
            Console.WriteLine("---------------------");
            int count = 0;
            foreach (var meter in _hypeManager.HypeMeters)
            {
                Console.Write(meter.Name);
                if (meter.Name.Length < 8)
                {
                    Console.Write("\t\t");
                }
                else
                {
                    Console.Write("\t");
                }
                if (count%2 == 0)
                {
                    Console.Write("{ Hype: " + meter.Current.ToString("0.00") + " }\t");
                }
                else
                {
                    Console.WriteLine("{ Hype: " + meter.Current.ToString("0.00") + " }");
                }
                count++;
            }

                
            
            Console.WriteLine();

            Console.WriteLine("X: Main Menu.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.X)
            {
                Back();   
            }

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
