using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.Shop.Products.Joy;

namespace TamagochiApp.Models
{
    public abstract class AbstractTamagotchi
    {
        public string Name { get; set; }

        protected bool _shouldRun = false;
        public abstract bool RunAway { get; protected set; }

        public abstract string TamagotchiType { get; protected set; }

        private int _joy;
        protected int Joy 
        { 
            get {  return _joy; } 
            set
            {
                if (value <= 0)
                {
                    _joy = 0;
                }
                else
                {
                    _joy = Math.Min(100, value);
                }
            }
        }

        private int _hunger;
        protected int Hunger 
        {
            get { return _hunger; }
            set
            {
                if (value <= 0)
                {
                    _hunger = 0;
                }
                else
                {
                    _hunger = Math.Min(100, value);
                }
            }
        }

        private int _vigor;
        protected int Vigor 
        {
            get { return _vigor; }
            set
            {
                if (value <= 0)
                {
                    _vigor = 0;
                }
                else
                {
                    _vigor = Math.Min(100, value);
                }
            }
        }

        private int _special;
        protected int Special
        {
            get { return _special; }
            set
            {
                if (value <= 0)
                {
                    _special = 0;
                }
                else
                {
                    _special = Math.Min(100, value);
                }
            }
        }

        public abstract void Play(IProduct product);
        
        public abstract void Eat(IProduct product);

        public abstract void Sleep(IProduct product);

        public abstract void SpecialStat(ISpecial special);

        public abstract IDecrease GetStrategy();

        public abstract List<String> GetStringValues();
        public abstract void DecreaseJoy(AbstractTamagotchi tamagotchi);
        public abstract void DecreaseHunger(AbstractTamagotchi tamagotchi);
        public abstract void DecreaseVigor(AbstractTamagotchi tamagotchi);
        public abstract void DecreaseSpecial(AbstractTamagotchi tamagotchi);
        public abstract void IncreaseVigor(AbstractTamagotchi tamagotchi);

        public abstract bool ShouldRunAway();

        public abstract string TypeRussian();
    }
}




