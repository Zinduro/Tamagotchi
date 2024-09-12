using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiApp.Shop.Products.ProductFactory
{
    public interface IAbsctractSpecialFactory
    {
        public ISpecial CreateSpecial();
    }
}
