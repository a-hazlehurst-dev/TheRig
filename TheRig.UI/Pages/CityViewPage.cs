using System;
using TheRig.Core.Locale;
using TheRig.UI.Controller;
using TheRig.UI.Pages.PageBinding;

namespace TheRig.UI.Pages
{
    public class CityViewPage : BasePage
    {

        private City _city;
        public CityViewPage(GameController gameController, IPageBinding pagebinding) : base(gameController, pagebinding)
        {
            _city = _gameController.GetCity();
        }

        public override void Title()
        {
            base.Title();
            Console.WriteLine("City View");
            Console.WriteLine();
            
        }

        public override void Draw()
        {
            Title();
            Console.WriteLine("City Information");
            Console.WriteLine("City Name:\t"+_city.Name);
            Console.WriteLine("Regions");

            foreach (var region in _gameController.GetCity().Regions)
            {
                Console.WriteLine("\t--------------------------------------------");
                Console.WriteLine("\tName: " + region.Name);
                Console.Write("\tSize:\t" + region.RegionConfiguration.PopulationSize+"\t\t");
                Console.WriteLine("Wealth:\t" + region.RegionConfiguration.Wealth);
                Console.WriteLine();
            }
            MenuOptions();
            MenuSelector(Console.ReadLine());
            base.Draw();
        }

        public override void MenuOptions()
        {
            base.MenuOptions();
        }

        public override void MenuSelector(string key)
        {
            _pageBinding.ExecuteInput(key);
            base.MenuSelector(key);
        }

        public override void Back()
        {
            _gameController.GamePages.ActivePage = _gameController.GamePages.Pages["CityMenu"];
        }

    }
}
