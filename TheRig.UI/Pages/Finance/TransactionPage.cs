
using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus;

namespace TheRig.UI.Pages.Finance
{
    public class TransactionPage : IPage
    {
        private readonly GameController _gameController;

        public TransactionPage(GameController gameController)
        {
            _gameController = gameController;
        }
        public void Back()
        {
            _gameController.GamePages.ActivePage = (FinanceMenuPage)_gameController.GamePages.Pages["FinanceMenu"];
        }

        public void Draw()
        {
            Title();

            foreach(var transaction in _gameController.Player.FinanceManager.TransactionManager.Transactions)
            {
                Console.WriteLine(transaction.DateCreated.ToString()+", "+ transaction.Name + ", " + transaction.Quantity + ", " + transaction.Value + ".");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("X: back to finance menu");

            var key = Console.ReadLine();
            if(key.Equals("X")|| key.Equals("x"))
            {
                Back();
            }

        }

        public void Title()
        {
            Console.WriteLine("Transactions");
            Console.WriteLine("--------------------------------");
        }
    }
}
