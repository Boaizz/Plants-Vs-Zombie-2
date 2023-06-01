using CustomProgram.Zombies;
using SplashKitSDK;

namespace CustomProgram.Factory
{

    public class ZombieFactoryCreator //this is using the ZombieFactory to create zombie.
    {
        private ZombieFactory _zombieFactory;
        public ZombieFactoryCreator()
        {

        }

        public Zombie CreateZombie(Timer timer)
        {

            if (SplashKit.TimerTicks(timer) >= 20000 && SplashKit.TimerTicks(timer) <= 40000)
            {
                if (SplashKit.Rnd(500) < 2)
                {
                    _zombieFactory = new FactoryNormalZombie();
                    return _zombieFactory.GetZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 40000 && SplashKit.TimerTicks(timer) <= 60000)
            {
                if (SplashKit.Rnd(700) < 2)
                {
                    _zombieFactory = new FactoryNormalZombie();
                    return _zombieFactory.GetZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 60000 && SplashKit.TimerTicks(timer) <= 80000)
            {
                if (SplashKit.Rnd(800) < 5)
                {
                    switch (SplashKit.Rnd(0, 2))
                    {
                        case 0:
                            _zombieFactory = new FactoryNormalZombie();
                            return _zombieFactory.GetZombie();
                        case 1:
                            _zombieFactory = new FactoryConeheadZombie();
                            return _zombieFactory.GetZombie();
                    }
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 80000 && SplashKit.TimerTicks(timer) <= 140000)
            {
                if (SplashKit.Rnd(800) < 7)
                {
                    return CreateRandomZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 140000 && SplashKit.TimerTicks(timer) <= 160000)
            {
                if (SplashKit.Rnd(800) < 8)
                {
                    return CreateRandomZombie();
                }
            }
            else if (SplashKit.TimerTicks(timer) >= 160000)
            {
                if (SplashKit.Rnd(800) < 9)
                {
                    _zombieFactory = new FactoryDoorZombie();
                    return _zombieFactory.GetZombie();
                }
            }
            return null;
        }

        private Zombie CreateRandomZombie()
        {
            ZombieFactory zombieFactory;
            switch (SplashKit.Rnd(0, 4))
            {
                case 0:
                    zombieFactory = new FactoryNormalZombie();
                    return zombieFactory.GetZombie();
                case 1:
                    zombieFactory = new FactoryConeheadZombie();
                    return zombieFactory.GetZombie();
                case 2:
                    zombieFactory = new FactoryBucketheadZombie();
                    return zombieFactory.GetZombie();
                case 3:
                    zombieFactory = new FactoryDoorZombie();
                    return zombieFactory.GetZombie();

            }
            return null;

        }
    }
}
