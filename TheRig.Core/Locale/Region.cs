using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using TheRig.Core.Interfaces;
using TheRig.Core.Locale.Configurations;
using TheRig.Core.Locale.Enums;

namespace TheRig.Core.Locale
{
    public class Region
    {

        public string Name { get; set; }
        public int BaseCustors { get; set; }
        public int CapacityCustomers { get; set; }
        public RegionConfiguration RegionConfiguration { get; set; }
        public RegionalHypeManager RegionalHypeManager { get; set; }

        public void Turn()
        {
        }

    }

    public static class CustomerGeneratorConfiguration
    {
        public static int TINY_REGION_BASE = 1;
        public static int SMALL_REGION_BASE = 2;
        public static int MEDIUM_REGION_BASE = 3;
        public static int LARGE_REGION_BASE = 4;
        public static int HUGE_REGION_BASE = 5;

    }

    public class CustomerGenerator
    {
        private readonly Region _region;

        public CustomerGenerator(Region region)
        {
            _region = region;
        }

        private int CalculateNumberOfCustomersToGenerate()
        {
            var totalCustomers = 0;
            var generalModifiers = Math.Round(PassThroughGeneral());
            totalCustomers = GetBaseCustomers();
               
            return totalCustomers;
        }

        private int GetBaseCustomers()
        {
            int val = 0;
            if (_region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Tiny) { val = CustomerGeneratorConfiguration.TINY_REGION_BASE; }
            if (_region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Small) { val = CustomerGeneratorConfiguration.SMALL_REGION_BASE; }
            if (_region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Medium) { val = CustomerGeneratorConfiguration.MEDIUM_REGION_BASE; }
            if (_region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Large) { val = CustomerGeneratorConfiguration.LARGE_REGION_BASE; }
            if (_region.RegionConfiguration.PopulationSize == PopulationSizeEnum.Huge) { val = CustomerGeneratorConfiguration.HUGE_REGION_BASE; }
            return val;
        }

        private float PassThroughGeneral()
        {
            float generalModifiers = 0;
            generalModifiers += _region.RegionalHypeManager.General.SingleOrDefault(x => x.Name.Equals("Awareness")).Current/10;
            generalModifiers += _region.RegionalHypeManager.General.SingleOrDefault(x => x.Name.Equals("Competition")).Current / 10; ;
            generalModifiers += _region.RegionalHypeManager.General.SingleOrDefault(x => x.Name.Equals("Reputation")).Current / 10; ;
            generalModifiers += _region.RegionalHypeManager.General.SingleOrDefault(x => x.Name.Equals("Demand")).Current / 10; ;
            return generalModifiers;
        }

        private int GetAwarenessModifier()
        {
            
            
        }
    }


    

    public class RegionalHypeManager
    {
        public List<IMeter> Meters { get; set; }
        public List<IMeter> General
        {
            get
            {
                return Meters.Where(x => x.Group == 1).ToList();
            }
        }
        public List<IMeter> Gender
        {
            get
            {
                return Meters.Where(x => x.Group == 2).ToList();
            }
        }
        public List<IMeter> Age
        {
            get
            {
                return Meters.Where(x => x.Group == 3).ToList();
            }
        }
        public List<IMeter> Occupation
        {
            get
            {
                return Meters.Where(x => x.Group == 4).ToList();
            }
        }

        public RegionalHypeManager()
        {
            Meters = new List<IMeter>
            {

                new Meter(0, 1000, 0, "Awareness",1 ), //n# customers
                new Meter(-100, 100, 0, "Reputation",1), // n# customers
                new Meter(-100, 100, -50, "Competition",1), // n# customers
                new Meter(-100, 100, 0, "Demand",1),

                new Meter(0, 100, 0, "Male", 2), // type of customers
                new Meter(0, 100, 0, "Female",2), // type of customers

                new Meter(0, 100, 0, "Child", 3),
                new Meter(0, 100, 0, "Youth", 3),
                new Meter(0, 100, 0, "Young Adult", 3),
                new Meter(0, 100, 0, "Adult", 3),
                new Meter(0, 100, 0, "Middle Aged", 3),
                new Meter(0, 100, 0, "Veteran", 3),
                new Meter(0, 100, 0, "Retired", 3),

                new Meter(0, 100, 0, "Student", 4),
                new Meter(0, 100, 0, "IT", 4),
                new Meter(0, 100, 0, "Photographer", 4),
                new Meter(0, 100, 0, "Doctor", 4),
                new Meter(0, 100, 0, "Teacher", 4),
                new Meter(0, 100, 0, "Unemployed", 4),
                new Meter(0, 100, 0, "Entreprenour", 4),
                new Meter(0, 100, 0, "Scientist", 4),
                new Meter(0, 100, 0, "Clerk", 4),
                new Meter(0, 100, 0, "Farmer", 4)

            };
        }

        public void Turn()
        {
            
        }
    }
}
