using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products
{
    public interface IProduct
    {
        public string ProductType { get; }

        public string Name { get; }

        public StatsEnum Stat { get; }

        public int Power { get; }

        public int Price { get; }
    }
}
