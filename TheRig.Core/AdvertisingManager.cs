using System;
using System.Collections.Generic;

namespace TheRig.Core
{
    public class AdvertisingManager
    {
        public List<AdvertisingCampaign> Active { get; set; }
        public List<AdvertisingCampaign> History { get; set; }


        public AdvertisingManager()
        {
            Active = new List<AdvertisingCampaign>();
            History = new List<AdvertisingCampaign>();
        }

        public void AddAdvertisingCampaign(AdvertisingCampaign advertisingCampaign)
        {
            Active.Add(advertisingCampaign);
        }

        public void Turn(DateTime time)
        {
           ProcessActiveCampaigns(time);
        }

        private void ProcessActiveCampaigns(DateTime time)
        {
            List<AdvertisingCampaign> tempCampaigns = new List<AdvertisingCampaign>();
            foreach (var advertising in Active)
            {
                var started = false;
                var ended = false;
                if (advertising.StartDate <= time)
                {
                    started = true;
                }
                if (advertising.EndDate < time)
                {
                    ended = true;
                    
                }

                if (!started)
                {
                    advertising.Status = AdvertisingStatus.Scheduled;
                    tempCampaigns.Add(advertising);
                }
                else
                {
                    if (!ended)
                    {
                        advertising.Status = AdvertisingStatus.Active;
                        tempCampaigns.Add(advertising);
                    }
                    else
                    {
                        advertising.Status = AdvertisingStatus.Completed;
                        History.Insert(0, advertising);
                    }
                }
            }
            Active = tempCampaigns;
        }
    }
}
