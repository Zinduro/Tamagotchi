using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.Products.Hunger;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public class BreadFactory : IAbstractProductFactory
    {
        public IProduct CreateProduct()
        {
            return new BreadProduct();
        }
    }
}
