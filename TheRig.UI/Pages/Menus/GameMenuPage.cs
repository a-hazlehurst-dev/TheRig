using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Menus
{
    public class GameMenuPage : IPage, IPageMenu
    {
        public GameController _gameController;
        public GameMenuPage(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Back()
        {
            Environment.Exit(1);
        }

        public void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }

        public void MenuOptions()
        {
            
            Console.WriteLine("A: Start new game.");
            Console.WriteLine("B: Load game.");
            Console.WriteLine("C: Exit.");
        }

        public void MenuSelector(string option)
        {
            if(option.Equals("A") || option.Equals("a"))
            {
                _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["MainMenu"];
            }
            else if (option.Equals("B") || option.Equals("b"))
            {
                Console.WriteLine("Not Written Yet!");
                Console.ReadKey();
            }
            else
            {
                Back();
            }
        }

        public void Title()
        {
            Console.WriteLine("Welcome to the Rig!");
        }
    }
}
