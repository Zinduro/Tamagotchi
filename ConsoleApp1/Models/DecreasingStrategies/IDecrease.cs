using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Models.DecreasingStrategies
{
    public interface IDecrease
    {
        public AbstractTamagotchi TamagotchiType { get; set; }
        public int JoyDecreaseCooldown { get; set; }
        public int HungerDecreaseCooldown { get; set; }
        public int VigorDecreaseCooldown { get; set; }
        public int SpecialDecreaseCooldown { get; set; }

        public void DecreaseJoy(AbstractTamagotchi tamagotchi);
        public void DecreaseHunger(AbstractTamagotchi tamagotchi);
        public void DecreaseVigor(AbstractTamagotchi tamagotchi);
        public void DecreaseSpecial(AbstractTamagotchi tamagotchi);
        public void IncreaseVigor(AbstractTamagotchi tamagotchi);
    }
}
