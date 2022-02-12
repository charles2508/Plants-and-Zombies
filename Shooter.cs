using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class Shooter : Item
    {
        private List<Pea> _shootingPea;
        private int _loadingTime; //This attribute checks whether a shooter has finished loading the pea or not
        private bool _canShoot;

        public Shooter(string name, string filename) : base(name,filename)
        {
            _shootingPea = new List<Pea>();
            _canShoot = false;
        }

        public override void BeAttacked(Zombie zombie)
        {
            this.Health -= zombie.Damage;
        }

        public virtual void Shoot()
        {
            LoadingTime = 0;
            CanShoot = false;
        }

        public void IncreaseLoadingTime()
        {
            LoadingTime++;
        }

        public List<Pea> ShootingPea
        {
            get
            {
                return _shootingPea;
            }
        }

        public int LoadingTime
        {
            get
            {
                return _loadingTime;
            }
            set
            {
                _loadingTime = value;
            }
        }

        public bool CanShoot
        {
            get
            {
                return _canShoot;
            }
            set
            {
                _canShoot = value;
            }
        }
    }
}
