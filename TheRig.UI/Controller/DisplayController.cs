using System;
using System.ComponentModel;
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

}

