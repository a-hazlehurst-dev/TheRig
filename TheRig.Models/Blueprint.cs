using TheRig.Models.Components;

namespace TheRig.Models
{
    public class Blueprint
    {
        public int Owner { get; set; }
        public string Name { get; set; }
        public Computer Computer { get; set; }

        public Blueprint()
        {
            Computer = new Computer();
        }

    }
}
