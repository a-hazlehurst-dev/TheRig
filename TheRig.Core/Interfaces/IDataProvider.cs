using System.Collections.Generic;
using TheRig.Models;
using TheRig.Models.Components;

namespace TheRig.Core.Interfaces
{
    public interface IDataProvider
    {
        List<Manufacturer> GetManufacturers();
    }
}
