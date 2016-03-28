using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Locale.Enums;
using TheRig.Core.Locale.Interfaces;
using TheRig.Models;

namespace TheRig.Core.Locale.Builders
{
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
                GetDistrictType(regionConfiguration, city.Regions);
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
            if (cityConfiguration.PopulationSize == PopulationSizeEnum.Tiny)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSizeEnum.Tiny) * 5);
                }
                diceZone.Add(new IntRange { Result = "Tiny", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Large", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); //25
                diceZone.Add(new IntRange { Result = "Huge", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 260 - existingRegionModifier;
            }
            else if (cityConfiguration.PopulationSize == PopulationSizeEnum.Small)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSizeEnum.Small) * 5);
                }
                diceZone.Add(new IntRange { Result = "Small", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Tiny", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Medium", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); //75
                diceZone.Add(new IntRange { Result = "Large", Min = 251 - existingRegionModifier, Max = 300 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301 - existingRegionModifier, Max = 325 - existingRegionModifier }); //25
                max = 325 - existingRegionModifier;
            }

            else if (cityConfiguration.PopulationSize == PopulationSizeEnum.Medium)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSizeEnum.Medium) * 5);
                }

                diceZone.Add(new IntRange { Result = "Medium", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Small", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Large", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); //75
                diceZone.Add(new IntRange { Result = "Tiny", Min = 251 - existingRegionModifier, Max = 300 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Huge", Min = 301 - existingRegionModifier, Max = 350 - existingRegionModifier }); //50
                max = 350 - existingRegionModifier;
            }
            else if (cityConfiguration.PopulationSize == PopulationSizeEnum.Large)
            {
                if (regions.Any())
                {
                    existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSizeEnum.Large) * 5);
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
                    existingRegionModifier = 30 - (regions.Count(x => x.RegionConfiguration.PopulationSize == PopulationSizeEnum.Huge) * 5);
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
                regionConfiguration.PopulationSize = PopulationSizeEnum.Tiny;
            }
            if (diceRole == "Small")
            {
                regionConfiguration.PopulationSize = PopulationSizeEnum.Small;
            }
            if (diceRole == "Medium")
            {
                regionConfiguration.PopulationSize = PopulationSizeEnum.Medium;
            }
            if (diceRole == "Large")
            {
                regionConfiguration.PopulationSize = PopulationSizeEnum.Large;
            }
            if (diceRole == "Huge")
            {
                regionConfiguration.PopulationSize = PopulationSizeEnum.Huge;
            }


        }

        private void DetermineRegionWealth(RegionConfiguration regionConfiguration, CityConfiguration cityConfiguration, int randomSeed, List<Region> cityRegions)
        {
            var diceZone = new List<IntRange>();
            int max = 0;
            var existingRegionModifier = 0;
            if (cityConfiguration.Wealth == WealthEnum.Poverty)
            {

                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == WealthEnum.Poverty) * 5);
                }
                diceZone.Add(new IntRange { Result = "Poverty", Min = 0, Max = 100 - existingRegionModifier });//100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier });//75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); //50
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); //25
                diceZone.Add(new IntRange { Result = "Rich", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 260 - existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == WealthEnum.Poor)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == WealthEnum.Poor) * 5);
                }
                diceZone.Add(new IntRange { Result = "Poor", Min = 0, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poverty", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300 - existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == WealthEnum.Average)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == WealthEnum.Average) * 5);
                }

                diceZone.Add(new IntRange { Result = "Average", Min = 0, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Poor", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Rich", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300 - existingRegionModifier;
            }
            else if (cityConfiguration.Wealth == WealthEnum.Prosperous)
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == WealthEnum.Prosperous) * 5);
                }
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 0 - existingRegionModifier, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Rich", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Poor", Min = 251 - existingRegionModifier, Max = 275 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 276 - existingRegionModifier, Max = 300 - existingRegionModifier }); //25
                max = 300 - existingRegionModifier;
            }
            else
            {
                if (cityRegions.Any())
                {
                    existingRegionModifier = 30 - (cityRegions.Count(x => x.RegionConfiguration.Wealth == WealthEnum.Rich) * 5);
                }

                diceZone.Add(new IntRange { Result = "Rich", Min = 0, Max = 100 - existingRegionModifier }); //100
                diceZone.Add(new IntRange { Result = "Prosperous", Min = 101 - existingRegionModifier, Max = 175 - existingRegionModifier }); // 75
                diceZone.Add(new IntRange { Result = "Average", Min = 176 - existingRegionModifier, Max = 225 - existingRegionModifier }); // 50
                diceZone.Add(new IntRange { Result = "Poor", Min = 226 - existingRegionModifier, Max = 250 - existingRegionModifier }); // 25
                diceZone.Add(new IntRange { Result = "Poverty", Min = 251 - existingRegionModifier, Max = 260 - existingRegionModifier }); //10
                max = 300 - existingRegionModifier;
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
                regionConfiguration.Wealth = WealthEnum.Poverty;
            }
            if (diceRole == "Poor")
            {
                regionConfiguration.Wealth = WealthEnum.Poor;
            }
            if (diceRole == "Average")
            {
                regionConfiguration.Wealth = WealthEnum.Average;
            }
            if (diceRole == "Prosperous")
            {
                regionConfiguration.Wealth = WealthEnum.Prosperous;
            }
            if (diceRole == "Rich")
            {
                regionConfiguration.Wealth = WealthEnum.Rich;
            }
        }

        private void GetDistrictType(RegionConfiguration regionConfiguration,  List<Region> cityRegions)
        {
            int resCount = 0;
            int indCount = 0;
            int comCount = 0;

            foreach (var region in cityRegions)
            {
                if (region.RegionConfiguration.Type == RegionTypes.Residential)
                {
                    resCount++;
                }
                if (region.RegionConfiguration.Type == RegionTypes.Commercial)
                {
                    comCount++;
                }
                if (region.RegionConfiguration.Type == RegionTypes.Industrial)
                {
                    indCount++;
                }
            }

            if (resCount == 0)
            {
                regionConfiguration.Type = RegionTypes.Residential;
                return;
            }
            if (comCount == 0)
            {
                regionConfiguration.Type = RegionTypes.Commercial;
                return;
            }
            if (indCount == 0)
            {
                regionConfiguration.Type = RegionTypes.Industrial;
                return;
            }

            int random = RandomNumber.Randomness.getNextInt(1, 3);
            if (random == 1)
            {
                regionConfiguration.Type = RegionTypes.Residential;
            }
            if (random == 2)
            {
                regionConfiguration.Type = RegionTypes.Industrial;
            }
            if (random == 3)
            {
                regionConfiguration.Type = RegionTypes.Commercial;
            }
        }
    }
}
