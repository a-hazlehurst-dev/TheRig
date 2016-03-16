using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Menus
{


    public class PurchasingMenuPage : IPage, IPageMenu
    {

        private readonly GameController _gameController;

        public PurchasingMenuPage(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Title()
        {
            Console.WriteLine("Purchasing Menu");
            Console.WriteLine("------------------------------");
        }
        public void Back()
        {
            _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["MainMenu"];
        }

        public void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }

        public void MenuOptions()
        {
            Console.WriteLine("A:\t Purchase bulk items.");
            Console.WriteLine("B:\t Purchase for specific Blueprint.");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("X:\tReturn to main menu.");
        }

        public void MenuSelector(string key)
        {
            
            if(key.Equals("A") || key.Equals("a"))
            {
                _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["Purchase-BulkItems"];
            }
            if(key.Equals("B") || key.Equals("b"))
            {

            }
            if (key.Equals("X") || key.Equals("x"))
            {
                Back();
            }
        }
    }
}
