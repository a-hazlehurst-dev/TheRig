using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.Models
{
    public class Distributor
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public decimal CostOfAllStock
        {
            get
            {
                var total = 0.00M;
                foreach (var item in StockItems)
                {
                    total += item.SellPrice*item.StockCount;
                }
                return total;
            }
        }

        public List<ItemStock> StockItems { get; set; }

        public Distributor()
        {
            StockItems = new List<ItemStock>();
        }

        public void AddItems(Item item, int quantity)
        {
            var check = StockItems.SingleOrDefault(x => x.Item.Id == item.Id);
            if (check!=null)
            {
                check.StockCount += quantity;
            }
            else
            {
                StockItems.Add(new ItemStock { Item =item, SellPrice = item.Price*0.50M, StockCount = quantity});
            }
        }

        public void RemoveItems(Item item, int quantity)
        {
            var check = StockItems.SingleOrDefault(x => x.Item.Id == item.Id);

            if (check == null) return;

            if (check.StockCount - quantity >= 0)
            {
                check.StockCount -= quantity;
            }
        }

        public ItemStock CheckItem(Item item)
        {
            return StockItems.SingleOrDefault(x => x.Item.Id.Equals(item.Id));
        }
    }
}
