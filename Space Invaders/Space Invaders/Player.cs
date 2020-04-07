using System.Drawing;

namespace SpaceInvaders {
    public class Player {
        private int state = 1; // 1 = alive, 0 = dead
        private Image playerImage;
        private bool isShoot; //holds whether player is currently shooting
        private int xPos; //holds x position of player
        private int yPos; //hold y position of player

        public Player() {
        }

        public Player(Point dPosition) { // Sets default position
            xPos = dPosition.X;
            yPos = dPosition.Y;
        }

        public void SetImage(Image i) { // Sets current sprite of player
            playerImage = i;
        }

        public void SetState(int s) { // Sets dead or alive state
            if (s == 0) {
                state = s;
            }
        }

        public bool IsFired() { // Checks if the player has an active projectile
            return (isShoot);
        }

        public void Fire(bool fireState) { // Fires a projectile
            isShoot = fireState;
        }

        public int GetPos(char dim) { // Gets the position of one dimension
            if (dim == 'x')
                return (xPos);
            else
                return (yPos);
        }

        public void SetPos(Point pos) {  // Sets the position of one dimension
            xPos = pos.X;
            yPos = pos.Y;
        }
    }
}
