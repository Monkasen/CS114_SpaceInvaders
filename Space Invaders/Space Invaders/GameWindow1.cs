using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input; // For key events

namespace SpaceInvaders {
    public partial class GameWindow : Form {
        double speedMultiplier = 1;
        double gameTicks = 1;
        int buttonCount = 1;
        private int rightSideDifference = 68;
        private int _projectileSpeed = 7;
        private bool _isShotFired = false; // Is player's shot still fired?


        public GameWindow() {
            InitializeComponent();
            player.Image = Image.FromFile("resources/textures/PlayerShip.png"); // Load player ship (dunno if necessary)
            playerProjectile.Image = Image.FromFile("resources/textures/PlayerProjectile.png");
        }

        private void debugButton_Click(object sender, EventArgs e) { // TEMPORARY BUTTON TO INCREASE ALIEN SPEED, NORMALLY DONE BY KILLING ALIENS
            speedMultiplier = speedMultiplier * 1.01;
            ++buttonCount;
            debugCount.Text = $"{buttonCount}"; // TEMPORARY LABEL TO DISPLAY HOW MANY ALIENS HAVE BEEN KILLED, MAX IS 55 IN NORMAL GAME
            invaderTest.Image = Image.FromFile("resources/textures/Alien1_1.png"); // TEST IMAGE LOADING
            invaderTest.Visible = true;
        }

        private void alienSpeed_Tick(object sender, EventArgs e) {
            gameTicks = Math.Round((gameTicks * speedMultiplier), 2);
            debugTimer.Text = $"{gameTicks}"; // TEMPORARY LABEL TO TRACK SPEED MULTIPLIER
            if (gameTicks >= 50) {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/quack.wav");
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(path);
                sp.Play();
                gameTicks = 0;
            }
            ++gameTicks;
        }

        // Timer will handle all input from the user
        private void playerMovement_Tick(object sender, EventArgs e)
        {
            debugXLocation.Text = player.Location.X.ToString(); // TEMPORARY LABEL TO DISPLAY PLAYER'S X LOCATION

            if (Keyboard.IsKeyDown(Key.Left)) // Move left
            {
                if (player.Location.X > 0)
                    player.Location = new Point(player.Location.X - 2, player.Location.Y);
            }
            else if (Keyboard.IsKeyDown(Key.Right)) // Move right
            {
                if (player.Location.X < this.Width - rightSideDifference) // Calculate current width in case we change this in the future
                    player.Location = new Point(player.Location.X + 2, player.Location.Y);
            }
            if (Keyboard.IsKeyDown(Key.Up)) // Shoot
            {
                if (!_isShotFired)
                {
                    _isShotFired = true;
                    playerProjectile.Location = new Point(player.Location.X + (52 / 2), player.Location.Y);
                    playerProjectile.Visible = true;
                }
            }

            if (!_isShotFired) return;
            playerProjectile.Location = new Point(playerProjectile.Location.X, playerProjectile.Location.Y - _projectileSpeed);
            _isShotFired = ProjectileEvent();
        }

        private bool ProjectileEvent() // Checks if either projectile collides with an invader (not implemented) or out of bounds
        {
            if (playerProjectile.Location.Y < 0)
            {
                playerProjectile.Visible = false;
                return false;
            }
            return true;
        }

        private void projectileCollision_Tick(object sender, EventArgs e)
        {
            // Nothing here yet
            // Should projectile tracking be in here too?
        }
    }
}
