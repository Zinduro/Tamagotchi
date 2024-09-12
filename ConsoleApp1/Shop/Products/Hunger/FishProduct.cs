using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products.Hunger
{
    public class FishProduct : IProduct
    {
        private string _productType = "FishProduct";
        public string ProductType { get { return _productType; } }

        private static string _name = "Рыба";
        public string Name
        {
            get { return _name; }
        }

        private static StatsEnum _stats = StatsEnum.Hunger;
        public StatsEnum Stat
        {
            get { return _stats; }
        }

        private static int _power = 17;
        public int Power
        {
            get { return _power; }
        }

        private static int _price = 8;
        public int Price
        {
            get { return _price; }
        }
    }
}
