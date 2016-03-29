﻿using TheRig.Core.Configuration;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Services;
using TheRig.Data;
using TheRig.Data.Providers;
using TheRig.UI.Controller;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dp = new DataProvider();
            var gameData = new GameData(dp);

            var cityConfiguration = new CityConfiguration(TheRig.Core.Locale.Enums.PopulationDensityEnum.Normal, TheRig.Core.Locale.Enums.PopulationSizeEnum.Medium, TheRig.Core.Locale.Enums.WealthEnum.Average);

            var gameSetup = new GameSetupConfiguration();
            var gameplaySetup = new GameplayConfiguration(cityConfiguration);
            gameplaySetup.Players = 1;
            gameplaySetup.StartingFunds = 2000M;
            var gameConfiguration = new GameConfiguration(gameplaySetup, gameSetup);

            var gameServices = new GameServices();

            var gameManager = new GameManager(gameData, gameServices, gameConfiguration);

            var displayController = new GameController(gameManager);
            displayController.Start();

            
        }
    }
}
