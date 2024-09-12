using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;

namespace TamagotchiApp.Models.DecreasingStrategies
{
    public class CatTamagotchiDecrease(AbstractTamagotchi tamagotchi) : IDecrease
    {
        private AbstractTamagotchi _tamagotchiType = tamagotchi;
        public AbstractTamagotchi TamagotchiType
        {
            get { return _tamagotchiType; }
            set
            {
                _tamagotchiType = value;
            }
        }

        private int _joyDecreaseCoooldown = 3200;
        public int JoyDecreaseCooldown
        {
            get { return _joyDecreaseCoooldown; }
            set
            {
                _joyDecreaseCoooldown = value;
            }
        }

        private int _hungerDecreaseCoooldown = 2800;
        public int HungerDecreaseCooldown
        {
            get { return _hungerDecreaseCoooldown; }
            set
            {
                _hungerDecreaseCoooldown = value;
            }
        }

        private int _vigorDecreaseCoooldown = 4100;
        public int VigorDecreaseCooldown
        {
            get { return _vigorDecreaseCoooldown; }
            set
            {
                _vigorDecreaseCoooldown = value;
            }
        }

        private int _specialDecreaseCoooldown = 1500;
        public int SpecialDecreaseCooldown
        {
            get { return _specialDecreaseCoooldown; }
            set
            {
                _specialDecreaseCoooldown = value;
            }
        }

        public void DecreaseJoy(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.DecreaseJoy(tamagotchi);
        }

        public void DecreaseHunger(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.DecreaseHunger(tamagotchi);
        }

        public void DecreaseVigor(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.DecreaseVigor(tamagotchi);
        }

        public void DecreaseSpecial(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.DecreaseSpecial(tamagotchi);
        }

        public void IncreaseVigor(AbstractTamagotchi tamagotchi)
        {
            tamagotchi.IncreaseVigor(tamagotchi);
        }
    }
}
