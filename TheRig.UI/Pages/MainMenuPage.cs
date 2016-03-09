using System;
using TheRig.Core;
using TheRig.UI.Controller;
using TheRig.UI.Helper;

namespace TheRig.UI.Pages
{
    public class MainMenuPage : IPage
    {
        private readonly GameController _displayController;

        public MainMenuPage(GameController displayController)
        {
            _displayController = displayController;
        }

        public void Draw()
        {
            UiTitleHelper.DrawMainTitle(_displayController);
            Console.Write("Main Menu");
            if (!string.IsNullOrEmpty(GameState.Instance.Player.ActiveComputerName))
            {
                Console.WriteLine("\t\t (Selected Computer: " + GameState.Instance.Player.ActiveComputerName + ")");
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("A : To Create a new Computer.");
            Console.WriteLine("B : To Display Computer.");
            Console.WriteLine("D : Find and Select computer.");
            Console.WriteLine("E : Marketing Department.");
            Console.WriteLine();
            Console.WriteLine("Z : Next Turn.");
            Console.WriteLine();
            Console.WriteLine("Press 'X' to quit");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.A)
            {
                var page = (NewComputerPage)_displayController.GamePages.Pages["CreateComputer"];
                _displayController.GamePages.ActivePage = page;

            }
            if (key == ConsoleKey.B)
            {
                var page = (ComputerDescriptionPage)_displayController.GamePages.Pages["ComputerDisplay"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.D)
            {
                var page = (FindComputersPage)_displayController.GamePages.Pages["SelectComputer"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.E)
            {
                var page = (MarketingMenuPage)_displayController.GamePages.Pages["AdvertisingPage"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.Z)
            {
                _displayController.Turn();
            }
            if (key == ConsoleKey.X)
            {
                _displayController.EndGame= true;
            }
            
        }
    }
}