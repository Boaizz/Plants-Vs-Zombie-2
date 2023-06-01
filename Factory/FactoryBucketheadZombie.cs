using CustomProgram.Zombies;

namespace CustomProgram.Factory
{
    public class FactoryBucketheadZombie : ZombieFactory //concretecreator 
    {
        public Zombie GetZombie()
        {
            Zombie zombie = new BucketheadZombie();
            return zombie;
        }
    }
}
