using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Shop.ProductEnum;
using TamagotchiApp.Shop.Products;
using TamagotchiApp.UI;

namespace TamagotchiApp.Player
{
    public class PlayerInventory
    {
        private int _coins = 100;
        public int Coins 
        { 
            get {  return _coins; } 
            set { _coins = value; }
        }

        private AbstractTamagotchi _tamagotchi;
        public AbstractTamagotchi Tamagotchi
        {
            get { return _tamagotchi; }
            set { _tamagotchi = value; }
        }

        private List<IProduct> _products = new List<IProduct>();
        private List<ISpecial> _specials = new List<ISpecial>();
        private List<IOther> _others = new List<IOther>();

        public PlayerInventory(AbstractTamagotchi tamagotchi) 
        {
            Tamagotchi = tamagotchi;
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }
        public void AddProduct(ISpecial special)
        {
            _specials.Add(special);
        }
        public void AddProduct(IOther other)
        {
            _others.Add(other);
        }

        public List<IProduct> GetProductList()
        {
            return _products;
        }

        public List<ISpecial> GetSpecialList()
        {
            return _specials;
        }

        public List<IOther> GetOtherList()
        {
            return _others;
        }

        public void ClearInventory()
        {
            _coins = 0;
            _products.Clear();
            _specials.Clear();
            _others.Clear();
        }

        public void UseIfInInventory(string name)
        {
            foreach (IProduct item in _products)
            {
                if (item.Name.ToLower().StartsWith(name.ToLower()))
                {
                    _products.Remove(item);
                    UseProduct(item, Tamagotchi);
                    return;
                }
            }
            foreach (ISpecial item in _specials)
            {
                if (item.Name.ToLower().StartsWith(name.ToLower()))
                {
                    _specials.Remove(item);
                    UseProduct(item, Tamagotchi);
                    return;
                }
            }
            foreach (IOther item in _others)
            {
                if (item.Name.ToLower().StartsWith(name.ToLower()))
                {
                    _others.Remove(item);
                    UseProduct(item, Tamagotchi);
                    return;
                }
            }

        }

        public void UseProduct(IProduct product, AbstractTamagotchi tamagotchi)
        {
           
            switch (product.Stat)
            {
                case StatsEnum.Joy:
                    Tamagotchi.Play(product);
                    break;
                case StatsEnum.Hunger:
                    Tamagotchi.Eat(product);
                    break;
                case StatsEnum.Vigor:
                    Tamagotchi.Sleep(product);
                    break;
                default:
                    break;
            }
            Menu.ShowStats(Tamagotchi);
        }

        public void UseProduct(ISpecial special, AbstractTamagotchi tamagotchi)
        {
            Tamagotchi = tamagotchi;
            Tamagotchi.SpecialStat(special);
            Menu.ShowStats(Tamagotchi);
        }

        public void UseProduct(IOther other,  AbstractTamagotchi tamagotchi)
        {
            other.PerformAction(tamagotchi);
        }
    }
}
