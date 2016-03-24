using System;
using TheRig.Core.Configuration;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale.Builders;
using TheRig.Core.Services;

namespace TheRig.Core.Managers
{
    public class GameManager : IGameManager
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly GamePreferences _gamePreferences;
        private CityService _cityService;

        public GameManager(IUnitOfWork unitofwork, GamePreferences gamePreferences)
        {
            _unitofwork = unitofwork;
            _gamePreferences = gamePreferences;
            Initialise();
        }

        public GamePreferences GameConfiguration { get; set; }
        public IGameState GameState { get; set; }
        public IUnitOfWork UnitOfWork { get { return _unitofwork; }  }
        public CityService CityService { get { return _cityService;}  }

        public void Initialise()
        {
            _cityService = new CityService(new CityBuilder(new RegionBuilder()));
            GameState = new GameState();

        }

        public void Start()
        {
            _cityService.BuildNewCity(_gamePreferences.InstanceConfiguration.CityConfiguration);

            for (int i = 0; i < _gamePreferences.InstanceConfiguration.PlayerCount; i++)
            {
                var player = new Player(i);
                GameState.Players.Add(player);
            }
        }

        public void Turn()
        {
        }
        public void End()
        {
            
        }

    }
}
