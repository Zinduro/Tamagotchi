using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products.Vigor
{
    public class CoffeeProduct : IProduct
    {
        private string _productType = "CoffeeProduct";
        public string ProductType { get { return _productType; } }

        private static string _name = "Кофе";
        public string Name
        {
            get { return _name; }
        }

        private static StatsEnum _stats = StatsEnum.Vigor;
        public StatsEnum Stat
        {
            get { return _stats; }
        }

        private static int _power = 15;
        public int Power
        {
            get { return _power; }
        }

        private static int _price = 7;
        public int Price
        {
            get { return _price; }
        }
    }
}
