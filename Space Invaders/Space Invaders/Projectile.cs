using System.Drawing;

namespace SpaceInvaders {
    class Projectile {
        private int type; // 0 = Alien, 1 = Player
        private Image projectileImage;
        private bool vis;
        private int xPos, yPos;
        public Projectile(int t) {
            type = t;
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

        public bool IsVisible() {
            return (vis);
        }

        public bool SetVisibility() {
            if (vis) {
                vis = false;
                return vis;
            }
            else {
                vis = true;
                return vis;
            }
        }

        public int GetPos(char dim) { // Gets the position of one dimension
            if (dim == 'x')
                return (xPos);
            else
                return (yPos);
        }

        public void SetPos(int pos, char dim) { // Sets the position of one dimension
            if (dim == 'x')
                xPos = pos;
            else
                yPos = pos;
        }
    }
}
