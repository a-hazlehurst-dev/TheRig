using System;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages
{
    public class NewComputerPage : IPage
    {
        private readonly GameController _controller;

        public NewComputerPage(GameController controller)
        {
            _controller = controller;
        }

        public void Draw()
        {
            var valid = false;
            var name = "";
            do
            {
                Console.WriteLine("What do you want to call the Computer.");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid name.");
                }
                else
                {
                    valid = true;
                }

            } while (!valid);


            GameState.Instance.Player.ActiveComputerName = name;
            GameState.Instance.Player.ComputerPool.Add(new Computer { Name = name});
            _controller.GoToMainMenu();
        }
    }
}