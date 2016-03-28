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
            return 1;
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
