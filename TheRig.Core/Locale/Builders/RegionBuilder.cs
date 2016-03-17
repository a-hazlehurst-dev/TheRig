
using TheRig.Core.Locale.Configurations;

namespace TheRig.Core.Locale.Builders
{
    public class RegionBuilder
    {
        public Region BuildRegion(RegionConfiguration regionConfiguration)
        {
            var region = new Region { Name = "Random" };
            region.RegionConfiguration = regionConfiguration;
            return region;
        }
    }
}
