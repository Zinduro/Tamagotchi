using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Models.TamagotchiFactory
{
    class BirdTamagotchiCreator : TamagotchiCreator
    {
        public override AbstractTamagotchi CreateTamagotchi(string name)
        {
            return new BirdTamagotchi(name);
        }

        public override AbstractTamagotchi CreateTamagotchi(string name, int joy, int hunger, int vigor, int special)
        {
            return new BirdTamagotchi(name, joy, hunger, vigor, special);
        }
    }
}
