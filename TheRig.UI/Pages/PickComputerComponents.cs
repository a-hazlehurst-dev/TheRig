using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core;
using TheRig.Models.Components;
using TheRig.UI.Controller;
using TheRig.UI.Helper;
using TheRig.UI.Pages;

namespace TheRig.UI.Pages
{
    public class PickComputerComponents : IPage
    {
        private GameController _displayController;
        public PickComputerComponents(GameController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {
            DisplayHelper helper = new DisplayHelper();
            UiTitleHelper.AddComponentsTitle(_displayController);

            var computer = GameState.Instance.Player.GetActiveComputer();
            if (computer.Motherboard.Name == "NotSet")
            {
                Console.WriteLine("You must first select a motherboard.");
                var motherboards = _displayController.UnitOfWork.MotherboardRepository.Find();
                if (motherboards.Any())
                {
                    var moboItem = helper.SelectableList(motherboards.Cast<Item>().ToList());
                    computer.Motherboard = (Motherboard)moboItem;

                   
                    int t = 0;
                    for (int k = 0; k < GameState.Instance.Player.ComputerPool.Count; k++)
                    {
                        var comp = GameState.Instance.Player.ComputerPool[k];
                        if (comp.Name.Equals(computer.Name))
                        {
                            t = k;
                            break;
                        }
                    }
                    GameState.Instance.Player.ComputerPool.RemoveAt(t);
                    GameState.Instance.Player.ComputerPool.Add(computer);

                    Console.WriteLine("Selected: " +computer.Motherboard.Name);
                }
            }
            if (!computer.Motherboard.Name.Equals("Not Set"))
            {
                Console.WriteLine("Please select your components.");
                
            }
            Console.ReadKey();
            _displayController.GamePages.ActivePage = _displayController.GamePages.Pages["ComputerDisplay"];
        }

        private List<Item> AddItemToSlot(List<Item> compatibleItems,  List<Item> slots  )
        {
            DisplayHelper helper = new DisplayHelper();

            var itemToAdd = helper.SelectableList(compatibleItems.ToList());
            int x = 0;
            foreach (var slot in slots)
            {
                if (slot.Name.Equals("Not set."))
                {
                    slots.RemoveAt(x);
                    break;
                }
                x++;
            }

            slots.Insert(x,itemToAdd);
            return slots;
        }
    }
}