using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;
using TheRig.UI.Pages.PageBinding;
using TheRig.UI.Pages.Supply;

namespace TheRig.UI.Pages.Menus
{

    public class SupplyPageBinding : IPageBinding
    {
        public void ExecuteInput(string key)
        {
            if (key.Equals("A") || key.Equals("a"))
            {
                GameController.GamePages.ActivePage = GameController.GamePages.Pages["ManufacturersViewPage"];
            }
            else if (key.Equals("B") || key.Equals("b"))
            {

            }
            if (key.Equals("C") || key.Equals("c"))
            {

            }
            if (key.Equals("D") || key.Equals("d"))
            {

            }
        }

        public GameController GameController { get; set; }
    }
    public class SupplyMenuPage : BasePage
    {
        public SupplyMenuPage(GameController gameController, IPageBinding pageBinding): base(gameController, pageBinding)
        {
        }

        public override void Title()
        {
            base.Title();
            Console.WriteLine("Supply Menu");
        }

        public override void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }


        public override void MenuOptions()
        {
            Console.WriteLine("A:\t Manufacturers");
            Console.WriteLine("B:\t Distributors");
            Console.WriteLine("C:\t Relations");
            Console.WriteLine("D:\t Owned");
            base.MenuOptions();
        }

       
    }
}
