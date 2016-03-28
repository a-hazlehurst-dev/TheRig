using System;
using TheRig.Core.Interfaces;

namespace TheRig.Core.Configuration
{
    public class GameConfiguration : IGameConfiguration
    {
        public GameplayConfiguration GameplayConfiguration { get; set; }
        public GameSetupConfiguration GameSetupConfiguration { get; set; }

        public GameConfiguration(GameplayConfiguration gameplayConfiguration, GameSetupConfiguration gameSetupConfiguration)
        {
            GameplayConfiguration = gameplayConfiguration;
            GameSetupConfiguration = gameSetupConfiguration;
        }
        
    }
}
