

using TheRig.Core.Locale.Enums;
using TheRig.Core.Managers;

namespace TheRig.Core.Locale.Configurations
{
    public class CityConfiguration
    {
        public PopulationSizeEnum PopulationSize { get; set; }
        public PopulationDensityEnum PopulationDensity { get; set; }
        public WealthEnum Wealth { get; set; }

        public int Regions
        {
            get
            {
                var count = 5;
                if (PopulationDensity == PopulationDensityEnum.Low) { count -= 1; }
                if (PopulationDensity == PopulationDensityEnum.High) { count += 1; }
                return count;
            }
        }


    }
}
