using TheRig.Core;
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
            var displayController = new DisplayController(unitOfWork);
            displayController.Start();

            
        }
    }

    public class TileGrid
    {
        public int Id { get; set; }
    }

   
   
   
   
    
    
}
