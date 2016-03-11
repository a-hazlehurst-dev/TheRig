using System;
using System.Linq;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;

namespace TheRig.UI.Pages.Inventory
{
    public class InventoryMenuPage : IPage, IPageMenu
    {
        private readonly GameController _gameController;
        public InventoryMenuPage(GameController gameController)
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
            View();
            MenuOptions();
            MenuSelector();
        }
        public void View()
        {

            var distinct = _gameController.Player.InventoryManager.Inventory.Distinct();
            foreach(var item in distinct)
            {
                Console.WriteLine(item.Name + ", " + _gameController.Player.InventoryManager.Inventory.Count(x => x.Name == item.Name));
            }
            Console.WriteLine();
        }
        public void MenuOptions()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("X: to go back.");
        }

        public void MenuSelector()
        {
            var key = Console.ReadLine();
            if(key.Equals("X")|| key.Equals("x"))
            {
                Back();
            }
        }

        public void Title()
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("------------------------------");
        }
    }
}
