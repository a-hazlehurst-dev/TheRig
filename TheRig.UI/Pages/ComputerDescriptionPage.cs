using System;
using System.Linq;
using TheRig.Models.Components;
using TheRig.UI.Controller;

namespace TheRig.UI.Pages
{
    public class ComputerDescriptionPage : IPage
    {
        private DisplayController _displayController;
        
        public ComputerDescriptionPage (DisplayController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {
            var computer = _displayController.Player.ComputerPool.SingleOrDefault(x => x.Name == _displayController.ActiveComputerName);
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Computer Blueprint");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            
            Console.WriteLine("Name: \t"+ computer.Name);
            Console.Write("Motherboard:\t");

            Console.WriteLine(computer.Motherboard != null ? computer.Motherboard.Name : "Not set.");


            var cpus = computer.Motherboard.CpuSlots;
            foreach (var cpu in cpus)
            {
                var temp = (Cpu)cpu;
                if (temp.Name == "Not set.")
                {
                    Console.WriteLine("\t\tEmpty Ram slot");
                }
                else
                {
                    Console.WriteLine("\t\t" + temp.Name + "(S:" + temp.Speed + " C:" + temp.Price + ")");
                }
            }

            var rams = computer.Motherboard.RamSlots;
            foreach (var ram in rams)
            {
                var temp = (Ram)ram;
                if (temp.Name == "Not set.")
                {
                    Console.WriteLine("\t\tEmpty Ram slot");
                }
                else
                {
                    Console.WriteLine("\t\t" + temp.Name + "(S:" + temp.Speed + " C:" + temp.Price + ")");
                }
            }

            var graphics = computer.Motherboard.GraphicsSlots;
            foreach (var graphic in graphics)
            {
                var temp = (Graphic)graphic;
                if (temp.Name == "Not set.")
                {
                    Console.WriteLine("\t\tEmpty Graphic slot");
                }
                else
                {
                    Console.WriteLine("\t\t" + temp.Name + "(S:" + temp.Speed + " C:" + temp.Price + ")");
                }
            }

            Console.WriteLine();
            Console.WriteLine("A: To add components.");
            Console.WriteLine("Press X to return to menu.");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                _displayController.GamePages.ActivePage = _displayController.GamePages.Pages["AddComponents"];
            }
            if (key.Key == ConsoleKey.X)
            {
                _displayController.GoToMainMenu();
            }
        }

    }
}