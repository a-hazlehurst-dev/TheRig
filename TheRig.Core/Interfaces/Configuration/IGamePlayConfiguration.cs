using TheRig.Core.Locale.Configurations;

namespace TheRig.Core.Interfaces.Configuration
{
    public interface IGameplayConfiguration
    {
        CityConfiguration CityConfiguration { get; set; }
    }
}
