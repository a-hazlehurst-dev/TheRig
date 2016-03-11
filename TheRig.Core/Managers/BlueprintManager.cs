using System.Collections.Generic;
using System.Linq;
using TheRig.Models;

namespace TheRig.Core.Managers
{
    public class BlueprintManager
    {
        public List<Blueprint> Blueprints { get; private set; }
        public Blueprint SelectedBlueprint { get; set; }

        public BlueprintManager()
        {
            Blueprints = new List<Blueprint>();
        }
        public Blueprint GetBlueprintByName(string name)
        {
            return Blueprints.SingleOrDefault(x => x.Name.Equals(name));
        }

        public void AddBlueprint(Blueprint blueprint)
        {
            Blueprints.Add(blueprint);
        }

    }
}
