using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Menus;

namespace TheRig.UI.Pages
{
    public class PurchaseBlueprintSupplies : IPage
    {
        private readonly GameController _gameController;

        public PurchaseBlueprintSupplies(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Title()
        {
            Console.Write("Purchase Supplies");
            Console.WriteLine("\t\t\t£"+_gameController.Player.FinanceManager.GetFunds().ToString("0.00"));
            Console.WriteLine("--------------------------------");
            Console.WriteLine();
        }


        public void Draw()
        {
            Title();
            Options();
            Console.Read();
            Back();
        }

        private void Options()
        {
            Console.WriteLine("A: select a blueprint to buy.");
            Console.WriteLine("B: select a component to buy.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("X: Return to previous page.");
        }

        private void MenuSelect()
        {
            var x = Console.ReadKey();
            if (x.Key == ConsoleKey.X)
            {
                Back();
            }
        }
        

        public void Back()
        {
            var page = (AssemblyMenuPage)_gameController.GamePages.Pages["AssemblyMenu"];
            _gameController.GamePages.ActivePage = page;
        }
    }
}
