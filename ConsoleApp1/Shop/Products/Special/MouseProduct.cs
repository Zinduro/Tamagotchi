using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models.TamagotchiFactory;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products.Special
{
    public class MouseProduct : ISpecial
    {
        private string _productType = "MouseProduct";
        public string ProductType { get { return _productType; } }

        private static TamagotchiEnum _type;
        public TamagotchiEnum TamagotchiType { get { return _type; } }

        private static string _name = "Мышь";
        public string Name
        {
            get { return _name; }
        }

        private static StatsEnum _stats = StatsEnum.Special;
        public StatsEnum Stat
        {
            get { return _stats; }
        }

        private static int _power = 20;
        public int Power
        {
            get { return _power; }
        }

        private static int _price = 5;
        public int Price
        {
            get { return _price; }
        }
    }
}
