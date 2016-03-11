using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Inventory;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Menus
{
    public class MainMenuPage : IPage, IPageMenu
    {
        private readonly GameController _displayController;

        public MainMenuPage(GameController displayController)
        {
            _displayController = displayController;
        }

        public void Title()
        {
            Console.WriteLine("The Rig.");
            Console.WriteLine("============================");
            Console.WriteLine("Main Menu");
        }

        public void Draw()
        {
            Title();
            Menu();
        }

        public void Menu()
        {
            MenuOptions();
            MenuSelector();
        }

        public void MenuOptions()
        {
            Console.WriteLine("A:\tBlueprints");
            Console.WriteLine("B:\tMarketing");
            Console.WriteLine("C:\tPurchasing");
            Console.WriteLine("D:\tInventory");
            Console.WriteLine("E\tFinance");
            Console.WriteLine();
            Console.WriteLine("Z:\tNext Turn.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press 'X' to quit");
        }


        public void MenuSelector()
        {
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.A)
            {
                var page = (AssemblyMenuPage)_displayController.GamePages.Pages["AssemblyMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.B)
            {
                var page = (MarketingMenuPage)_displayController.GamePages.Pages["MarketingMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.C)
            {
                var page = (PurchasingMenuPage)_displayController.GamePages.Pages["PurchasingMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if(key== ConsoleKey.D)
            {
                var page = (InventoryMenuPage)_displayController.GamePages.Pages["InventoryMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.E)
            {
                var page = (FinanceMenuPage)_displayController.GamePages.Pages["FinanceMenu"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.Z)
            {
                _displayController.Turn();
            }
            if (key == ConsoleKey.X)
            {
                Back();
            }
        }

        public void Back()
        {
            _displayController.EndGame = true;
        }


    }
}