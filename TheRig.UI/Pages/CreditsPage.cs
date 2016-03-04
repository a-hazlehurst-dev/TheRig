using System;
using TheRig.UI.Pages;

namespace TheRig.UI.Pages
{
    public class CreditsPage : IPage
    {
        public void Draw()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("===Credits==============================");
            Console.WriteLine("\tDesign :\t Adam Hazlehurst");
            Console.WriteLine("\tProgrammer :\t Adam Hazlehurst");
            Console.WriteLine("\tGraphics :\t Adam Hazlehurst");
            Console.WriteLine("\tSound :\t\t Adam Hazlehurst");
        }
    }
}