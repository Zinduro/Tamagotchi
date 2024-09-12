using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.Models.DecreasingStrategies;
using TamagotchiApp.Models.StatsShow;
using TamagotchiApp.Models.TamagotchiFactory;
using TamagotchiApp.Player;
using TamagotchiApp.UI;

namespace TamagotchiApp.Models.TamagotchiRun
{
    public class RunAwayTimer
    {
        private AbstractTamagotchi _tamagotchi;
        public RunAwayTimer(AbstractTamagotchi tamagotchi) 
        { 
            _tamagotchi = tamagotchi;
        }

        public void SetTamagotchi(AbstractTamagotchi tamagotchi)
        {
            _tamagotchi = tamagotchi;
        }

        public void Flag(object obj)
        {
            _tamagotchi.ShouldRunAway();
        }

        public AbstractTamagotchi TamagotchiCheck(TamagotchiCreator creator, DecreaseTimer decreaseTimer, StatsTimer statsTimer)
        {
            TimerCallback checkCallback = new TimerCallback(Flag);

            Timer checkTimer = new Timer(checkCallback, null, 0, 1000);
            PlayerInventory playerInventory = new PlayerInventory(_tamagotchi);

            if (_tamagotchi.RunAway == true)
            {
                Menu.ShowTamagotchiRunAway();
                Menu.ShowYourChoice();
                int choice = ClientTamagotchi.GetOptionChoice();
                if (choice == 1)
                {
                    playerInventory.ClearInventory();
                    if (decreaseTimer.GetType().GetEvents() == null)
                    {
                        decreaseTimer.Stop();
                    }
                    if (statsTimer.GetType().GetEvents() == null)
                    {
                        statsTimer.Stop();
                    }

                    Menu.ShowStartMenu();
                    Menu.ShowYourChoice();
                    creator = null;
                    int tamagotchiChoice;
                    do
                    {
                        tamagotchiChoice = ClientTamagotchi.GetTamagotchiChoice();

                        if (tamagotchiChoice == (int)TamagotchiEnum.Cat)
                        {
                            creator = new CatTamagotchiCreator();
                        }
                        else if (tamagotchiChoice == (int)TamagotchiEnum.Bird)
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
                    return currentTamagotchi;
                }
                else if (choice == 2)
                {
                    Environment.Exit(0);
                }
            }
            return null;
        }
    }
}
