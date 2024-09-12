using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Game;
using TamagotchiApp.Player;
using TamagotchiApp.Shop.Products;
using static System.Net.Mime.MediaTypeNames;

namespace TamagotchiApp.Saver
{
    public class TamagotchiSaver
    {
        public static void SaveGame(AbstractTamagotchi tamagotchi, PlayerInventory playerInventory)
        {
            using (StreamWriter sw = File.CreateText(Program.Path))
            {
                sw.WriteLine(DateTime.Now);

                List<string> stats = tamagotchi.GetStringValues();

                sw.WriteLine(stats[0]); //Name
                sw.WriteLine(stats[1]); //TamagotchiType
                sw.WriteLine(stats[2]); //Joy
                sw.WriteLine(stats[3]); //Hunger
                sw.WriteLine(stats[4]); //Vigor
                sw.WriteLine(stats[5]); //Special

                sw.WriteLine(playerInventory.Coins);

                sw.WriteLine(playerInventory.GetProductList().Count());
                playerInventory.GetProductList().ForEach(product => sw.WriteLine(product.ProductType));
                sw.WriteLine(playerInventory.GetSpecialList().Count());
                playerInventory.GetSpecialList().ForEach(special => sw.WriteLine(special.ProductType));
                sw.WriteLine(playerInventory.GetOtherList().Count());
                playerInventory.GetOtherList().ForEach(special => sw.WriteLine(special.ProductType));
            }
        }
    }
}
