using TheRig.Core;
using TheRig.Core.Configuration;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale;
using TheRig.Core.Locale.Builders;
using TheRig.Core.Managers;
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
            var preferences = new GamePreferences();
            var gameManager = new GameManager(unitOfWork, preferences);

            var displayController = new GameController(gameManager);
            displayController.Start();

            
        }
    }
}
