using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;
using TheRig.UI.Pages.PageBinding;

namespace TheRig.UI.Pages.Menus
{
    public class CityMenuPage : BasePage
    {

        public CityMenuPage(GameController gameController, IPageBinding  pageBinding): base(gameController, pageBinding)
        {
            
        }
        public override void Title()
        {
            base.Title();
        }

        public override void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
            
        }

        public override void MenuOptions()
        {
            Console.WriteLine("City Menu");
            Console.WriteLine("A: To view city Information.");
            Console.WriteLine("B: To view Regional Information.");
            base.MenuOptions();
            
        }

        public override void MenuSelector(string option)
        {
            _pageBinding.ExecuteInput(option);
            base.MenuSelector(option);
        }

     
    }

   
}
