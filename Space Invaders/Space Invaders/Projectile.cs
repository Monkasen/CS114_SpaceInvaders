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
        private bool vis;
        private int xPos, yPos;
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

        public bool IsVisible()
        {
            return (vis);
        }

        public void SetVisibility(bool b)
        {
            vis = b;
        }

        public int GetPos(char dim) //gets the position of one dimension
        {
            if (dim == 'x')
                return (xPos);
            else
                return (yPos);
        }

        public void SetPos(int pos, char dim) //sets the position of one dimension
        {
            if (dim == 'x')
                xPos = pos;
            else
                yPos = pos;
        }
    }
}
