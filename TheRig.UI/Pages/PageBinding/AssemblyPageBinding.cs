using System;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages.PageBinding
{
    public class AssemblyPageBinding : IPageBinding
    {
        public GameController GameController { get; set; }

        public void ExecuteInput(string key)
        {
            if (key == "A" || key == "a")
            {
                var page = (CreateBlueprint)GameController.GamePages.Pages["Create-Blueprint"];
                GameController.GamePages.ActivePage = page;
            }
            if (key == "B" || key == "b")
            {
                var page = (SelectMenuComponentsPage)GameController.GamePages.Pages["Select-BlueprintComponents"];
                GameController.GamePages.ActivePage = page;
            }
        }
    }
}
