﻿using System.Collections.Generic;
using System.Linq;
using TheRig.Models;

namespace TheRig.Core.Services
{
    public class BlueprintService
    {
        public List<Blueprint> Blueprints { get; }

        public BlueprintService()
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

        public List<Blueprint> GetPlayersBlueprints(int id)
        {
            return Blueprints.Where(x => x.Owner == id).ToList();
        }
    }
}