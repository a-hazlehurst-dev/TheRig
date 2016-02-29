using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    End();
                }
            }
        }

        public DisplayController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            GamePages= new GamePages(this);
        }

        public void Start()
        {
            do
            {
                Console.Clear();
                GamePages.Pages["MainMenu"].Draw();

            } while (!_endGame);
            
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
            Console.WriteLine("Press 'X' to quit");
            if (Console.ReadKey().Key == ConsoleKey.X)
            {
                _displayController.EndGame= true;
            }
        }
    }

}
