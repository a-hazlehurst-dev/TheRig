using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.PageBinding;

namespace TheRig.UI.Pages.Menus

{
    public class AssemblyMenuPage : BasePage
    {
        

        public AssemblyMenuPage(GameController gameController, IPageBinding pageBinding) : base(gameController, pageBinding)
        {

        }
        public override void Draw()
        {
            Title();
            MenuOptions();
            MenuSelector(Console.ReadLine());
        }

        public override void MenuOptions()
        {
            Console.WriteLine("A:\tCreate a new PC Blueprint");
            Console.WriteLine("B:\tTo alter an existing blueprint.");
            base.MenuOptions();
        }

        public override void MenuSelector(string key)
        {
            _pageBinding.ExecuteInput(key);

            base.MenuSelector(key);
        }

        public override void Title()
        {
            base.Title();
            Console.WriteLine("Assembly Menu");
            Console.WriteLine("---------------------------");
        }
    }
}
