using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Menus

{
    public class AssemblyMenuPage : IPage, IPageMenu
    {
        private readonly GameController _gameController;

        public AssemblyMenuPage(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Back()
        {
            _gameController.GoToMainMenu();
        }

        public void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector();
        }

        public void MenuOptions()
        {
            Console.WriteLine("A:\tCreate a new PC Blueprint");
            Console.WriteLine("B:\tTo alter an existing blueprint.");

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("x: back to main menu.");
        }

        public void MenuSelector()
        {
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
            if (key == "X" || key == "x")
            {
                Back();            }
        }

        public void Title()
        {
            Console.WriteLine("Assembly Menu");
            Console.WriteLine("---------------------------");
        }
    }
}
