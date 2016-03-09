using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces;

namespace TheRig.Core
{
    public class HypeManager
    {
        public List<CustomerHypeMeter> HypeMeters { get; set; }

        public HypeManager()
        {
            HypeMeters = new List<CustomerHypeMeter>
            {
                new CustomerHypeMeter(-100,100 ,0, "Kids"),
                new CustomerHypeMeter(-100, 100, 0, "Youths"),
                new CustomerHypeMeter(-100, 100, 0, "Young Adults"),
                new CustomerHypeMeter(-100, 100, 0, "Adults"),
                new CustomerHypeMeter(-100, 100, 0, "Middle Aged"),
                new CustomerHypeMeter(-100, 100, 0, "Veteran"),
                new CustomerHypeMeter(-100, 100, 0, "Retired"),
            };
        }


        private void ProcessAdvertisingHype(List<AdvertisingCampaign> campaigns)
        {

            if (campaigns.Any(x => x.Status == AdvertisingStatus.Active))
            {
                var activeCampaigns = campaigns.Where(x => x.Status == AdvertisingStatus.Active);
                foreach (var campaign in activeCampaigns)
                {
                    ChangeHypeMeter(campaign.Primary.Name, 2);
                    
                    foreach (var demographic in campaign.Secondary)
                    {
                       ChangeHypeMeter(demographic.Name, .8f);
                    }
                }
            }
        }

        private void ChangeHypeMeter(string name, float value)
        {
            var hypeMeter = HypeMeters.SingleOrDefault(x => x.Name == name);
            if (hypeMeter != null)
            {
                hypeMeter.Change(value);
            }
        }

        public void Turn(DateTime gameDate, List<AdvertisingCampaign> campaigns)
        {
            ProcessAdvertisingHype(campaigns);
            ProcessNaturalDecay();
        }

        private void ProcessNaturalDecay()
        {
            foreach (var hypeMeter in HypeMeters)
            {
                var decayRate = (hypeMeter.Current/125)*-1;
                hypeMeter.Change(decayRate);
            }
        }

        public double GetTotalHype()
        {
            return  HypeMeters.Sum(x => x.Current);
        }
    }
    

    public class Demographic
    {
        public string Name { get; set; }

    }

    public class AdvertisingCampaign
    {
        public AdvertisingCampaign()
        {
        }


        public Demographic Primary { get;  set; }
        public List<Demographic> Secondary { get;  set; }
        public AdvertisingFunding Funding { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public AdvertisingStatus Status { get; set; }
    }

    public class AdvertisingFunding
    {
        public AdvertisingFunding(float funding)
        {
            
        }
        public  FundingLevel FundingLevel { get; set; }
        public float CostPerDay { get;  }
    }

    public enum FundingLevel
    {
        Low,
        Standard,
        High,
        Extreme
    }

    public enum AdvertisingStatus
    {
        Scheduled,
        Active,
        Cancelled,
        Completed
    }

    public class Region
    {
        public string Name { get; set; }
        public int BaseCustomers { get; set; }
        public RegionDemographic Demographic { get; set; }
        public HypeManager Hype { get; set; }
    }

    public class RegionDemographic
    {
        public Wealth Wealth { get; set; }
        public Type Type { get; set; }
        
        
    }

    public enum Wealth
    {
        Poor,
        Low,
        Average,
        Good,
        Wealthy,
        Rich
        
    }

    public enum Type
    {
        Residential,
        Commercial,
        Industrial
    }


    public class BalanceScale
    {
        
    }

}
