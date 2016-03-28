using TheRig.Core.Locale.Configurations;

namespace TheRig.Core.Configuration
{
    public class GameplayConfiguration
    {
        public GameplayConfiguration(CityConfiguration cityConfiguration)
        {
            CityConfiguration = cityConfiguration;
        }
        public CityConfiguration CityConfiguration { get; set; }
    }
}
