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

        public int Players { get; set; }

        public decimal StartingFunds{get; set;}
        public DifficultyEnum Difficulty { get; set; }
    }


    public enum DifficultyEnum
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
}
