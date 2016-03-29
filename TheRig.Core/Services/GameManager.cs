using System;
using TheRig.Core.Interfaces;

namespace TheRig.Core.Services
{
    public class GameManager: IGameManager
    {
        public IGameData GameData { get; }
        public IGameConfiguration GameConfiguration { get; }
        public IGameServices GameServices { get; }

        public GameManager(IGameData gameData, IGameServices gameServices, IGameConfiguration gameConfiguration)
        {
            GameData = gameData;
            GameServices = gameServices;
            GameConfiguration = gameConfiguration;
        }
        public void Start()
        {
            GameServices.Build(GameConfiguration, GameData);   
        }

        public void End()
        {
            
        }

        public void Turn()
        {
            
        }
    }
}
