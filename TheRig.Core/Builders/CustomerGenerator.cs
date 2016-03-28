using System;
using System.Linq;
using TheRig.Core.Locale;
using TheRig.Core.Locale.Enums;
using TheRig.Models;

namespace TheRig.Core.Builders
{
    public class CustomerGenerator
    {

        public int GetCustomers(Region region)
        {
            MoveCustomerInfoUpOne(region.ThisWeek, region.PreviousWeek);
            MoveCustomerInfoUpOne(region.Forecast, region.ThisWeek);

            region.Forecast.BaseCustomers = GetRandomCustomersCount(region);
            region.Forecast.WealthModifier = GetWealthModifier(region);
            region.Forecast.DistrictTypeModifier = CreateDistrictModifier(region);

            Apply(region.Forecast);

            ApplyAwarenessFilter(region);

            return region.PreviousWeek.CustomersCreated;
        }

        private void ApplyAwarenessFilter(Region region)
        {
            //var meter = region.RegionalHypeManager.General.SingleOrDefault(x => x.Name == "Awareness");
            //var step = meter.Max / 10;
            //if (meter.Current >= step * 0 && meter.Current < step * 1)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(0, 12, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 1 && meter.Current < step * 2)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(8, 22, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 2 && meter.Current < step * 3)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(18, 32, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 3 && meter.Current < step * 4)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(28, 42, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 4 && meter.Current < step * 5)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(38, 52, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 5 && meter.Current < step * 6)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(48, 62, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 6 && meter.Current < step * 7)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(58, 72, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 7 && meter.Current < step * 8)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(68, 82, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 8 && meter.Current < step * 9)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(78, 92, region.Forecast.CustomersCreated);
            //}
            //else if (meter.Current >= step * 9 && meter.Current < step * 10)
            //{
            //    region.Forecast.AwareCustomers = CalculateAwareness(88, 100, region.Forecast.CustomersCreated);
            //}
        }

        public int CalculateAwareness(int min, int max, int customers)
        {
            int rand = RandomNumber.Randomness.getNextInt(min, max);
            decimal a = (rand / 100M);
            return (int)Math.Round(customers * a);
        }

        private void MoveCustomerInfoUpOne(CustomerInfo source, CustomerInfo destination)
        {
            destination.BaseCustomers = source.BaseCustomers;
            destination.CustomersCreated = source.CustomersCreated;
            destination.DistrictTypeModifier = source.DistrictTypeModifier;
            destination.WealthModifier = source.WealthModifier;
            destination.AwareCustomers = source.AwareCustomers;
        }
        private int GetWealthModifier(Region region)
        {
            var rand = 0;
            ApplyWealthMod(region.RegionConfiguration.Wealth, WealthEnum.Poverty, -8, 5, ref rand);
            ApplyWealthMod(region.RegionConfiguration.Wealth, WealthEnum.Poor, -5, 5, ref rand);
            ApplyWealthMod(region.RegionConfiguration.Wealth, WealthEnum.Average, -5, 10, ref rand);
            ApplyWealthMod(region.RegionConfiguration.Wealth, WealthEnum.Prosperous, -5, 12, ref rand);
            ApplyWealthMod(region.RegionConfiguration.Wealth, WealthEnum.Rich, -5, 5, ref rand);
            return rand;
        }

        private void ApplyWealthMod(WealthEnum source, WealthEnum expected, int low, int high, ref int val)
        {
            if (source == expected)
            {
                val = RandomNumber.Randomness.getNextInt(low, high);
            }
        }
        private int GetRandomCustomersCount(Region region)
        {
            var rand = 0;
            if (region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Tiny)
            {
                rand = RandomNumber.Randomness.getNextInt(0, 200);
            }
            if (region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Small)
            {
                rand = RandomNumber.Randomness.getNextInt(0, 400);
            }
            if (region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Medium)
            {
                rand = RandomNumber.Randomness.getNextInt(0, 600);
            }
            if (region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Large)
            {
                rand = RandomNumber.Randomness.getNextInt(0, 800);
            }
            if (region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Huge)
            {
                rand = RandomNumber.Randomness.getNextInt(0, 1000);
            }

            return rand;
        }
        private int CreateDistrictModifier(Region region)
        {
            var rand = 0;
            if (region.RegionConfiguration.Type == RegionTypes.Residential)
            {
                rand = RandomNumber.Randomness.getNextInt(-5, 5);
            }
            if (region.RegionConfiguration.Type == RegionTypes.Commercial)
            {
                rand = RandomNumber.Randomness.getNextInt(-8, 10);
            }
            if (region.RegionConfiguration.Type == RegionTypes.Industrial)
            {
                rand = RandomNumber.Randomness.getNextInt(-10, 10);
            }
            return rand;
        }
        private void Apply(CustomerInfo info)
        {
            info.CustomersCreated = info.BaseCustomers;

            decimal t = Convert.ToDecimal(info.WealthModifier) / 100;
            decimal x = info.BaseCustomers * t;
            info.CustomersCreated += (int)Math.Round(x);


            decimal w = Convert.ToDecimal(info.DistrictTypeModifier) / 100;
            decimal k = info.BaseCustomers * w;
            info.CustomersCreated += (int)Math.Round(k);

        }
    }
}
