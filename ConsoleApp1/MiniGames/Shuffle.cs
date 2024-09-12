using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models;
using TamagotchiApp.Player;
using TamagotchiApp.UI;

namespace TamagotchiApp.MiniGames
{
    public class Shuffle
    {
        

        public static void StartGame(PlayerInventory playerInventory)
        {
            List<string> stringsToShuffle = ["зимушка", "электрик", "пистолет", "тамагочи", "фоторамка"];

            int count = 5;

            for (int i = 0; i < count; i++)
            {
                Span<char> random = ShuffleString(stringsToShuffle[i]);
                Menu.ShowString(random.ToString());

                string answer = ClientTamagotchi.GetStringInputChoice();

                if (answer == stringsToShuffle[i])
                {
                    playerInventory.Coins += 15;
                    Menu.ShowGoodAnswer();
                }
                else
                {
                    Menu.ShowBadAnswer();
                }
            }
        }

        private static Span<char> ShuffleString(string input)
        {
            Random r = new Random();
            Span<char> spanInput = new Span<char>(input.ToCharArray());
            Random.Shared.Shuffle(spanInput);

            return spanInput;
        }
    }
}
