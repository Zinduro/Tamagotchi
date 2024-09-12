using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Player;
using TamagotchiApp.Shop.ProductEnum;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.UI;

namespace TamagotchiApp.Shop
{
    public class ShopLogic
    {
        private IProduct _product;
        public IProduct Product 
        { 
            get { return _product; } 
            set { _product = value; }
        }

        private ISpecial _special;
        public ISpecial Special
        {
            get { return _special; }
            set { _special = value; }
        }

        private AbstractTamagotchi _tamagotchi;
        public AbstractTamagotchi Tamagotchi
        {
            get { return _tamagotchi; }
            set { _tamagotchi = value; }
        }

        public void BuyProduct(IProduct product, PlayerInventory playerInventory)
        {
            int price = product.Price;
            int playerCoins = playerInventory.Coins;

            if (price < playerCoins)
            {
                playerInventory.AddProduct(product);
                playerInventory.Coins -= price;
            }
            else
            {
                Menu.ShowNotEnoughCoins();
            }
        }
        public void BuyProduct(ISpecial special, PlayerInventory playerInventory)
        {
            int price = special.Price;
            int playerCoins = playerInventory.Coins;

            if (price < playerCoins)
            {
                playerInventory.AddProduct(special);
                playerInventory.Coins -= price;
            }
            else
            {
                Menu.ShowNotEnoughCoins();
            }
        }
        public void BuyProduct(IOther other, PlayerInventory playerInventory)
        {
            int price = other.Price;
            int playerCoins = playerInventory.Coins;

            if (price < playerCoins)
            {
                playerInventory.AddProduct(other);
                playerInventory.Coins -= price;
            }
            else
            {
                Menu.ShowNotEnoughCoins();
            }
        }
    }
}
