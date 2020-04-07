using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders {
    class Projectile {
        private int type; // 0 = Alien, 1 = Player
        private Image projectileImage;
        public Projectile() {

        }

        public Projectile(int t, Image i) {
            type = t;
            projectileImage = i;
        }

        public void SetImage(Image i) {
            projectileImage = i;
        }

        public int GetProjectileType() {
            return type;
        }

        public Image GetImage() {
            return projectileImage;
        }

    }
}
