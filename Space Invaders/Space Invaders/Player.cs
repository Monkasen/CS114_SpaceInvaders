using System.Drawing;

namespace SpaceInvaders {
    public class Player {
        private bool isShoot; //holds whether player is currently shooting
        private int xPos; //holds x position of player
        private int yPos; //hold y position of player
        private int lives;

        public Player() {
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

        public int GetLives() {
            return (lives);
        }

        public void SetLives(int l) {
            lives = l;
        }

        public void LoseLife(){
            lives--;
        }
    }
}
