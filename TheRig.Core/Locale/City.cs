
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using TheRig.Core.Interfaces;
using TheRig.Core.Managers;

namespace TheRig.Core.Locale
{
    public class City
    {
        public CityConfiguration CityConfiguration { get; set; }
        public string Name { get; set; }
        public List<Region>  Regions { get; private set; }

        
        public City()
        {
        
        }


    }

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

    public interface ICityBuilder
    {
        City Build(CityConfiguration cityConfiguration);
    }

    public class CityBuilder : ICityBuilder
    {
        private readonly RegionBuilder _regionBuilder;

        public CityBuilder(RegionBuilder regionBuilder)
        {
            _regionBuilder = regionBuilder;
        }

        public City Build(CityConfiguration cityConfiguration)
        {
            var city = new City();

            for (int x = 0; x < cityConfiguration.Regions; x++)
            {
                var regionConfiguration = new RegionConfiguration();
                DetermineRegionWealth(regionConfiguration, cityConfiguration, 1, city.Regions);
                DetermineRegionPopulation(regionConfiguration, cityConfiguration, 1, city.Regions);
                var region = _regionBuilder.BuildRegion(regionConfiguration);
                city.Regions.Add(region);
            }

            city.CityConfiguration = cityConfiguration;
            return city;
        }

        private void DetermineRegionPopulation(RegionConfiguration regionConfiguration, CityConfiguration cityConfiguration, int randomSeed, List<Region> regions)
        {
            var diceZone = new List<IntRange>();
            int max = 0;
            if (cityConfiguration.PopulationSize == PopulationSize.Tiny)
            {
                var existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Tiny) * 5);

