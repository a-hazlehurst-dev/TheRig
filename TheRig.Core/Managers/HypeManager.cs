using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces;

namespace TheRig.Core.Managers
{
    public class HypeManager
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

        public HypeManager()
        {
            Meters = new List<IMeter>
            {

                new Meter(0, 1000,0, "Awareness",1 ), //n# customers
                new Meter(-100, 100, 0, "Reputation",1), // n# customers

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
