using Space_Invaders;
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
        private const int _projectileSpeed = 7;
        private bool _isShotFired = false; // Is player's shot still fired?
        private int soundStep = 1; 
        private int deathTimer = 0; // Death timer for alien explosion
        private int alienAnimation = 0; // Alien animation step


        public GameWindow() {
            InitializeComponent();
            player.Image = Image.FromFile("resources/textures/PlayerShip.png"); // Load player ship (dunno if necessary)
            playerProjectile.Image = Image.FromFile("resources/textures/PlayerProjectile.png");
            invaderTest.Image = Image.FromFile("resources/textures/Alien1_1.png"); // TEST IMAGE LOADING
            invaderTest.Visible = true;
        }

        private void debugButton_Click(object sender, EventArgs e) { // TEMPORARY BUTTON TO INCREASE ALIEN SPEED, NORMALLY DONE BY KILLING ALIENS
            speedMultiplier = speedMultiplier * 1.01; // When an alien dies, increase game speed by 1%
            ++buttonCount;
            debugCount.Text = $"{buttonCount}"; // TEMPORARY LABEL TO DISPLAY HOW MANY ALIENS HAVE BEEN KILLED, MAX IS 55 IN NORMAL GAME
        }

        private void alienSpeed_Tick(object sender, EventArgs e) { // Controls speed of aliens throughout the game
            gameTicks = Math.Round((gameTicks * speedMultiplier), 2);
            debugTimer.Text = $"{gameTicks}"; // TEMPORARY LABEL TO TRACK SPEED MULTIPLIER
            if (gameTicks >= 15) { // Move aliens forward after 15 ticks
                #region sound events
                if (soundStep == 1) {
                    var sp = new System.Windows.Media.MediaPlayer();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick1.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;
                }
                else if (soundStep == 2) {
                    var sp = new System.Windows.Media.MediaPlayer();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick2.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;

                }
                else if (soundStep == 3) {
                    var sp = new System.Windows.Media.MediaPlayer();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick3.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;
                }
                else if (soundStep == 4) {
                    var sp = new System.Windows.Media.MediaPlayer();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick4.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    soundStep = 1;
                }
                #endregion
                // Alien animations
                if (alienAnimation == 0 && invaderTest.Enabled == true) { // Change invaderTest.Enabled = true to check if alien is alive using Alien class 'state' when implemented
                    invaderTest.Image = Image.FromFile("resources/textures/Alien1_2.png");
                    ++alienAnimation;
                }
                else if (alienAnimation ==1 && invaderTest.Enabled == true) { // Change invaderTest.Enabled = true to check if alien is alive using Alien class 'state' when implemented
                    invaderTest.Image = Image.FromFile("resources/textures/Alien1_1.png");
                    --alienAnimation;
                }
                gameTicks = 0; // Reset counter to 0 for next alien movement
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
                    playerProjectile.Location = new Point(player.Location.X + (25), player.Location.Y);
                    playerProjectile.Visible = true;
                    // Play sound
                    var sp = new System.Windows.Media.MediaPlayer();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/playerShoot.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
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
            if (playerProjectile.Bounds.IntersectsWith(invaderTest.Bounds) && (invaderTest.Enabled = true)) { // Change invaderTest.Enabled = true to check if alien is alive using Alien class 'state' when implemented
                playerProjectile.Visible = false;
                invaderTest.Enabled = false;
                invaderTest.Image = Image.FromFile("resources/textures/AlienDeath.png");
                // Play sound
                var sp = new System.Windows.Media.MediaPlayer();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/alienDeath.wav");
                sp.Open(new System.Uri(path));
                sp.Play();
                // Starts timer to remove alien explosion
                alienDeath.Enabled = true;
            }
        }

        private void alienDeath_Tick(object sender, EventArgs e) { //Handles removing alien explosion after death
            ++deathTimer;
            if (deathTimer == 10) { // After 10 ticks, remove the explosion and reset the timer
                invaderTest.Image = Image.FromFile("resources/textures/Alien_Dead.png");
                alienDeath.Enabled = false;
                deathTimer = 0;
            }
        }
    }
}
