using System;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages.PageBinding
{
    public class CityMenuPageBinding : IPageBinding
    {
        public GameController GameController { get; set; }

        public void ExecuteInput(string key)
        {
            if (key == "A" || key == "a")
            {
                GameController.GamePages.ActivePage = GameController.GamePages.Pages["CityView"];
            }
            if (key == "B" || key == "b")
            {

            }
        }
    }
}
