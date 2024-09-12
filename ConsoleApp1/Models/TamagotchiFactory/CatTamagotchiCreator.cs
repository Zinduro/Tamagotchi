using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Models.TamagotchiFactory
{
    class CatTamagotchiCreator : TamagotchiCreator
    {
        public override AbstractTamagotchi CreateTamagotchi(string name)
        {
            return new CatTamagotchi(name);
        }

        public override AbstractTamagotchi CreateTamagotchi(string name, int joy, int hunger, int vigor, int special)
        {
            return new CatTamagotchi(name, joy, hunger, vigor, special);
        }
    }
}
