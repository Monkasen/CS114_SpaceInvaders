using System.Drawing;
using System.Security;

namespace SpaceInvaders {
    class Projectile {
        private int type; // 0 = Alien, 1 = Player
        private bool vis;
        private int xPos, yPos;

        public Projectile(int t) {
            type = t;
        }

        public bool SetVisibility(bool b) {
            vis = b;
            return vis;
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
