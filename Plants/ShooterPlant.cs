using System.Collections.Generic;
using CustomProgram.Bullets;
using CustomProgram.Zombies;

namespace CustomProgram.Plants
{
    public class ShooterPlant : Plant
    {
        private List<Bullet> _bulletpeas;
        private int _reloadTime;
        private bool _readytoShoot;

        public ShooterPlant(string name, string filename) : base(name, filename)
        {
            _bulletpeas = new List<Bullet>();
            _readytoShoot = false;
        }

        public override void BeAttacked(Zombie zombie)
        {
            Health -= zombie.Damage;
        }

        public virtual void Shoot()
        {
            ReloadTime = 0;
            IsReadyToShoot = false;
        }

        public void ReloadTimeTicks()
        {
            ReloadTime++;
        }

        public List<Bullet> BulletPeas
        {
            get
            {
                return _bulletpeas;
            }
        }

        public int ReloadTime
        {
            get
            {
                return _reloadTime;
            }
            set
            {
                _reloadTime = value;
            }
        }

        public bool IsReadyToShoot //check if the shooter plant is ready to shoot or not
        {
            get
            {
                return _readytoShoot;
            }
            set
            {
                _readytoShoot = value;
            }
        }
    }
}
