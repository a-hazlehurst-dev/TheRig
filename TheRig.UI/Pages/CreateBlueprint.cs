using System;
using TheRig.Models;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;
using TheRig.UI.Pages.Menus;

namespace TheRig.UI.Pages
{
    public class CreateBlueprint : IPage
    {
        private readonly GameController _controller;

        public CreateBlueprint(GameController controller)
        {
            _controller = controller;
        }


        public void Title()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Blueprint creation Screen");
            Console.WriteLine();
        }

        public void Back()
        {
            var page = (AssemblyMenuPage)_controller.GamePages.Pages["AssemblyMenu"];
            _controller.GamePages.ActivePage = page;
        }

        public void Draw()
        {
            Title();
            var valid = false;
            var name = "";
            do
            {
                Console.WriteLine("Please provide a unique name for your blueprint.");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name)|| _controller.GameManager.GameState.Managers.BlueprintManager.GetBlueprintByName(name) !=null)
                {
                    Console.WriteLine("Invalid name.");
                }
                else
                {
                    valid = true;
                }

            } while (!valid);

            _controller.GameManager.GameState.Managers.BlueprintManager.Blueprints.Add(new Blueprint { Name = name, Owner = _controller.GameManager.GameState.ActivePlayerId});

            Back();
        }
    }
}