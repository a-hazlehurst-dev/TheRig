using System;
using TheRig.UI.Pages.Interfaces;

namespace TheRig.UI.Pages
{
    public class CreditsPage : IPage
    {
        public void Back()
        {
            return;
        }

        public void Draw()
        {
            Title();
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\tDesign :\t Adam Hazlehurst");
            Console.WriteLine("\tProgrammer :\t Adam Hazlehurst");
            Console.WriteLine("\tGraphics :\t Adam Hazlehurst");
            Console.WriteLine("\tSound :\t\t Adam Hazlehurst");
        }

        public void Title()
        {
            Console.WriteLine("The Rig");
            Console.WriteLine("================================");
        }
    }
}