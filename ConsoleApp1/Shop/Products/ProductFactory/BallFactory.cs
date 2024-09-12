using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.Products.Joy;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public class BallFactory : IAbstractProductFactory
    {
        public IProduct CreateProduct()
        {
            return new BallProduct();
        }
    }
}
