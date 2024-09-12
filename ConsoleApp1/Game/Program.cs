using TamagochiApp.Models;
using TamagotchiApp.Loader;
using TamagotchiApp.MiniGames;
using TamagotchiApp.Models;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Models.StatsShow;
using TamagotchiApp.Models.TamagotchiFactory;
using TamagotchiApp.Models.TamagotchiRun;
using TamagotchiApp.Player;
using TamagotchiApp.Saver;
using TamagotchiApp.Shop;
using TamagotchiApp.Shop.ProductEnum;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.Shop.Products.Hunger;
using TamagotchiApp.Shop.Products.Joy;
using TamagotchiApp.Shop.Products.Name;
using TamagotchiApp.Shop.Products.Special;
using TamagotchiApp.Shop.Products.Vigor;
using TamagotchiApp.UI;

namespace TamagotchiApp.Game
{
    public class Program
    {
        private static string _path = Directory.GetCurrentDirectory() + "\\save.txt"; //хранится рядом с exe файлом
        public static string Path
        {
            get { return _path; }
        }

        static void Main(string[] args)
        {
            Menu.ShowStartMenu(); //если есть файл сохранения, то спросить, хочет ли его загрузить. Тогда оттуда подставлять.
            Menu.ShowYourChoice();
            TamagotchiCreator creator = null;
            do
            {
                int choice = ClientTamagotchi.GetTamagotchiChoice();

                if (choice == (int)TamagotchiEnum.Cat)
                {
                    creator = new CatTamagotchiCreator();
                }
                else if (choice == (int)TamagotchiEnum.Bird)
                {
                    creator = new BirdTamagotchiCreator();
                }
                else
                {
                    Menu.ShowInvalidChoice();
                }
            } while (creator == null);

            Menu.ShowNameChoice();
            string name = ClientTamagotchi.GetTamagotchiNameChoice();

            AbstractTamagotchi currentTamagotchi = ClientTamagotchi.CreateTamagotchi(creator, name);

            Menu.ShowGreetings(currentTamagotchi);

            DecreaseTimer decreaseTimer = new DecreaseTimer(currentTamagotchi.GetStrategy());
            decreaseTimer.DecreaseAllValues();

            StatsTimer statsTimer = new StatsTimer(currentTamagotchi);

            RunAwayTimer runAwayTimer = new RunAwayTimer(currentTamagotchi);

            PlayerInventory playerInventory = new PlayerInventory(currentTamagotchi);
            ShopLogic shop = new ShopLogic();


            int optionChoice = 1;
            while (optionChoice != 0)
            {
                if (runAwayTimer.TamagotchiCheck(creator, decreaseTimer, statsTimer) != null)
                {
                    currentTamagotchi = runAwayTimer.TamagotchiCheck(creator, decreaseTimer, statsTimer);
                }

                Menu.ShowOptions();
                Menu.ShowYourChoice();
                optionChoice = ClientTamagotchi.GetOptionChoice();
                switch (optionChoice)
                {
                    case (int)OptionsEnum.Inventory:
                        Menu.Clear();
                        Menu.ShowInventory(playerInventory);
                        Menu.ShowChooseToUseItem();
                        Menu.ShowYourChoice();
                        int useChoose = ClientTamagotchi.GetOptionChoice();
                        switch (useChoose)
                        {
                            case 1:
                                Menu.ShowChooseInventoryItem();
                                Menu.ShowYourChoice();
                                playerInventory.UseIfInInventory(Console.ReadLine());
                                Menu.Clear();
                                break;
                            case 2:
                                break;
                        }
                        break;
                    case (int)OptionsEnum.Sleep:
                        Menu.Clear();
                        decreaseTimer.Stop();
                        decreaseTimer.DecreaseExceptVigor();
                        statsTimer.ShowStats();
                        bool flag = true;
                        while (flag == true)
                        {
                            if (Console.ReadKey().Key == ConsoleKey.D1)
                            {
                                statsTimer.Stop();
                                flag = false;
                            }
                        }
                        decreaseTimer.Stop();
                        decreaseTimer.DecreaseAllValues();
                        break;
                    case (int)OptionsEnum.Stats:
                        Menu.Clear();
                        Menu.ShowStats(currentTamagotchi);
                        break;
                    case (int)OptionsEnum.MiniGame:
                        Menu.Clear();
                        Menu.ShowMiniGameMenu();
                        int miniGameChoice = ClientTamagotchi.GetOptionChoice();
                        switch (miniGameChoice)
                        {
                            case (int)MiniGamesEnum.Riddles:
                                Menu.Clear();
                                Menu.ShowRiddlesRules();
                                Riddles.StartGame(playerInventory);
                                break;
                            case (int)MiniGamesEnum.GuessNumber:
                                Menu.Clear();
                                Menu.ShowGuessNumberRules();
                                GuessNumber.StartGame(playerInventory);
                                break;
                            case (int)MiniGamesEnum.Shuffle:
                                Menu.Clear();
                                Menu.ShowShuffleRules();
                                Shuffle.StartGame(playerInventory);
                                break;
                        }
                        break;
                    case (int)OptionsEnum.Shop:
                        Menu.Clear();
                        Menu.ShowShopMenu();
                        Menu.ShowYourChoice();
                        int shopChoice = ClientTamagotchi.GetOptionChoice();
                        IProduct product;
                        ISpecial special;
                        IOther other;
                        switch (shopChoice)
                        {
                            case (int)StatsEnum.Joy:
                                Menu.ShowShopJoyMenu();
                                Menu.ShowYourChoice();
                                int joyChoice = ClientTamagotchi.GetOptionChoice();
                                switch (joyChoice)
                                {
                                    case (int)ProductJoyEnum.Ball:
                                        product = new BallProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                    case (int)ProductJoyEnum.TeddyBear:
                                        product = new TeddyBearProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                }
                                break;
                            case (int)StatsEnum.Hunger:
                                Menu.ShowShopHungerMenu();
                                Menu.ShowYourChoice();
                                int hungerChoice = ClientTamagotchi.GetOptionChoice();
                                switch (hungerChoice)
                                {
                                    case (int)ProductHungerEnum.Fish:
                                        product = new FishProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                    case (int)ProductHungerEnum.Meat:
                                        product = new MeatProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                    case (int)ProductHungerEnum.Bread:
                                        product = new BreadProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                }
                                break;
                            case (int)StatsEnum.Vigor:
                                Menu.ShowShopVigorMenu();
                                Menu.ShowYourChoice();
                                int vigorChoice = ClientTamagotchi.GetOptionChoice();
                                switch (vigorChoice)
                                {
                                    case (int)ProductVigorEnum.Coffee:
                                        product = new CoffeeProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                    case (int)ProductVigorEnum.EnergyDrink:
                                        product = new EnergyDrinkProduct();
                                        shop.BuyProduct(product, playerInventory);
                                        break;
                                }
                                break;
                            case (int)StatsEnum.Special:
                                Menu.ShowShopSpecialMenu();
                                Menu.ShowYourChoice();
                                int specialChoice = ClientTamagotchi.GetOptionChoice();
                                switch (specialChoice)
                                {
                                    case (int)ProductSpecialEnum.Mouse:
                                        special = new MouseProduct();
                                        shop.BuyProduct(special, playerInventory);
                                        break;
                                    case (int)ProductSpecialEnum.ForFlight:
                                        special = new ForFlightProduct();
                                        shop.BuyProduct(special, playerInventory);
                                        break;
                                }
                                break;
                            case (int)StatsEnum.Other:
                                Menu.ShowShopOtherMenu();
                                Menu.ShowYourChoice();
                                int otherChoice = ClientTamagotchi.GetOptionChoice();
                                switch (otherChoice)
                                {
                                    case (int)OtherEnum.NameChanger:
                                        other = new NameChanger();
                                        shop.BuyProduct(other, playerInventory);
                                        break;
                                }
                                break;
                        }
                        break;
                    case (int)OptionsEnum.Save:
                        Menu.Clear();
                        TamagotchiSaver.SaveGame(currentTamagotchi, playerInventory);
                        Menu.ShowGameSaved();
                        break;
                    case (int)OptionsEnum.Load:
                        currentTamagotchi = TamagotchiLoader.LoadGame(playerInventory, decreaseTimer, statsTimer, runAwayTimer);
                        //runAwayTimer.SetTamagotchi(currentTamagotchi);
                        Menu.Clear();
                        break;
                    case (int)OptionsEnum.Exit:
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}

