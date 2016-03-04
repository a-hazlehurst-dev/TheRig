using System;
using TheRig.Models.Components;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages
{
    public class NewComputerPage : IPage
    {
        private readonly DisplayController _controller;

        public NewComputerPage(DisplayController controller)
        {
            _controller = controller;
        }

        public void Draw()
        {
            Console.WriteLine("What do you want to call the Computer.");
            var name = Console.ReadLine();
            _controller.ActiveComputerName = name;
            _controller.Player.ComputerPool.Add(new Computer { Name = name});
            _controller.GoToMainMenu();
        }
    }
}