﻿using TheRig.Core;
using TheRig.Core.Locale;
using TheRig.Core.Locale.Builders;
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
            var unitOfWork = new UnitOfWork(dp);
            var displayController = new GameController(unitOfWork, new CityService(new CityBuilder(new RegionBuilder())));
            displayController.Start();

            
        }
    }
}
