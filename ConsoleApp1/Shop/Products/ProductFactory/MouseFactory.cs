using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Shop.Products.Special;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public class MouseFactory : IAbsctractSpecialFactory
    {
        public ISpecial CreateSpecial()
        {
            return new MouseProduct();
        }
    }
}
