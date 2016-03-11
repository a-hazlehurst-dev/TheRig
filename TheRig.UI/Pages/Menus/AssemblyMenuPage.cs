using System;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages.Menus
{
    public class AssemblyMenuPage : IPage
    {
        private readonly GameController _gameController;

        public AssemblyMenuPage(GameController gameController)
        {
            _gameController = gameController;
        }


        public void Draw()
        {
            Console.WriteLine("Blueprints");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");

            Console.WriteLine("A:\tCreate a new PC Blueprint");
            Console.WriteLine("B:\tTo alter an existing blueprint.");
            Console.WriteLine("C:\tPurchase supplies for Pc.");

            Console.WriteLine("");
            Console.WriteLine("x: back to main menu.");

            var key = Console.ReadLine();
            if (key == "A" || key == "a")
            {
                var page = (CreateBlueprint)_gameController.GamePages.Pages["Create-Blueprint"];
                _gameController.GamePages.ActivePage = page;
            }
            if (key == "B" || key == "b")
            {
                var page = (SelectMenuComponentsPage)_gameController.GamePages.Pages["Select-BlueprintComponents"];
                _gameController.GamePages.ActivePage = page;
            }
            if (key == "C" || key == "c")
            {
                var page = (PurchaseBlueprintSupplies)_gameController.GamePages.Pages["Purchase-BlueprintSupplies"];
                _gameController.GamePages.ActivePage = page;
            }
            if (key == "X" || key == "x")
            {
                _gameController.GoToMainMenu();
            }

        }
    }
}
