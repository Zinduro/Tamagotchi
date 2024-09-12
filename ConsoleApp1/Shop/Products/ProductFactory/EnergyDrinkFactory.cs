using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.Products.Vigor;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public class EnergyDrinkFactory : IAbstractProductFactory
    {
        public IProduct CreateProduct()
        {
            return new EnergyDrinkProduct();
        }
    }
}
