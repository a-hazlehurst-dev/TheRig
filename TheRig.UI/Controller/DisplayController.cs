﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using TheRig.Core.Interfaces;
using TheRig.UI.Pages;

namespace TheRig.UI.Controller
{
    public class DisplayController
    {
        private bool _endGame;
        public IUnitOfWork UnitOfWork { get; private set; }
        public ComputerRepository ComputerRepository { get; set; }
        public GamePages GamePages { get; set; }
        public Player Player { get; set; }

        public string ActiveComputerName { get; set; }
        public bool EndGame
        {
            set
            {
                Console.WriteLine("Are you sure you wish to quit? press 'Y' to quit");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    _endGame = true;
                }
            }
        }

        public DisplayController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ComputerRepository = new ComputerRepository();
            Player = new Player();
            ActiveComputerName = "Not Set";
            GamePages= new GamePages(this);

        }

        public void Start()
        {
            do
            {
                Console.Clear();
                GamePages.ActivePage.Draw();
            }
            while (!_endGame);
            End();
        }

        public void End()
        {
            Console.Clear();
            Credits();
            Console.ReadKey();
        }

        public void Credits()
        {
            GamePages.Pages["Credits"].Draw();
        }

        public void GoToMainMenu()
        {
            GamePages.ActivePage = GamePages.Pages["MainMenu"];
        }
    }


    public class Player
    {
        public List<Computer> ComputerPool { get; set; }

        public Player()
        {
            ComputerPool = new List<Computer>();
        }

        
    public class Player
    {
        public List<Computer> ComputerPool { get; set; }

        public Player()
        {
            ComputerPool = new List<Computer>();
            Pages.Add("CreateComputer", new ComputerCreatorPage(displayController));
            Pages.Add("SelectComputer", new FindComputersPage(displayController));
            Pages.Add("AddComponents", new PickComputerComponents(displayController));
            _displayController = displayController;
    }
        private DisplayController _displayController;
            Pages.Add("CreateComputer", new ComputerCreatorPage(displayController));
            Pages.Add("SelectComputer", new FindComputersPage(displayController));
            Pages.Add("AddComponents", new PickComputerComponents(displayController));
            _displayController = displayController;
            if (!string.IsNullOrEmpty(_displayController.ActiveComputerName))
            {
                Console.WriteLine("\t\t (Selected Computer: " + _displayController.ActiveComputerName + ")");
            }
                var page = (ComputerCreatorPage)_displayController.GamePages.Pages["CreateComputer"];
                _displayController.GamePages.ActivePage = page;
            }
            if (key == ConsoleKey.D)
            {
                var page = (FindComputersPage)_displayController.GamePages.Pages["SelectComputer"];
            
        public List<Computer> GetAll()
        {
            return _computers;
        }

            var computer = _displayController.Player.ComputerPool.SingleOrDefault(x => x.Name == _displayController.ActiveComputerName);
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Computer Blueprint");
            Console.WriteLine("=====================================");
            Console.WriteLine();

            Console.WriteLine("Components:\t " + computer.Motherboard.Components.Count);
            Console.WriteLine();
            Console.WriteLine("A: To add components.");
            Console.WriteLine("Press X to return to menu.");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
        {
            GamePages.ActivePage = GamePages.Pages["MainMenu"];
            }

            
        }
    }

    public class PickComputerComponents : IPage
    {
        private DisplayController _displayController;
        public PickComputerComponents(DisplayController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {
            Console.Write("Main Menu");
            if (!string.IsNullOrEmpty(_displayController.ActiveComputerName))
            {
                Console.WriteLine("\t\t (Selected Computer: " + _displayController.ActiveComputerName + ")");
            }
            var computer =
            Console.WriteLine("A : To Create a new Computer.");
            Console.WriteLine("B : To Display Computer.");
            Console.WriteLine("D : Find and Select computer.");
            if (key == ConsoleKey.A)
            {
                var page = (ComputerCreatorPage)_displayController.GamePages.Pages["CreateComputer"];
                _displayController.GamePages.ActivePage = page;
                if (motherboards.Any())
                {
                    int x = 0;
                    foreach (var motherboard in motherboards)
                    {
                        Console.WriteLine(x + ": " + motherboard.Name);
                        x++;
                    }
                    var input = Console.ReadLine();
                    int num = 0;
                    int.TryParse(input, out num);
                    computer.Motherboard = motherboards.ElementAt(num);
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
            
        }
    }

    public class ComputerCreatorPage : IPage
    {
        private readonly DisplayController _controller;

        public ComputerCreatorPage(DisplayController controller)
        {
            _controller = controller;
        }

        public void Draw()
        {
            return _computers;
        }

        {
            Console.WriteLine("What do you want to call the Computer.");
            var name = Console.ReadLine();
            _controller.ActiveComputerName = name;
            _controller.Player.ComputerPool.Add(new Computer { Name = name});
            _controller.GoToMainMenu();
    }
}

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
            
            Dictionary<int, Computer> selection = new Dictionary<int, Computer>();
            Computer selected = null;
            bool go = true;
            do


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
        }

    }

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

    public class DisplayHelper
    {
        public Item SelectableList(List<Item> listOfItems)
        {
            Console.Write("Please select from the list and type the number next to the item.");
            int count = 0;
            foreach (var item in listOfItems)
            {
                Console.WriteLine(count + ", " + item.Name);
                count++;
            }

            int x = 0;
            string line = "";
            do
            {
                Console.WriteLine("Please select a valid number");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out x));

            return listOfItems.ElementAt(x-1);
        }
    }
}

