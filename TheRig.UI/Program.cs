using TheRig.Core;
using TheRig.Data;
using TheRig.Data.Providers;
using TheRig.Data.Repositories;
using TheRig.UI.Controller;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dp = new DataProvider();
            var unitOfWork = new UnitOfWork(dp);
            var gameManager = new GameManager(unitOfWork);

            var display = new Display(gameManager);
            var motherboard = gameManager.GetMotherboard(1);
            var test = "sdlkg";
            display.DisplayCompatibleItems(motherboard);
        }
    }

 

    

    



    
    

    

   



    

  

   

 

   

    

   

    public class TileGrid
    {
        public int Id { get; set; }
    }

   
   
   
   
    
    
}
