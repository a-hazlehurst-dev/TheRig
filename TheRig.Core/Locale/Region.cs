using TheRig.Core.Locale.Configurations;
using TheRig.Models;

namespace TheRig.Core.Locale
{
    public class Region
    {
        public Region()
        {
            PreviousWeek = new CustomerInfo();
            ThisWeek = new CustomerInfo();
            Forecast = new CustomerInfo();
        }

        public string Name { get; set; }
        public RegionConfiguration RegionConfiguration { get; set; }
        public CustomerInfo PreviousWeek{ get; set; }
        public CustomerInfo ThisWeek { get; set; }
        public CustomerInfo Forecast { get; set; }

        public void Turn()
        {
        }

    }

}
