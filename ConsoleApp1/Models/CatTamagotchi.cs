using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Shop.Products.Joy;
using TamagotchiApp.Shop.Products;

namespace TamagochiApp.Models
{
    public class CatTamagotchi : AbstractTamagotchi
    {

        public override bool RunAway
        {
            get { return _shouldRun; }
            protected set { _shouldRun = value; }
        }

        private string _tamagotchiType = "CatTamagotchi";
        public override string TamagotchiType
        {
            get { return _tamagotchiType; }
            protected set { _tamagotchiType = value; }
        }

        public CatTamagotchi(string name)
        {
            this.Name = name;
            Joy = 100;
            Hunger = 100;
            Vigor = 100;
            Special = 100;
        }

        public CatTamagotchi(string name, int joy, int hunger, int vigor, int special)
        {
            this.Name = name;
            Joy = joy;
            Hunger = hunger;
            Vigor = vigor;
            Special = special;
        }

        public override void Play(IProduct product)
        {
            Joy += product.Power;
        }

        public override void Eat(IProduct product)
        {
            Hunger += product.Power;
        }

        public override void Sleep(IProduct product)
        {
            Vigor += product.Power;
        }

        public override void SpecialStat(ISpecial special)
        {
            Special += special.Power;
        }

        public override IDecrease GetStrategy()
        {
            return new CatTamagotchiDecrease(this);
        }

        public override void DecreaseJoy(AbstractTamagotchi tamagotchi)
        {
            Joy--;
        }

        public override void DecreaseHunger(AbstractTamagotchi tamagotchi)
        {
            Hunger--;
        }

        public override void DecreaseVigor(AbstractTamagotchi tamagotchi)
        {
            Vigor--;
        }

        public override void DecreaseSpecial(AbstractTamagotchi tamagotchi)
        {
            Special--;
        }

        public override void IncreaseVigor(AbstractTamagotchi tamagotchi)
        {
            Vigor++;
        }

        public override List<string> GetStringValues()
        {
            List<string> values =
            [
                Name,
                TamagotchiType,
                Joy.ToString(),
                Hunger.ToString(),
                Vigor.ToString(),
                Special.ToString(),
                TypeRussian(),
            ];

            return values;
        }

        public override bool ShouldRunAway()
        {
            if (Joy == 0 || Hunger == 0 || Vigor == 0 || Special == 0)
            {
                RunAway = true;
            }
            return RunAway;
        }

        public override string TypeRussian()
        {
            return "Кошка";
        }
    }
}
