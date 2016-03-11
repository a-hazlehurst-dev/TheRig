using System;
using System.Collections.Generic;
using System.Linq;
using TheRig.Models.Components;

namespace TheRig.UI.Helper
{
    public class DisplayHelper
    {
        public Item SelectableList(List<Item> listOfItems)
        {
            Console.WriteLine("Please select from the list and type the number next to the item.");
            int count = 0;
            foreach (var item in listOfItems)
            {
                Console.WriteLine(count + ", " + item.Name);
                count++;
            }

            int x = 0;
            string line = "";
            do
            {
                Console.WriteLine("Please select a valid number");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out x));

            return listOfItems.ElementAt(x);
        }
    }
}