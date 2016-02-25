using System;
using System.Collections.Generic;
using TheRig.Core;
using TheRig.Core.Builders;
using TheRig.Models.Components;

namespace TheRig.UI.Controller
{
    public class DisplayController
    {
        private GameManager _gameManager;
        private Item _selectedItem;

        public DisplayController(GameManager gameManager)
        {
            _gameManager = gameManager;
            bool quit = false;
            do
            {
                Console.Clear();
                Title();
                quit = MainMenu();
            } while (quit);

        }

        public void Title()
        {
            Console.WriteLine("Welcome to the Rig, Written by Adam Hazlehurst");
        }

        public void DisplayAllComponents()
        {
            ComponentListModel componentListModel = new ComponentListModel(_gameManager);
            string display="";
            Console.WriteLine("This is a list of all available components. Please type a number to select on");
            foreach(var item in componentListModel.Items)
            {
                display += item.Key + ", " + item.Value.Name + Environment.NewLine;
            }
            Console.Write(display);

            string selectedValue = Console.ReadLine();
            int val = -1;
            if (!int.TryParse(selectedValue, out val))
            {
                _selectedItem = null;
                return;
            }
                
            _selectedItem = componentListModel.Items[val];

        }

        public bool MainMenu()
        {
            Console.WriteLine("Main Menu, please select from the list.");
            if (_selectedItem != null)
            {
                Console.WriteLine("Current Selected item is: " + _selectedItem.Name);
                Console.WriteLine("Press 'v' for more information ");

            }
            Console.WriteLine("A: Displays All items.");
            string selected = Console.ReadLine();
            if (selected.Equals("A"))
            {
                DisplayAllComponents();
            }
            if (selected.Equals("Q"))
            {
                return false;
            }
            if (selected.Equals("V"))
            {
                DisplayItem();
            }
            return true;

        }

        public  void DisplayItem()
        {
            if (_selectedItem != null)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Name: " + _selectedItem.Name + ", £" + _selectedItem.Price);
                Console.ReadKey();
            }
        }

    }

    

    public class ComponentListModel
    {
        private readonly GameManager _gameManager;
        public Dictionary<int, Item> Items { get; set; }
        
        public ComponentListModel(GameManager gameManager)
        {
            _gameManager = gameManager;
            Items = new Dictionary<int, Item>();
            Build();
        }

        private void Build()
        {
            var items = new List<Item>();
            items.AddRange(_gameManager.UnitOfWork.CpuRepository.Find());
            items.AddRange(_gameManager.UnitOfWork.GraphicsRepository.Find());
            items.AddRange(_gameManager.UnitOfWork.MotherboardRepository.Find());
            items.AddRange(_gameManager.UnitOfWork.RamRepository.Find());
            items.AddRange(_gameManager.UnitOfWork.SoundRepository.Find());
            int count = 1;
            foreach(var item  in items)
            {
                Items.Add(count, item);
                count++;
            }
        }


    }
}
