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
            var displayController = new DisplayController(gameManager);
        }
    }

 

    

    



    
    

    

   



    

  

   

 

   

    

   

    public class TileGrid
    {
        public int Id { get; set; }
    }

   
   
   
   
    
    
}
