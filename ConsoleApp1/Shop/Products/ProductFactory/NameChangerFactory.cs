using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.Products.Name;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public class NameChangerFactory : IAbstractOtherFactory
    {
        public IOther CreateOther()
        {
            return new NameChanger();
        }
    }
}
