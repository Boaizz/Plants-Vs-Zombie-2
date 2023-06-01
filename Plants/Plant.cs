using System;
using CustomProgram.Zombies;

namespace CustomProgram.Plants
{
    public abstract class Plant : GameObject
    {
        private int _health;
        private Cell _cell;
        public Plant(string name, string filename) : base(name, filename)
        {
            _health = 100;
        }

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public Cell Cell
        {
            get
            {
                return _cell;
            }
            set
            {
                _cell = value;
            }
        }
        public int Row
        {
            get
            {
                return (int)Math.Ceiling((Y - 145) / 110);
            }
        }

        public abstract void BeAttacked(Zombie zombie);
    }
}
