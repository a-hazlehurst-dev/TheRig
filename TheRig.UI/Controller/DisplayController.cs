using System;
using System.Collections.Generic;
using TheRig.Core;
using TheRig.Core.Builders;
using TheRig.Models.Components;

namespace TheRig.UI.Controller
{
    public class Display
    {
        private GameManager _gameManager;
        public Display(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Quit()
        {

        }

        public void DisplayCompatibleItems(Motherboard motherboard)
        {
            var motherboardBuilder = new MotherboardBuilder(_gameManager.UnitOfWork);
            var compatible = motherboardBuilder.GetCompatibleItems(motherboard);


            Console.Clear();
            var list = 1;
            foreach (var item in compatible)
            {
                Console.WriteLine(list + ". " + item.Name);
                list++;
            }
            Console.WriteLine("Enter the number of the item you wish to install, 0 to view the pc, or x to exit: ");
            var key = Console.ReadLine();
            if (key.Equals("x") || key.Equals("X"))
                return;
            else
            {
                ProcessInput(key, motherboard, list, compatible);
            }
        }

        public void ProcessInput(string key, Motherboard motherboard, int list, List<Item> compatible)
        {
            int val = 0;
            int.TryParse(key, out val);
            if (val == 0)
            {
                DisplayInstalledItems(motherboard);
                DisplayCompatibleItems(motherboard);
            }
            else if (val > 0 && val < list)
            {
                motherboard.Components.Add(compatible[val - 1]);
                DisplayCompatibleItems(motherboard);
            }
        }

        public void DisplayInstalledItems(Motherboard motherboard)
        {
            Console.Clear();
            Console.WriteLine("Installed Items");
            int speed = 0;
            decimal cost = 0.0m;
            string names = "";
            foreach (var component in motherboard.Components)
            {

                if (component.Type == "Ram")
                {
                    var obj = ((Ram)component);
                    speed += obj.Speed;
                    cost += obj.Price;
                    names += Environment.NewLine + obj.Name;
                }
                if (component.Type == "Cpu")
                {
                    var obj = ((Cpu)component);
                    speed += obj.Speed;
                    cost += obj.Price;
                    names += Environment.NewLine + obj.Name;
                }
                if (component.Type == "Graphic")
                {
                    var obj = ((Graphic)component);
                    speed += obj.Speed;
                    cost += obj.Price;
                    names += Environment.NewLine + obj.Name;
                }
                if (component.Type == "Sound")
                {
                    var obj = ((Sound)component);
                    cost += obj.Price;
                    names += Environment.NewLine + obj.Name;
                }

            }
            Console.WriteLine("Speed: " + speed + ". Cost: " + cost);
            Console.WriteLine(names);
            Console.ReadKey();
        }

    }
}
