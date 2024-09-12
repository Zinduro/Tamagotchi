using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Models;
using TamagotchiApp.Shop.ProductEnum;
using TamagotchiApp.UI;

namespace TamagotchiApp.Shop.Products.Name
{
    public class NameChanger : IOther
    {
        private string _productType = "NameChanger";
        public string ProductType { get { return _productType; } }

        private static string _name = "Смена имени";
        public string Name
        {
            get { return _name; }
        }

        private static int _price = 30;
        public int Price
        {
            get { return _price; }
        }

        public void PerformAction(AbstractTamagotchi tamagotchi)
        {
            Menu.Clear();
            Menu.ShowNameChoice();
            string newName = ClientTamagotchi.GetTamagotchiNameChoice();

            tamagotchi.Name = newName;
        }
    }
}
