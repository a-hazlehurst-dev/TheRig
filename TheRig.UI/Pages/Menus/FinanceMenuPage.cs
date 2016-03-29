using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Menus
{

    public class FinanceMenuPage : IPage, IPageMenu
    {
        private readonly GameController _gameController;
        public FinanceMenuPage(GameController gameController)
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
            Console.WriteLine("Current Balance: £" + _gameController.GameManager.GameServices.Finance.GetFunds(1));
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }

        public void MenuOptions()
        {
            Console.WriteLine("A:\tView Transactions.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("X:\tBack to main menu.");
        }

        public void MenuSelector(string key)
        {
            if(key.Equals("A")|| key.Equals("a"))
            {
                _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["Transactions"];
            }
            if(key.Equals("X") || key.Equals("x"))
            {
                Back();
            }
        }

        public void Title()
        {
            Console.WriteLine("Finance Mananger");
            Console.WriteLine("-------------------------------");
        }
    }
}
