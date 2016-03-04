using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages;

namespace TheRig.UI.Pages
{
    public class MainMenuPage : IPage
    {
        private readonly DisplayController _displayController;

        public MainMenuPage(DisplayController displayController)
        {
            _displayController = displayController;
        }

        public void Draw()
        {
            Console.Write("Main Menu");
            if (!string.IsNullOrEmpty(_displayController.ActiveComputerName))
            {
                Console.WriteLine("\t\t (Selected Computer: " + _displayController.ActiveComputerName + ")");
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("A : To Create a new Computer.");
            Console.WriteLine("B : To Display Computer.");
            Console.WriteLine("D : Find and Select computer.");
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

            if (key == ConsoleKey.X)
            {
                _displayController.EndGame= true;
            }
            
        }
    }
}