using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products.Joy
{
    public class BallProduct : IProduct
    {
        private string _productType = "BallProduct";
        public string ProductType { get { return _productType; } }

        private static string _name = "Мячик";
        public string Name
        {
            get { return _name; }
        }

        private static StatsEnum _stats = StatsEnum.Joy;
        public StatsEnum Stat
        {
            get { return _stats; }
        }

        private static int _power = 20;
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
