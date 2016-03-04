using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;
using TheRig.UI.Controller;
using TheRig.UI.Helper;
using TheRig.UI.Pages;

namespace TheRig.UI.Pages
{
    public class PickComputerComponents : IPage
    {
        private DisplayController _displayController;
        public PickComputerComponents(DisplayController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {
            DisplayHelper helper = new DisplayHelper();
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Computer Blueprint - Add Components");
            Console.WriteLine("=====================================");
            Console.WriteLine("");
            var computer =
                _displayController.Player.ComputerPool.Single(x => x.Name == _displayController.ActiveComputerName);
            if (computer.Motherboard.Name == "NotSet")
            {
                Console.WriteLine("You must first select a motherboard.");
                var motherboards = _displayController.UnitOfWork.MotherboardRepository.Find();
                if (motherboards.Any())
                {
                    var moboItem = helper.SelectableList(motherboards.Cast<Item>().ToList());
                    computer.Motherboard = (Motherboard)moboItem;

                   
                    int t = 0;
                    for (int k = 0; k < _displayController.Player.ComputerPool.Count; k++)
                    {
                        var comp = _displayController.Player.ComputerPool[k];
                        if (comp.Name.Equals(computer.Name))
                        {
                            t = k;
                            break;
                        }
                    }
                    _displayController.Player.ComputerPool.RemoveAt(t);
                    _displayController.Player.ComputerPool.Add(computer);

                    Console.WriteLine("Selected: " +computer.Motherboard.Name);
                }
            }
            if (!computer.Motherboard.Name.Equals("Not Set"))
            {
                Console.WriteLine("Please select your components.");
                var cpus= _displayController.UnitOfWork.CpuRepository.GetCompatible(computer.Motherboard);
                var rams = _displayController.UnitOfWork.RamRepository.GetCompatible(computer.Motherboard);
                var graphics = _displayController.UnitOfWork.GraphicsRepository.GetCompatible(computer.Motherboard);
                
                computer.Motherboard.CpuSlots = AddItemToSlot(cpus.Cast<Item>().ToList(), computer.Motherboard.CpuSlots.Cast<Item>().ToList()).Cast<Cpu>().ToList();
                computer.Motherboard.RamSlots = AddItemToSlot(rams.Cast<Item>().ToList(), computer.Motherboard.RamSlots.Cast<Item>().ToList()).Cast<Ram>().ToList();
                computer.Motherboard.GraphicsSlots = AddItemToSlot(graphics.Cast<Item>().ToList(),computer.Motherboard.GraphicsSlots.Cast<Item>().ToList()).Cast<Graphic>().ToList();
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