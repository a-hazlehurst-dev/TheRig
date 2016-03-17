using TheRig.Core.Locale;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Locale.Interfaces;

namespace TheRig.Core.Services
{
    public class CityService
    {
        private readonly ICityBuilder _cityBuilder;
        public City City { get; private set; }

        public CityConfiguration CityConfiguration { get; private set; }

        public CityService(ICityBuilder cityBuilder)
        {
            _cityBuilder = cityBuilder;
        }

        public void BuildNewCity(CityConfiguration cityConfiguration)
        {
            CityConfiguration = cityConfiguration;
            City = _cityBuilder.Build(CityConfiguration);
        }
    }

}
