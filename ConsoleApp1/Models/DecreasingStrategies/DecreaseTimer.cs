using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TamagochiApp.Models;
using Timer = System.Threading.Timer;

namespace TamagotchiApp.Models.DecreasingStrategies
{
    public class DecreaseTimer
    {
        private IDecrease _strategy;
        private double _joy = 100;
        private double _hunger = 100;
        private double _vigor = 100;
        private double _special = 100;

        Timer joyTimer;
        Timer hungerTimer;
        Timer vigorTimer;
        Timer specialTimer;

        public DecreaseTimer(IDecrease strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IDecrease strategy)
        {
            _strategy = strategy;
        }

        private void DecreaseJoy(object obj)
        {
            _strategy.DecreaseJoy(_strategy.TamagotchiType);
        }

        private void DecreaseHunger(object obj)
        {
            _strategy.DecreaseHunger(_strategy.TamagotchiType);
        }

        private void DecreaseVigor(object obj)
        {
            _strategy.DecreaseVigor(_strategy.TamagotchiType);
        }

        private void DecreaseSpecial(object obj)
        {
            _strategy.DecreaseSpecial(_strategy.TamagotchiType);
        }

        private void IncreaseVigor(object obj)
        {
            _strategy.IncreaseVigor(_strategy.TamagotchiType);
        }

        public void DecreaseAllValues()
        {
            TimerCallback joyCallback = new TimerCallback(DecreaseJoy);
            TimerCallback hungerCallback = new TimerCallback(DecreaseHunger);
            TimerCallback vigorCallback = new TimerCallback(DecreaseVigor);
            TimerCallback specialCallback = new TimerCallback(DecreaseSpecial);

            joyTimer = new Timer(joyCallback, null, 0, _strategy.JoyDecreaseCooldown);
            hungerTimer = new Timer(hungerCallback, null, 0, _strategy.HungerDecreaseCooldown);
            vigorTimer = new Timer(vigorCallback, null, 0, _strategy.VigorDecreaseCooldown);
            specialTimer = new Timer(specialCallback, null, 0, _strategy.SpecialDecreaseCooldown);
        }

        public void DecreaseExceptVigor()
        {
            TimerCallback joyInSleepCallback = new TimerCallback(DecreaseJoy);
            TimerCallback hungerInSleepCallback = new TimerCallback(DecreaseHunger);
            TimerCallback vigorInSleepCallback = new TimerCallback(IncreaseVigor);
            TimerCallback specialInSleepCallback = new TimerCallback(DecreaseSpecial);

            joyTimer = new Timer(joyInSleepCallback, null, 0, (_strategy.JoyDecreaseCooldown) / 2);
            hungerTimer = new Timer(hungerInSleepCallback, null, 0, (_strategy.HungerDecreaseCooldown) / 2);
            vigorTimer = new Timer(vigorInSleepCallback, null, 0, (_strategy.VigorDecreaseCooldown) / 2);
            specialTimer = new Timer(specialInSleepCallback, null, 0, (_strategy.SpecialDecreaseCooldown) / 2);
        }

        public void Stop()
        {
            joyTimer.Change(Timeout.Infinite, Timeout.Infinite);
            hungerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            vigorTimer.Change(Timeout.Infinite, Timeout.Infinite);
            specialTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
