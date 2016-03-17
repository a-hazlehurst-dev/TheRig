using TheRig.Core.Locale.Configurations;

namespace TheRig.Core.Locale.Interfaces
{
    public interface ICityBuilder
    {
        City Build(CityConfiguration cityConfiguration);
    }
}
