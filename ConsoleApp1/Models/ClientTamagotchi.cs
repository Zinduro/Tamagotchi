using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Models.StatsShow;
using TamagotchiApp.Models.TamagotchiFactory;
using TamagotchiApp.Models.TamagotchiRun;
using TamagotchiApp.UI;

namespace TamagotchiApp.Models
{
    public class ClientTamagotchi
    {
        public static int GetTamagotchiChoice()
        {
            int tamagotchiChoice = Convert.ToInt32(Console.ReadLine());

            return tamagotchiChoice;
        }

        public static string GetTamagotchiNameChoice()
        {
            string name = Console.ReadLine();

            return name;
        }

        public static int GetOptionChoice()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static AbstractTamagotchi CreateTamagotchi(TamagotchiCreator creator, string name)
        {
            AbstractTamagotchi tamagotchi = creator.CreateTamagotchi(name);
            return tamagotchi;
        }
        public static AbstractTamagotchi CreateTamagotchi(TamagotchiCreator creator, string name, int joy, int hunger, int vigor, int special)
        {
            AbstractTamagotchi tamagotchi = creator.CreateTamagotchi(name, joy, hunger, vigor, special);
            return tamagotchi;
        }

        public static string GetStringInputChoice()
        {
            return Console.ReadLine();
        }
    }
}
