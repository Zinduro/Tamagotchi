﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.ProductEnum;

namespace TamagotchiApp.Shop.Products.Hunger
{
    public class BreadProduct : IProduct
    {
        private string _productType = "BreadProduct";
        public string ProductType { get { return _productType; } }

        private static string _name = "Хлеб";
        public string Name
        { 
            get { return _name; }
        }

        private static StatsEnum _stats = StatsEnum.Hunger;
        public StatsEnum Stat
        {
            get { return _stats; }
        }

        private static int _power = 10;
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
