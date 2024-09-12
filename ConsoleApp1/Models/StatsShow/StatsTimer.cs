using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiApp.Models;
using TamagotchiApp.UI;

namespace TamagotchiApp.Models.StatsShow
{
    public class StatsTimer
    {
        private Timer statsTimer;
        private AbstractTamagotchi _tamagotchi;
        public AbstractTamagotchi Tamagotchi
        {
            get { return _tamagotchi; }
            set { _tamagotchi = value; }
        }

        public StatsTimer(AbstractTamagotchi tamagotchi)
        {
            Tamagotchi = tamagotchi;
        }

        private void Stats(object obj)
        {
            Menu.Clear();
            Menu.ShowWakeUpHint();
            Menu.ShowStats(_tamagotchi);
        }

        public void ShowStats()
        {
            TimerCallback statsCallback = new TimerCallback(Stats);

            statsTimer = new Timer(statsCallback, null, 0, 1000);
        }

        public void Stop()
        {
            statsTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
