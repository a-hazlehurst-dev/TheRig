using System;
using System.Linq;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Locale.Enums;
using TheRig.Core.Managers;
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
            RegionalHypeManager  = new HypeManager();
        }

        public string Name { get; set; }
        public RegionConfiguration RegionConfiguration { get; set; }
        public HypeManager RegionalHypeManager { get; set; }
        public CustomerInfo PreviousWeek{ get; set; }
        public CustomerInfo ThisWeek { get; set; }
        public CustomerInfo Forecast { get; set; }

        public void Turn()
        {
        }

    }

}
