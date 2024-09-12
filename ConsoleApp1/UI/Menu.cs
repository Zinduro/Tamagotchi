using System.Net.NetworkInformation;
using TamagochiApp.Models;
using TamagotchiApp.Player;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.Shop.Products.Hunger;
using TamagotchiApp.Shop.Products.Joy;
using TamagotchiApp.Shop.Products.Name;
using TamagotchiApp.Shop.Products.Special;
using TamagotchiApp.Shop.Products.Vigor;

namespace TamagotchiApp.UI
{
    public class Menu
    {
        public static void ShowStartMenu() 
        {
            CatTamagotchi cat = new CatTamagotchi("default");
            BirdTamagotchi bird = new BirdTamagotchi("default");

            Console.WriteLine("Выберите своего питомца: ");
            Console.WriteLine("1. " + cat.TypeRussian());
            Console.WriteLine("2. " + bird.TypeRussian() + "\n");
        }

        public static void ShowYourChoice()
        {
            Console.WriteLine("Ваш выбор: ");
        }

        public static void ShowInvalidChoice()
        {
            Console.WriteLine("Введено недопустимое значение!\n");
        }

        public static void ShowNameChoice()
        {
            Console.WriteLine("Как бы вы хотели назвать своего питомца?");
        }

        public static void ShowGreetings(AbstractTamagotchi tamagotchi)
        {
            Console.WriteLine("Что за чудный зверёк! Это же " + tamagotchi.TypeRussian() + " по имени " + tamagotchi.GetStringValues().First() + "!");
            Console.WriteLine("Чтобы ваш питомец чувствовал себя хорошо, вам нужно удовлетворять его потребности. И не забывайте делать это вовремя!\n");
        }

        public static void ShowStats(AbstractTamagotchi tamagotchi)
        {
            List<string> stats = tamagotchi.GetStringValues();
            Console.WriteLine("Имя тамагочи - " + stats[0]);
            Console.WriteLine("Радость - " + stats[2]);
            Console.WriteLine("Голод - " + stats[3]);
            Console.WriteLine("Бодрость - " + stats[4]);
            Console.WriteLine("Особая потребность - " + stats[5] + "\n");
            Console.WriteLine("Тип тамагочи - " + stats[6] + "\n");
        }

        public static void ShowOptions()
        {
            Console.WriteLine("Выберите, как вы хотите провести время с вашим питомцем: ");
            Console.WriteLine("1. Проверить инвентарь.");
            Console.WriteLine("2. Уложить спать.");
            Console.WriteLine("3. Проверить потребности.");
            Console.WriteLine("4. Поиграть в мини-игры.");
            Console.WriteLine("5. Открыть магазин.");
            Console.WriteLine("6. Сохранить игру.");
            Console.WriteLine("7. Загрузить игру.");
            Console.WriteLine("0. Выйти.\n");
        }

        public static void ShowInventory(PlayerInventory playerInventory)
        {
            List<IProduct> products = playerInventory.GetProductList();
            List<ISpecial> specials = playerInventory.GetSpecialList();
            List<IOther> others = playerInventory.GetOtherList();
            Console.WriteLine("\nВот список ваших предметов:");
            Console.WriteLine("Обычные предметы.");
            products.ForEach(product => Console.WriteLine("\t" + product.Name));
            Console.WriteLine("\nПредметы для особых потребностей:");
            specials.ForEach(special => Console.WriteLine("\t" + special.Name));
            Console.WriteLine("\nДругие предметы:");
            others.ForEach(other => Console.WriteLine("\t" + other.Name));
            Console.WriteLine("\nВаш баланс - " + playerInventory.Coins + "\n");
        }

        public static void ShowChooseToUseItem()
        {
            Console.WriteLine("Хотите использовать предмет?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет\n");
        }

        public static void ShowChooseInventoryItem()
        {
            Console.WriteLine("Введите название предмета, который хотите использовать (можно написать лишь начало, которое поможет понять, что это за предмет):");
        }

        public static void ShowNotEnoughCoins()
        {
            Console.WriteLine("Похожу, у вас недостаточно денег для покупки. Попробуйте поиграть в мини-игры, чтобы заработать их!");
        }

        public static void ShowWakeUpHint()
        {
            Console.WriteLine("Нажмите '1', чтобы разбудить тамагочи...");
        }

        public static void ShowShopMenu()
        {
            Console.WriteLine("Добро пожаловать в магазин! Выберите необходимую категорию товара.");
            Console.WriteLine("1. Игрушки.");
            Console.WriteLine("2. Еда.");
            Console.WriteLine("3. Бодрость.");
            Console.WriteLine("4. Особые товары.");
            Console.WriteLine("5. Другие товары.");
        }

