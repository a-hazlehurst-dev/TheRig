using System;
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
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("A:\tBlueprints");
            Console.WriteLine("B:\tMarketing");
            Console.WriteLine();
            Console.WriteLine("Z:\tNext Turn.");
            Console.WriteLine();
            Console.WriteLine("Press 'X' to quit");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.A)
            {
                var page = (AssemblyMenuPage) _displayController.GamePages.Pages["AssemblyMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.B)
            {
                var page = (MarketingMenuPage)_displayController.GamePages.Pages["MarketingMenu"];
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