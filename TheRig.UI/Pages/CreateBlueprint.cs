using System;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.UI.Controller;

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
                if (string.IsNullOrWhiteSpace(name)|| _controller.Player.BlueprintManager.GetBlueprintByName(name) !=null)
                {
                    Console.WriteLine("Invalid name.");
                }
                else
                {
                    valid = true;
                }

            } while (!valid);

            _controller.Player.BlueprintManager.Blueprints.Add(new Blueprint { Name = name});

            GameState.Instance.Player.ActiveComputerName = name;
            GameState.Instance.Player.ComputerPool.Add(new Computer { Name = name});

            Back();
        }
    }
}