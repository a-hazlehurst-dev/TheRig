using System;
using System.Linq;
using TheRig.Models.Components;
using TheRig.UI.Controller;
using TheRig.UI.Helper;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Purchasing
{
    public class PurchaseBulkItems : IPage, IPageMenu
    {
        private readonly GameController _gameController;
        public PurchaseBulkItems(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Title()
        {
            Console.Write("Purchase Bulk Items");
            Console.WriteLine("\t\t\t\t" + _gameController.Player.FinanceManager.GetFunds());
            Console.WriteLine("---------------------------------");
        }
        

        public void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector();
        }
        public void Back()
        {
            _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["PurchasingMenu"];
        }

        public void MenuOptions()
        {
            Console.WriteLine("A: To buy Motherboards.");
            Console.WriteLine("B: To buy Cpu's");
            Console.WriteLine("C: To buy Ram");
            Console.WriteLine("D: To buy Graphics Cards");
            Console.WriteLine("E: To buy Sound Cards.");

            Console.WriteLine("------------------------------");
            Console.WriteLine("X:\tBack To Purchasing menu.");
        }

        public void MenuSelector()
        {
            var key = Console.ReadLine();
            if (key.Equals("A") || key.Equals("a"))
            {
                ViewAndSelectMotherboards();
            }
            if (key.Equals("B") || key.Equals("b"))
            {
                Back();
            }
            if (key.Equals("C") || key.Equals("c"))
            {
                Back();
            }
            if (key.Equals("D") || key.Equals("d"))
            {
                Back();
            }
            if (key.Equals("E") || key.Equals("e"))
            {
                Back();
            }
            if (key.Equals("X")|| key.Equals("x"))
            {
                Back();
            }
        }

        private void ViewAndSelectMotherboards()
        {
            var key = "";
            var val = 0;
            var isValid = false;
            DisplayHelper helper = new DisplayHelper();
            var item =helper.SelectableList(_gameController.UnitOfWork.MotherboardRepository.Find().Cast<Item>().ToList());
            do
            {
                Console.Write("How many would you like to order?");
                var funds =_gameController.Player.FinanceManager.GetFunds();
                var qty =( Math.Round(funds / item.Price, MidpointRounding.AwayFromZero));
                Console.WriteLine("Max: " + qty);
                key = Console.ReadLine();

                isValid = int.TryParse(key, out val);
                if(!isValid)
                {
                    Console.WriteLine(" invalid input.");
                    continue;
                }
                if(val * item.Price > funds)
                {
                    Console.WriteLine("You cannot afford this amount.");
                    isValid = false;
                }
                
            } while (!isValid);

            _gameController.Player.PurchasingManager.PurchaseItem(item, val, _gameController.GameDate);

            Console.ReadKey();
        }
    }
}
