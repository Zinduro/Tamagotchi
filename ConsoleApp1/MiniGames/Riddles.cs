using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TamagotchiApp.Models;
using TamagotchiApp.Player;
using TamagotchiApp.UI;

namespace TamagotchiApp.MiniGames
{
    public class Riddles
    { 
       public static void StartGame(PlayerInventory playerInventory)
       {
            Random random = new Random();
            
            Dictionary<string, string> riddleMap = [];

            riddleMap.Add("Речка спятила с ума - по домам пошла сама", "Водопровод");
            riddleMap.Add("Музыкант, певец, рассказчик - а всего труба да ящик", "Граммофон");
            riddleMap.Add("На раскрашенных страницах много праздников хранится", "Календарь");
            riddleMap.Add("Ах, не трогайте меня: обожгу и без огня!", "Крапива");
            riddleMap.Add("Маленькие домики по улице бегут, мальчиков и девочек домики везут", "Машины");

            int count = 5;

            for (int i = 0; i < count; i++)
            {
                var currentRiddle = riddleMap.First();

                Menu.ShowString(currentRiddle.Key);
                string answer = ClientTamagotchi.GetStringInputChoice();

                if (currentRiddle.Value.ToLower() == answer.ToLower())
                {
                    playerInventory.Coins += 10;
                    Menu.ShowGoodAnswer();
                    riddleMap.Remove(currentRiddle.Key);
                }
                else
                {
                    Menu.ShowBadAnswer();
                    riddleMap.Remove(currentRiddle.Key);
                }
            }
       }   
    }
}
