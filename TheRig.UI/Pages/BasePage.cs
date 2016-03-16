using System;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus.Interfaces;
using TheRig.UI.Pages.PageBinding;

namespace TheRig.UI.Pages
{
    public class BasePage : IPage, IPageMenu
    {
        protected GameController _gameController;
        protected IPageBinding _pageBinding;

        public BasePage(GameController gameController, IPageBinding pageBinding)
        {
            _gameController = gameController;
            _pageBinding = pageBinding;
            _pageBinding.GameController = _gameController;
        }
        public virtual void Back()
        {
            _gameController.GoToMainMenu();
        }

        public virtual void Draw()
        {

        }

        public virtual void MenuOptions()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("X: To go back.");
        }

        public virtual void MenuSelector(string key)
        {
            _pageBinding.ExecuteInput(key);

            if (key.Equals("x") || key.Equals("X"))
            {
                Back();
            }
        }

        public virtual void Title()
        {
            Console.WriteLine("The Rig");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
