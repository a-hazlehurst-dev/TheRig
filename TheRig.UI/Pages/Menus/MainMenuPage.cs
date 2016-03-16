using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.PageBinding;

namespace TheRig.UI.Pages.Menus
{
    public class MainMenuPage : BasePage 
    {

        public MainMenuPage(GameController gameController, IPageBinding pageBinding) : base(gameController, pageBinding)
        {
            _pageBinding = pageBinding;
        }

        public override void Title()
        {
            base.Title();
            Console.WriteLine("Main Menu");
        }

        public override void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }

        public override void MenuOptions()
        {
            Console.WriteLine("A:\tBlueprints");
            Console.WriteLine("B:\tMarketing");
            Console.WriteLine("C:\tPurchasing");
            Console.WriteLine("D:\tInventory");
            Console.WriteLine("E\tFinance");
            Console.WriteLine("F\tCity View");
            Console.WriteLine();
            Console.WriteLine("Z:\tNext Turn.");
            base.MenuOptions();
        }

        public override void MenuSelector(string key)
        {
            _pageBinding.ExecuteInput(key);
            
            if (key.Equals("X") || key.Equals("x"))
            {
                Back();
            }
        }

        public override void Back()
        {
            _gameController.EndGame = true;
        }
    }
}