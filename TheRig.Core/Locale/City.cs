using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale.Configurations;

namespace TheRig.Core.Locale
{
    public class City
    {
        public CityConfiguration CityConfiguration { get; set; }
        public string Name { get; set; }
        public List<Region>  Regions { get; private set; }

        public City()
        {
            Regions = new List<Region>();
        }
    }
}
