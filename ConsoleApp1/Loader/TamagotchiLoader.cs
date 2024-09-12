using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Game;
using TamagotchiApp.Models;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Models.StatsShow;
using TamagotchiApp.Models.TamagotchiFactory;
using TamagotchiApp.Models.TamagotchiRun;
using TamagotchiApp.Player;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.Shop.Products.Hunger;
using TamagotchiApp.Shop.Products.ProductFactory;

namespace TamagotchiApp.Loader
{
    public class TamagotchiLoader
    {
        private static DateTime date;

        private static string name;
        private static string tamagotchiType;
        private static int joy;
        private static int hunger;
        private static int vigor;
        private static int special;

        private static int playerCoins;

        private static int productsCount;
        private static int specialsCount;
        private static int othersCount;


        public static AbstractTamagotchi LoadGame(PlayerInventory playerInventory, DecreaseTimer decreaseTimer, StatsTimer statsTimer, RunAwayTimer runAwayTimer)
        {
            Dictionary<string, IAbstractProductFactory> productFactories = [];
            Dictionary<string, IAbsctractSpecialFactory> specialFactories = [];
            Dictionary<string, IAbstractOtherFactory> otherFactories = [];

            productFactories.Add("BallProduct", new BallFactory());
            productFactories.Add("TeddyBearProduct", new TeddyBearFactory());
            productFactories.Add("BreadProduct", new BreadFactory());
            productFactories.Add("FishProduct", new FishFactory());
            productFactories.Add("MeatProduct", new MeatFactory());
            productFactories.Add("CoffeeProduct", new CoffeeFactory());
            productFactories.Add("EnergyDrinkProduct", new EnergyDrinkFactory());

            specialFactories.Add("MouseProduct", new MouseFactory());
            specialFactories.Add("ForFlightProduct", new ForFlightFactory());

            otherFactories.Add("NameChanger", new NameChangerFactory());

            Dictionary<string, TamagotchiCreator> tamagotchiFactories = [];

            tamagotchiFactories.Add("CatTamagotchi", new CatTamagotchiCreator());
            tamagotchiFactories.Add("BirdTamagotchi", new BirdTamagotchiCreator());

            StreamReader sr = new StreamReader(Program.Path);

            date = DateTime.Parse(sr.ReadLine());
            name = sr.ReadLine();
            tamagotchiType = sr.ReadLine();
            joy = int.Parse(sr.ReadLine());
            hunger = int.Parse(sr.ReadLine());
            vigor = int.Parse(sr.ReadLine());
            special = int.Parse(sr.ReadLine());

            playerCoins = int.Parse(sr.ReadLine());

            TamagotchiCreator currentTamagotchiFactory = tamagotchiFactories.Where(f => f.Key == tamagotchiType).First().Value;
            ;

            AbstractTamagotchi currentTamagotchi = ClientTamagotchi.CreateTamagotchi(currentTamagotchiFactory, name, joy, hunger, vigor, special);

            double offlineTime = MillisecondsOffline(date);
            DecreaseForOffline(currentTamagotchi, offlineTime);

            playerInventory.Tamagotchi = currentTamagotchi;
            playerInventory.Coins = playerCoins;

            if (decreaseTimer.GetType().GetEvents() == null)
            {
                decreaseTimer.Stop();
            }
            if (statsTimer.GetType().GetEvents() == null)
            {
                statsTimer.Stop();
            }
            decreaseTimer.SetStrategy(currentTamagotchi.GetStrategy());
            runAwayTimer.SetTamagotchi(currentTamagotchi);

            productsCount = int.Parse(sr.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                string productType = sr.ReadLine();

                IAbstractProductFactory currentProductFactory = productFactories.Where(f => f.Key == productType).First().Value;
                IProduct product = currentProductFactory.CreateProduct();

                playerInventory.AddProduct(product);
            }

            specialsCount = int.Parse(sr.ReadLine());
            for (int i = 0; i < specialsCount; i++)
            {
                string productType = sr.ReadLine();

                IAbsctractSpecialFactory currentSpecialFactory = specialFactories.Where(f => f.Key == productType).First().Value;
                ISpecial special = currentSpecialFactory.CreateSpecial();

                playerInventory.AddProduct(special);
            }

            othersCount = int.Parse(sr.ReadLine());
            for (int i = 0; i < othersCount; i++)
            {
                string productType = sr.ReadLine();

                IAbstractOtherFactory currentOtherFactory = otherFactories.Where(f => f.Key == productType).First().Value;
                IOther other = currentOtherFactory.CreateOther();

                playerInventory.AddProduct(other);
            }

            return currentTamagotchi;
        }

        private static double MillisecondsOffline(DateTime lastPlayed)
        {
            DateTime dateTimeNow = DateTime.Now;
            double difference = (dateTimeNow - lastPlayed).TotalMilliseconds;

            return difference;
        }

        private static void DecreaseForOffline(AbstractTamagotchi tamagotchi, double milliseconds)
        {
            for (int i = 0; i <= milliseconds / tamagotchi.GetStrategy().JoyDecreaseCooldown; i++)
            {
                tamagotchi.GetStrategy().DecreaseJoy(tamagotchi);
            }
            for (int i = 0; i <= milliseconds / tamagotchi.GetStrategy().HungerDecreaseCooldown; i++)
            {
                tamagotchi.GetStrategy().DecreaseHunger(tamagotchi);
            }
            for (int i = 0; i <= milliseconds / tamagotchi.GetStrategy().VigorDecreaseCooldown; i++)
            {
                tamagotchi.GetStrategy().DecreaseVigor(tamagotchi);
            }
            for (int i = 0; i <= milliseconds / tamagotchi.GetStrategy().SpecialDecreaseCooldown; i++)
            {
                tamagotchi.GetStrategy().DecreaseSpecial(tamagotchi);
            }
        }
    }
}
