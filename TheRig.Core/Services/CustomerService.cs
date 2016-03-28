using System;
using System.Collections.Generic;
using TheRig.Models;

namespace TheRig.Core.Services
{
    public class CustomerService
    {
        private Random _random;
        public List<Customer> ActiveCustomers { get; set; }
        public List<Customer> HistoricalCustomers { get; set; }

        public CustomerService()
        {
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
