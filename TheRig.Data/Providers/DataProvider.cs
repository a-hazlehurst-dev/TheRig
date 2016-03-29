using System.Collections.Generic;
using TheRig.Core.Interfaces;
using TheRig.Models;
using TheRig.Models.Components;

namespace TheRig.Data.Providers
{
    public class DataProvider : IDataProvider
    {
        private List<ItemStock> VisageStock()
        {
            return new List<ItemStock>
            {
                new ItemStock
                {
                    Item = new Motherboard(2, 1, 1, 1) { Id ="MB-01", RamTypeId = 1, Name = "Fade", CpuTypeId = 1, GraphicsTypeId = 1, SoundTypeId = 1, Price = 50.0m},
                    StockCount = 100,
                    SellPrice = 79.99M
                },
                new ItemStock
                {
                    Item = new Ram {Id = "RM-01", TypeId = 1, Name = "Grayso", Speed = 1, Capacity = 5, Price = 50.0M},
                    StockCount = 100,
                    SellPrice = 75.00M
                },
                new ItemStock
                {
                    Item = new Graphic {Id = "GR-01", Name = "Fog",  TypeId = 1 , Speed = 1, Price = 100.00M},
                    StockCount = 100,
                    SellPrice = 125M
                },
                new ItemStock
                {
                      Item = new Cpu {Id = "CP-01", TypeId = 1, Name = "Mirage", Speed = 1, Price = 98.00M},
                      StockCount = 100,
                      SellPrice = 125M
                },
                new ItemStock
                {
                      Item = new Sound {Id = "SO-01", Name = "Tinge",  TypeId = 1, Price = 12.99M},
                      StockCount = 100,
                      SellPrice = 19.99M
                }


            };
        }

        private List<ItemStock> LizardStock()
        {
            return new List<ItemStock>
            {
                new ItemStock
                {
                    Item = new Ram {Id = "RM-02", TypeId = 1, Name = "Iguana", Speed = 1, Capacity = 8, Price = 70.0M},
                    StockCount = 100,
                    SellPrice = 99M
                },
                new ItemStock
                {
                    Item = new Ram {Id = "RM-03", TypeId = 1, Name = "Dragon", Speed = 1, Capacity = 10, Price = 75.0M},
                    StockCount = 100,
                    SellPrice = 105M
                },
                new ItemStock
                {
                    Item = new Ram {Id = "RM-04", TypeId = 2, Name = "Gecko", Speed = 2, Capacity = 8, Price = 100.0M},
                    StockCount = 100,
                    SellPrice = 130M
                }
            };
        }

        private List<ItemStock> RockStock()
        {
            return new List<ItemStock>
            {
                new ItemStock
                {
                    Item = new Cpu {Id = "CP-02", TypeId = 1, Name = "Lime", Speed = 1, Price = 98.00M},
                    SellPrice = 125M,
                    StockCount = 100
                },
                new ItemStock
                {
                    Item = new Cpu {Id = "CP-03", TypeId = 1, Name = "Igneus", Speed = 2, Price = 130.00M},
                    SellPrice = 160M,
                    StockCount = 100,
                },
                new ItemStock
                {
                    Item = new Cpu {Id = "CP-04", TypeId = 1, Name = "Salt", Speed = 2, Price = 199.00M},
                    SellPrice = 250M,
                    StockCount = 100,
                }
            };
        }

        private List<ItemStock> DewsburyStock()
        {
            return new List<ItemStock>
            {
                new ItemStock
                {
                    Item =new Graphic {Id = "GR-02", Name = "Leeds",  TypeId = 1 , Speed = 1, Price = 100.00M},
                    SellPrice = 125M,
                    StockCount = 100
                },
                new ItemStock
                {
                    Item = new Graphic {Id = "GR-03", Name = "London",  TypeId = 1, Speed = 2, Price = 125.00M},
                    SellPrice = 150M,
                    StockCount = 100
                },
                new ItemStock
                {
                    Item = new Graphic { Id ="GR-04", Name ="Chester",  TypeId =2, Speed = 3, Price = 170.00M},
                     SellPrice = 199.99M,
                    StockCount = 100
                }

            };
        }

        private List<ItemStock> BandStock()
        {
            return new List<ItemStock>
            {
                new ItemStock
                {
                    Item =new Sound {Id = "SO-01", Name = "Tune",  TypeId = 1, Price = 12.99M},
                    SellPrice = 16.99M,
                    StockCount = 100,
                },
                new ItemStock
                {
                    Item = new Sound {Id = "SO-02", Name = "Ballad",  TypeId = 3, Price = 25.99M},
                    SellPrice = 35M,
                    StockCount = 100
                }
            };
        }

        public List<Manufacturer> GetManufacturers()
        {
            return new List<Manufacturer>
            {
                new Manufacturer { Id="M-01", Name = "Visaage", Stock = VisageStock() },
                new Manufacturer { Id="M-02", Name = "Lizard", Stock = LizardStock()},
                new Manufacturer { Id="M-03", Name = "Rock", Stock = RockStock() },
                new Manufacturer { Id="M-04", Name = "Dewsbury", Stock = DewsburyStock()  },
                new Manufacturer { Id ="M-05", Name = "Band", Stock = BandStock()}
            };
        }
    }
}
