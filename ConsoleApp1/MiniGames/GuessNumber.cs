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
    public class GuessNumber
    {
        public static void StartGame(PlayerInventory playerInventory)
        {
            Random randomNumber = new Random();
            int goal = randomNumber.Next(1, 10);
            int numberOfTries = 7;

            for (int i = 0; i < numberOfTries; i++)
            {
                Menu.ShowInputNumber();
                int answer = ClientTamagotchi.GetOptionChoice();

                if (answer == goal)
                {
                    playerInventory.Coins += 20;
                    Menu.ShowRightNumber();
                    break;
                }
                else
                {
                    if (answer < goal)
                    {
                        Menu.ShowGreaterNumber();
                        continue;
                    }
                    else if (answer > goal)
                    {
                        Menu.ShowLessNumber();
                        continue;
                    }
                }
            }
        }
    }
}
