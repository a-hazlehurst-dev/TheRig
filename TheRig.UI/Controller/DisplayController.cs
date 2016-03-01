using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TheRig.Core;
using TheRig.Core.Builders;
using TheRig.Core.Interfaces;
using TheRig.Models.Components;

namespace TheRig.UI.Controller
{
    public class DisplayController
    {
        private bool _endGame;
        public IUnitOfWork UnitOfWork { get; private set; }
        public ComputerRepository ComputerRepository { get; set; }
        public GamePages GamePages { get; set; }
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

    }


    public class GamePages
    {
        public Dictionary<string, IPage> Pages { get; set; }
        public IPage ActivePage { get; set; }

        public GamePages(DisplayController displayController)
        {
            Pages = new Dictionary<string, IPage>();
            Pages.Add("MainMenu", new MainMenuPage(displayController));
            Pages.Add("Credits", new CreditsPage());
            Pages.Add("ComputerDisplay", new ComputerDisplayPage(displayController));
            ActivePage = Pages["MainMenu"];
        }


    }

    public interface IPage
    {
        void Draw();
    }

    public class CreditsPage : IPage
    {
        public void Draw()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("===Credits==============================");
            Console.WriteLine("\tDesign :\t Adam Hazlehurst");
            Console.WriteLine("\tProgrammer :\t Adam Hazlehurst");
            Console.WriteLine("\tGraphics :\t Adam Hazlehurst");
            Console.WriteLine("\tSound :\t\t Adam Hazlehurst");
        }
    }

    public class MainMenuPage : IPage
    {
        private readonly DisplayController _displayController;

        public MainMenuPage(DisplayController displayController)
        {
            _displayController = displayController;
        }

        public void Draw()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------------------------");
            Console.WriteLine("C : To Create a new Computer.");
            Console.WriteLine("D : To Display Computer.");
            Console.WriteLine("A : To Add components To the Computer.");
            Console.WriteLine();
            Console.WriteLine("Press 'X' to quit");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.C)
            {
                
            }
            if (key == ConsoleKey.D)
            {
                var page = (ComputerDisplayPage)_displayController.GamePages.Pages["ComputerDisplay"];
                page.Computer =_displayController.ComputerRepository.GetComputer("New PC");
                _displayController.GamePages.ActivePage = page;
            }
            
            if (key == ConsoleKey.X)
            {
                _displayController.EndGame= true;
            }
        }
    }

    public class ComputerRepository
    {
        private List<Computer> _computers;

        public ComputerRepository()
        {
            _computers = new List<Computer>();
        }
        public Computer GetComputer(string name)
        {
            var computer = _computers.SingleOrDefault(x => x.Name == name);
            if (computer==null)
            {
                computer = new Computer();
                AddComputer(computer);
            }
            return computer;
        }

        public void AddComputer(Computer computer)
        {
            _computers.Add(computer);
        }
    }

    public class ComputerDisplayPage : IPage
    {
        private DisplayController _displayController;
        public Computer Computer { get; set; }
        public ComputerDisplayPage (DisplayController displayController)
        {
            _displayController = displayController;
        }
        public void Draw()
        {

            Console.WriteLine("Computer Blueprint---");
            Console.WriteLine(Computer.Name);
            Console.Write("Motherboard: ");
            if (Computer.Motherboard != null)
            {
                Console.WriteLine(Computer.Motherboard.Name);
            }
            else
            {
                Console.WriteLine("Not set");
            }
            Console.Write("Components: " + Computer.Motherboard.Components.Count);
            Console.ReadKey();
            _displayController.GamePages.ActivePage = _displayController.GamePages.Pages["MainMenu"];
        }
    }

}
