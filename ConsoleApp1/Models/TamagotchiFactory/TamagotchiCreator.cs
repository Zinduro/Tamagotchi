using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Models.TamagotchiFactory
{
    public abstract class TamagotchiCreator
    {
        public abstract AbstractTamagotchi CreateTamagotchi(string name);
        public abstract AbstractTamagotchi CreateTamagotchi(string name, int joy, int hunger, int vigor, int special);
    }
}
