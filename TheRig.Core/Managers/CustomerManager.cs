using System;
using System.Collections.Generic;
using TheRig.Models;

namespace TheRig.Core.Managers
{
    public class CustomerManager
    {
        private Random _random;
        public List<Customer> ActiveCustomers { get; set; }
        public List<Customer> HistoricalCustomers { get; set; }

        private readonly HypeManager _hypeManager;
        public CustomerManager(HypeManager hypeManager)
        {
            _hypeManager = hypeManager;
            _random = new Random();
        }

        public void Turn(DateTime gameDate)
        {
            
        }

        private int DetermineNumberOfCustomersToCreate()
        {
            var hypePower = _hypeManager.GetTotalHype();
            if (hypePower > 0 && hypePower < 100)
            {
                return _random.Next(10, 50);
            }
            if (hypePower > 99 && hypePower < 200)
            {
                return _random.Next(40, 120);
            }
            if (hypePower > 199 && hypePower < 300)
            {
                return _random.Next(80, 150);
            }

            return 0;
        }

        private void CreateCustomers()
        {
            
        }

        private Customer CreateCustomer()
        {
            return null;
        }


    }
}
