using CustomProgram.Zombies;

namespace CustomProgram.Factory
{
    public class FactoryNormalZombie : ZombieFactory //concretecreator 
    {
        public Zombie GetZombie()
        {
            Zombie zombie = new NormalZombie();
            return zombie;
        }
    }
}
