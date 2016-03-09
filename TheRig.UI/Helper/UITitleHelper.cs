using System;
using TheRig.UI.Controller;

namespace TheRig.UI.Helper
{
    public static class UiTitleHelper
    {

        public static void TitleBar(GameController gameController)
        {
            Console.Clear();
            Console.Write(gameController.GameDate.ToString("D"));
            Console.WriteLine("");
        }
        public static void DrawMainTitle(GameController gameController)
        {
            
            Console.WriteLine(" The Rig");
            Console.WriteLine("=============================================");
            TitleBar(gameController);
            Console.WriteLine();
        }

        public static void DrawBluePrintTitle(GameController gameController)
        {
            
            Console.WriteLine(" Computer Blueprint");
            Console.WriteLine("=====================================");
            TitleBar(gameController);
            Console.WriteLine();
        }

        public static void AddComponentsTitle(GameController gameController)
        {
            
            Console.WriteLine(" Add Components");
            Console.WriteLine("=====================================");
            TitleBar(gameController);
            Console.WriteLine("");
        }

        public static void DrawAdvertismentTitle(GameController gameController)
        {
            
            Console.WriteLine(" Advertising");
            Console.WriteLine("=====================================");
            TitleBar(gameController);
            Console.WriteLine("");
        }
        
        public static void DrawAdvertismentTitle(GameController gameController)
        {
            TitleBar(gameController);
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" Advertising");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
        }
        
    }
}