        public static void ShowShopJoyMenu()
        {
            BallProduct ball = new BallProduct();
            TeddyBearProduct teddy = new TeddyBearProduct();
            Console.WriteLine("Раздел с игрушками. Что хотите купить?");
            Console.WriteLine("1. " + ball.Name + ". Цена - " + ball.Price + ". Сила - " + ball.Power + ".");
            Console.WriteLine("2. " + teddy.Name + ". Цена - " + teddy.Price + ". Сила - " + teddy.Power + ".");
        }

        public static void ShowShopHungerMenu()
        {
            FishProduct fish = new FishProduct();
            MeatProduct meat = new MeatProduct();
            BreadProduct bread = new BreadProduct();
            Console.WriteLine("Раздел с едой. Что хотите купить?");
            Console.WriteLine("1. " + fish.Name + ". Цена - " + fish.Price + ". Сила - " + fish.Power + ".");
            Console.WriteLine("2. " + meat.Name + ". Цена - " + meat.Price + ". Сила - " + meat.Power + ".");
            Console.WriteLine("3. " + bread.Name + ". Цена - " + bread.Price + ". Сила - " + bread.Power + ".");
        }

        public static void ShowShopVigorMenu()
        {
            CoffeeProduct coffee = new CoffeeProduct();
            EnergyDrinkProduct energyDrink = new EnergyDrinkProduct();
            Console.WriteLine("Раздел со средствами от усталости. Что хотите купить?");
            Console.WriteLine("1. " + coffee.Name + ". Цена - " + coffee.Price + ". Сила - " + coffee.Power + ".");
            Console.WriteLine("2. " + energyDrink.Name + ". Цена - " + energyDrink.Price + ". Сила - " + energyDrink.Power + ".");
        }

        public static void ShowShopSpecialMenu()
        {
            MouseProduct mouse = new MouseProduct();
            ForFlightProduct forFlight = new ForFlightProduct();
            Console.WriteLine("Раздел с особенными товарами. Что хотите купить?");
            Console.WriteLine("1. " + mouse.Name + ". Цена - " + mouse.Price + ". Сила - " + mouse.Power + ". Тип питомца - " + mouse.TamagotchiType );
            Console.WriteLine("2. " + forFlight.Name + ". Цена - " + forFlight.Price + ". Сила - " + forFlight.Power + ".");
        }

        public static void ShowShopOtherMenu()
        {
            NameChanger nameChanger = new NameChanger();
            Console.WriteLine("Раздел с другими товарами. Что хотите купить?");
            Console.WriteLine("1. " + nameChanger.Name + ". Цена - " + nameChanger.Price + ".");

        }

        public static void ShowInvalidSpecialProduct()
        {
            Console.WriteLine("Этот продукт не подходит для вашего питомца! Выберите другой.");
        }

        public static void ShowMiniGameMenu()
        {
            Console.WriteLine("Раздел с мини-играми. Выберите желаемую:");
            Console.WriteLine("1. Загадки.");
            Console.WriteLine("2. Угадай число");
            Console.WriteLine("3. Путаница");
        }

        public static void ShowRiddlesRules()
        {
            Console.WriteLine("Попробуйте разгадать загадки!");
        }

        public static void ShowGuessNumberRules()
        {
            Console.WriteLine("У вас 7 попыток, чтобы угадать моё число (от 1 до 100)!");
        }

        public static void ShowInputNumber()
        {
            Console.WriteLine("Введите ваше число:");
        }

        public static void ShowGreaterNumber()
        {
            Console.WriteLine("Моё число больше!");
        }

        public static void ShowLessNumber()
        {
            Console.WriteLine("Моё число меньше!");
        }

        public static void ShowRightNumber()
        {
            Console.WriteLine("Вы угадали!");
        }

        public static void ShowWrongNumber()
        {
            Console.WriteLine("Попробуйте ещё раз!");
        }

        public static void ShowShuffleRules()
        {
            Console.WriteLine("Восстановите первоначальное слово в этой путанице!");
        }

        public static void ShowString(string input)
        {
            Console.WriteLine(input);
        }

        public static void ShowTamagotchiRunAway()
        {
            Console.WriteLine("Похоже, вы не уследили за питомцем! Он убежал и забрал с собой все вещи из инвентаря! Желаете завести нового?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
        }

        public static void ShowGameSaved()
        {
            Console.WriteLine("Игра успешно сохранена!\n");
        }

        public static void ShowGoodAnswer()
        {
            Console.WriteLine("\nВерный ответ!");
        }
        
        public static void ShowBadAnswer()
        {
            Console.WriteLine("\nОтвет неправильный :(");
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
