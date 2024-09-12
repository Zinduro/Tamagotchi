using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models.TamagotchiFactory;

namespace TamagotchiApp.Shop.Products
{
    public interface ISpecial : IProduct
    {
        public TamagotchiEnum TamagotchiType { get; }
    }
}
