using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.UI.Controller;
using TheRig.UI.Pages.Interfaces;

namespace TheRig.UI.Pages
{
    public class FindComputersPage : IPage
    {
        public GameController _displayController;

        public FindComputersPage(GameController displayController)
        {
            _displayController = displayController;
        }

        public void Back()
        {
            _displayController.GoToMainMenu();
        }

        public void Draw()
        {
            Console.Clear();
            var computers = GameState.Instance.Player.ComputerPool;
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
                    GameState.Instance.Player.ActiveComputerName = selected.Name;
                }
            } while (go);
            Back();
        }

        public void Title()
        {
            return;
        }
    }
}