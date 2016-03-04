using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;
using TheRig.UI.Controller;
using TheRig.UI.Pages;

namespace TheRig.UI.Pages
{
    public class FindComputersPage : IPage
    {
        public DisplayController _displayController;

        public FindComputersPage(DisplayController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {
            Console.Clear();
            var computers = _displayController.Player.ComputerPool;
            if (!computers.Any())
            {
                _displayController.GoToMainMenu();
                return;
            }

            Dictionary<int, Computer> selection = new Dictionary<int, Computer>();
            Computer selected = null;
            bool go = true;
            do
            {
                int count = 1;
                selection.Clear();
                foreach (var computer in computers)
                {
                    selection.Add(count, computer);
                    count++;
                }
                
                Console.WriteLine("Please select a computer by typing its Id.");
                foreach (var computer in selection)
                {
                    Console.WriteLine(computer.Key + ": " + computer.Value.Name);
                }

                var x = Console.ReadLine();
                int selectedNumber = 0;
                int.TryParse(x, out selectedNumber);
                if (selectedNumber > 0 && selectedNumber <= count)
                {
                    go = false;
                    selected = selection[selectedNumber];
                    _displayController.ActiveComputerName = selected.Name;
                }
            } while (go);
            _displayController.GoToMainMenu();
        }
    }
}