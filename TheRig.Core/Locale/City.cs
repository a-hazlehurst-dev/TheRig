
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TheRig.Core.Interfaces;

namespace TheRig.Core.Locale
{
    public class City
    {
        public CityConfiguration CityConfiguration { get; set; }
        public string Name { get; set; }
        public List<Region>  Regions { get; private set; }

        
        public City()
        {
            Regions = new List<Region>();
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
                DetermineRegionWealth(regionConfiguration, cityConfiguration, 0, city.Regions);
                Thread.Sleep(12);
                DetermineRegionPopulation(regionConfiguration, cityConfiguration, 0, city.Regions);
                Thread.Sleep(11);
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
            var existingRegionModifier = 0;
            if (cityConfiguration.PopulationSize == PopulationSize.Tiny)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 -(regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Tiny)*5);
                }
                diceZone.Add(new IntRange { Result = "Tiny", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Large", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); //25
                diceZone.Add(new IntRange { Result = "Huge", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 260 - existingRegionModifier;
            }
            else if(cityConfiguration.PopulationSize == PopulationSize.Small)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 -(regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Small)*5);
                }
                diceZone.Add(new IntRange { Result = "Small", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Tiny", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); //75
                diceZone.Add(new IntRange { Result = "Large", Min = 251 - existingRegionModifier, Max = 300 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301 - existingRegionModifier, Max = 325 - existingRegionModifier }); //25
                max = 325- existingRegionModifier;
            }

            else if (cityConfiguration.PopulationSize == PopulationSize.Medium)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 -(regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Medium)*5);
                }

                diceZone.Add(new IntRange { Result = "Medium", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Large", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); //75
                diceZone.Add(new IntRange { Result = "Tiny", Min = 251 - existingRegionModifier, Max = 300 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301 - existingRegionModifier, Max = 350 - existingRegionModifier }); //50
                max = 350 - existingRegionModifier;
            }
            else if (cityConfiguration.PopulationSize == PopulationSize.Large)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 -(regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Large)*5);
                }

                diceZone.Add(new IntRange { Result = "Large", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Medium", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Huge", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); //75
                diceZone.Add(new IntRange { Result = "Small", Min = 251 - existingRegionModifier, Max = 300 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Tiny", Min = 301 - existingRegionModifier, Max = 325 - existingRegionModifier }); //25
                max = 325 - existingRegionModifier;
            }
            else
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 -(regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSize.Huge)*5);
                }

                diceZone.Add(new IntRange { Result = "Huge", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Large", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Small", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); //25
                diceZone.Add(new IntRange { Result = "Tiny", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 260 - existingRegionModifier;
            }

            Random rand = new Random();
            int results = rand.Next(0, max);
            string diceRole = "";
            foreach (var intRange in diceZone)
            {
                if (results <= intRange.Max && results > intRange.Min)
                {
                    diceRole = intRange.Result;
                    break;
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
            var existingRegionModifier = 0;
            if (cityConfiguration.Wealth == Wealth.Poverty)
            {
                
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 -(cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Poverty)*5);
                }
                diceZone.Add(new IntRange {Result = "Poverty", Min = 0,Max =100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); //25
                diceZone.Add(new IntRange { Result = "Rich", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 260 - existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Poor)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 -(cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Poor)*5);
                }
                diceZone.Add(new IntRange { Result = "Poor", Min = 0, Max =100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poverty", Min = 101 - existingRegionModifier, Max =175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300- existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Average)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 -(cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Average)*5);
                }

                diceZone.Add(new IntRange { Result = "Average", Min = 0, Max = 100- existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300- existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == Wealth.Prosperous)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 -(cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Prosperous)*5);
                }
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 0- existingRegionModifier, Max = 100- existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Rich", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Poor", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300-existingRegionModifier;
            }
            else
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 -(cityRegions.Count(x => x.RegionConfiguration.Wealth == Wealth.Rich)*5);
                }
            
                diceZone.Add(new IntRange { Result = "Rich", Min = 0, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); // 50
                diceZone.Add(new IntRange { Result = "Poor", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 300- existingRegionModifier;
            }

            Random rand = new Random();
            int results = rand.Next(0, max);
            string diceRole = "";
            foreach (var intRange in diceZone)
            {
                if (results > intRange.Min && results <= intRange.Max)
                {
                    diceRole = intRange.Result;
                    break;
                }
            }
       
            if (diceRole == "Poverty")
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
