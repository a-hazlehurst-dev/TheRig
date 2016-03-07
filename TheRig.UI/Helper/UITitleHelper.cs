using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRig.UI.Helper
{
    public static class UITitleHelper
    {

        public static void DrawMainTitle()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine(" The Rig");
            Console.WriteLine("=============================================");
            Console.WriteLine();
        }

        public static void DrawBluePrintTitle()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Computer Blueprint");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public static void AddComponentsTitle()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" Add Components");
            Console.WriteLine("=====================================");
            Console.WriteLine("");
        }

    }
}