                diceZone.Add(new IntRange { Result = "Tiny", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101, Max = 75 });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176, Max = 225 }); //50
                diceZone.Add(new IntRange { Result = "Large", Min = 226, Max = 250 }); //25
                diceZone.Add(new IntRange { Result = "Huge", Min = 251, Max = 260 }); //10
                max = 260 - existingRegionModifier;
            }
            else if(cityConfiguration.PopulationSize == PopulationSize.Small)
            {
                var existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Small) * 5);

                diceZone.Add(new IntRange { Result = "Small", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Tiny", Min = 101, Max = 175 });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176, Max = 250 }); //75
                diceZone.Add(new IntRange { Result = "Large", Min = 251, Max = 300 }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301, Max = 325 }); //25
                max = 325- existingRegionModifier;
            }

            else if (cityConfiguration.PopulationSize == PopulationSize.Medium)
            {
                var existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Medium) * 5);

                diceZone.Add(new IntRange { Result = "Medium", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101, Max = 175 });//75
                diceZone.Add(new IntRange { Result = "Large", Min = 176, Max = 250 }); //75
                diceZone.Add(new IntRange { Result = "Tiny", Min = 251, Max = 300 }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301, Max = 350 }); //50
                max = 350 - existingRegionModifier;
            }
            else if (cityConfiguration.PopulationSize == PopulationSize.Large)
            {
                var existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Large) * 5);

                diceZone.Add(new IntRange { Result = "Large", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Medium", Min = 101, Max = 175 });//75
                diceZone.Add(new IntRange { Result = "Huge", Min = 176, Max = 250 }); //75
                diceZone.Add(new IntRange { Result = "Small", Min = 251, Max = 300 }); //50
                diceZone.Add(new IntRange { Result = "Tiny", Min = 301, Max = 325 }); //25
                max = 325 - existingRegionModifier;
            }
            else
            {
                var existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Huge) * 5);

                diceZone.Add(new IntRange { Result = "Huge", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Large", Min = 101, Max = 175 });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176, Max = 225 }); //50
                diceZone.Add(new IntRange { Result = "Small", Min = 226, Max = 250 }); //25
                diceZone.Add(new IntRange { Result = "Tiny", Min = 251, Max = 260 }); //10
                max = 260 - existingRegionModifier;
            }

            Random rand = new Random(randomSeed);
            int results = rand.Next(0, max);
            string diceRole = "";
            foreach (var intRange in diceZone)
            {
                if (results > intRange.Max && results <= intRange.Min)
                {
                    diceRole = intRange.Result;
                }
            }

            if (diceRole == "Tiny")
            {
                regionConfiguration.PopulationSize = PopulationSize.Tiny;
            }
            if (diceRole == "Small")
            {
                regionConfiguration.PopulationSize = PopulationSize.Small;
            }
            if (diceRole == "Medium")
            {
                regionConfiguration.PopulationSize = PopulationSize.Medium;
            }
            if (diceRole == "Large")
            {
                regionConfiguration.PopulationSize = PopulationSize.Large;
            }
            if (diceRole == "Huge")
            {
                regionConfiguration.PopulationSize = PopulationSize.Huge;
            }


        }

        private void DetermineRegionWealth(RegionConfiguration regionConfiguration, CityConfiguration cityConfiguration, int randomSeed, List<Region> cityRegions )
        {
            var diceZone = new List<IntRange>();
            int max = 0;
            if (cityConfiguration.Wealth == Wealth.Poverty)
            {
                var existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Poverty)*5);

                diceZone.Add(new IntRange {Result = "Poverty", Min = 0,Max =100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101, Max = 75 });//75
                diceZone.Add(new IntRange { Result = "Average", Min = 176, Max = 225 }); //50
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 226, Max = 250 }); //25
                diceZone.Add(new IntRange { Result = "Rich", Min = 251, Max = 260 }); //10
                max = 260 - existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Poor)
            {
                var existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Poor) * 5);

                diceZone.Add(new IntRange { Result = "Poor", Min = 0, Max =100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poverty", Min = 101, Max =175 }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176, Max = 250 }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 251, Max = 275 }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276, Max = 300 }); //25
                max = 300- existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Average)
            {
                var existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Average) * 5);

                diceZone.Add(new IntRange { Result = "Average", Min = 0, Max = 100- existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101, Max = 175 }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 176, Max = 250 }); // 75
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251, Max = 275 }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276, Max = 300 }); //25
                max = 300- existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Prosperous)
            {
                var existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Prosperous) * 5);
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 0, Max = 100- existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Rich", Min = 101, Max = 175 }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176, Max = 250 }); // 75
                diceZone.Add(new IntRange { Result = "Poor", Min = 251, Max = 275 }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 276, Max = 300 }); //25
                max = 300-existingRegionModifier;
            }
            else
            {
                var existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Prosperous) * 5);
                diceZone.Add(new IntRange { Result = "Rich", Min = 0, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 101, Max = 175 }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176, Max = 225 }); // 50
                diceZone.Add(new IntRange { Result = "Poor", Min = 226, Max = 250 }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251, Max = 260 }); //10
                max = 300- existingRegionModifier;
            }

            Random rand = new Random(randomSeed);
            int results = rand.Next(0, max);
            string diceRole = "";
            foreach (var intRange in diceZone)
            {
                if (results > intRange.Max && results <= intRange.Min)
                {
                    diceRole = intRange.Result;
                }
            }

            if (diceRole == "Povery")
            {
                regionConfiguration.Wealth = Wealth.Poverty;
            }
            if (diceRole == "Poor")
            {
                regionConfiguration.Wealth = Wealth.Poor;
            }
            if (diceRole == "Average")
            {
                regionConfiguration.Wealth = Wealth.Average;
            }
            if (diceRole == "Prosperous")
            {
                regionConfiguration.Wealth = Wealth.Prosperous;
            }
            if (diceRole == "Rich")
            {
                regionConfiguration.Wealth = Wealth.Rich;
            }
        }
    }

    public class IntRange
    {
        public string Result { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }


    public class RegionBuilder
    {
        public Region BuildRegion(RegionConfiguration regionConfiguration)
        {
            var region = new Region {Name = "Random"};
            region.RegionConfiguration = regionConfiguration;
            return region;
        }

        
    }
    

    public class BusinessInformation
    {
        public List<IMeter>  HypeMeters { get; private set; }

        public BusinessInformation()
        {
            HypeMeters = new List<IMeter>();
        }

        public IMeter GetHypeMeter(string name)
        {
            return HypeMeters.SingleOrDefault(x => x.Name.Equals(name));
        }
    }

    public class Region
    {

        public  RegionConfiguration RegionConfiguration { get; set; }

        public string Name { get; set; }

        public Region ()
        {
            
        }
    }

    public class CityConfiguration
    {
        public PopulationSize PopulationSize { get; set; }
        public PopulationDensity PopulationDensity { get; set; }
        public Wealth Wealth { get; set; }

        public int Regions
        {
            get
            {
                var count = 5;
                if (PopulationDensity == PopulationDensity.Low){count -= 1;}
                if (PopulationDensity == PopulationDensity.High){count += 1;}
                return count;
            }
        }


    }

    public class RegionConfiguration
    {
        public PopulationSize PopulationSize { get; set; }
        public Wealth Wealth { get; set; }
        public RegionTypes Type { get; set; }
    }

    public enum RegionTypes
    {
        Residential = 1, 
        Commercial = 2, 
        Industrial = 3
    }

    public enum PopulationDensity
    {
        Low = 1,
        Normal = 2,
        High = 3
    }

    public enum Wealth
    {
        Poverty = 1,
        Poor = 2,
        Average = 3,
        Prosperous= 4,
        Rich= 5,
    }

    public enum PopulationSize
    {
        Tiny = 1,
        Small = 2,
        Medium = 3,
        Large = 4,
        Huge = 5
    }

    

}
