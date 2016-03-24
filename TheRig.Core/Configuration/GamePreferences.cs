using System.Threading;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Locale.Enums;

namespace TheRig.Core.Configuration
{
    public class GamePreferences
    {
        public GamePreferences()
        {
            SoundConfiguration = new SoundConfiguration();
            GameplayConfiguration = new GameplayConfiguration();
            GraphicsConfiguration = new GraphicsConfiguration();
            DataConfiguration = new DataConfiguration();
            InstanceConfiguration = new InstanceConfiguration();
        }

        public SoundConfiguration SoundConfiguration { get; set; }
        public GraphicsConfiguration GraphicsConfiguration { get; set; }
        public GameplayConfiguration GameplayConfiguration { get; set; }
        public DataConfiguration DataConfiguration { get; set; }
        public InstanceConfiguration InstanceConfiguration { get; set; }
    }

    public class InstanceConfiguration
    {

        public InstanceConfiguration()
        {
            CityConfiguration = new CityConfiguration
            {
                PopulationDensity = PopulationDensityEnum.Normal,
                PopulationSize = PopulationSizeEnum.Medium,
                Wealth = WealthEnum.Average
            };
        }
        public CityConfiguration CityConfiguration { get; set; }
        public int PlayerCount { get; set; }

    }
}
