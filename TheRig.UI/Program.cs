using TheRig.Core.Configuration;
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
            var gameData = new UnitOfWork(dp);
            var preferences = new GamePreferences();
            
            var gameManager = new GameManager(gameData, preferences);

            var displayController = new GameController(gameManager);
            displayController.Start();

            
        }
    }
}
