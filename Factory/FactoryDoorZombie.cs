using CustomProgram.Zombies;

namespace CustomProgram.Factory
{
    public class FactoryDoorZombie : ZombieFactory //concretecreator 
    {
        public Zombie GetZombie()
        {
            Zombie zombie = new DoorZombie();
            return zombie;
        }
    }
}
