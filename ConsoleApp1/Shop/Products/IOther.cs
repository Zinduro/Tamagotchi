using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Shop.Products
{
    public interface IOther
    {
        public string ProductType { get; }

        public string Name { get; }

        public int Price { get; }

        public void PerformAction(AbstractTamagotchi tamagotchi);
    }
}
