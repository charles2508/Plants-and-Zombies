using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public enum ZombieType
    {
        Normal,
        Conehead,
        Buckethead
    }
    public class ZombieFactory
    {
        private Dictionary<ZombieType, Type> _zombieTypes;
        public ZombieFactory() 
        {
            _zombieTypes = new Dictionary<ZombieType, Type>();
        }

        public void RegisterZombie(ZombieType zombieType, Type typeOfZombie)
        {
            _zombieTypes.Add(zombieType, typeOfZombie);
        }

        public Zombie CreateZombie(int remainingZombies, Timer timer)
        {
            if (SplashKit.TimerTicks(timer) >= 20000 && SplashKit.TimerTicks(timer) <= 40000)
            {
                if (SplashKit.Rnd(500) == 1 && remainingZombies > 48)
                {
                    return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Normal]);
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 40000 && SplashKit.TimerTicks(timer) <= 60000)
            {
                if (SplashKit.Rnd(700) < 2 && remainingZombies >= 44)
                {
                    return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Normal]);
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 60000 && SplashKit.TimerTicks(timer) <= 90000)
            {
                if (SplashKit.Rnd(800) < 5 && remainingZombies >= 36)
                {
                    switch (SplashKit.Rnd(0, 2))
                    {
                        case 0:
                            return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Normal]);
                        case 1:
                            return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Conehead]);
                    }
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 90000 && SplashKit.TimerTicks(timer) <= 135000)
            {
                if (SplashKit.Rnd(1000) < 7 && remainingZombies >= 25)
                {
                    return CreateRandomZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 135000 && SplashKit.TimerTicks(timer) <= 160000)
            {
                if (SplashKit.Rnd(900) < 8 && remainingZombies >= 10)
                {
                    return CreateRandomZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 160000)
            {
                if (SplashKit.Rnd(800) < 9)
                {
                    return CreateRandomZombie();
                }
            }
            return null;
        }

        private Zombie CreateRandomZombie()
        {
            switch (SplashKit.Rnd(0, 3))
            {
                case 0:
                    return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Normal]);
                case 1:
                    return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Buckethead]);
                case 2:
                    return (Zombie)Activator.CreateInstance(_zombieTypes[ZombieType.Conehead]);
            }
            return null;
        }
    }
}
