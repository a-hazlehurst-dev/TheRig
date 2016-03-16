using System;
using TheRig.Core;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale;
using TheRig.UI.Pages;

namespace TheRig.UI.Controller
{
    public class GameController
    {
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
        public IUnitOfWork UnitOfWork { get; private set; }
        public GamePages GamePages { get; set; }
        public Player Player { get; set; } 
        public DateTime GameDate { get; set; }
        private readonly  CityService _cityService;

        public GameController(IUnitOfWork unitOfWork, CityService cityService)
        {
            GameDate = new DateTime(1990, 1,6);
            UnitOfWork = unitOfWork;
            _cityService = cityService;
            _cityService.BuildNewCity(new CityConfiguration { Wealth = Wealth.Average, PopulationSize = PopulationSize.Medium });
            Player = new Player(GameDate);
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

        public City GetCity()
        {
            return _cityService.City;
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
            GameDate = GameDate.AddDays(7);
            Player.Turn(GameDate);
        }
    }
}

