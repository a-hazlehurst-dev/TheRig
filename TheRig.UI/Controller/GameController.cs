using System;
using TheRig.Core.Interfaces;
using TheRig.UI.Pages;

namespace TheRig.UI.Controller
{
    public class GameController
    {
        public  IGameManager GameManager { get; private set; }
        private bool _endGame;
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
        
        public GamePages GamePages { get; set; }

        public GameController(IGameManager gameManager)
        {
            GameManager = gameManager;
            GamePages= new GamePages(this);

        }

        public void Start()
        {
            GameManager.Start();
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
            GamePages.Pages["Credits"].Draw();
            Console.ReadKey();
        }

        public void GoToMainMenu()
        {
            GamePages.ActivePage = GamePages.Pages["MainMenu"];
        }

        public void Turn()
        {
            GameManager.Turn();
        }
    }
}

