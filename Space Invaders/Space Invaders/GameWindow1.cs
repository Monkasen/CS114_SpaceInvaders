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
        private List<Alien> AlienList = new List<Alien>();

        public GameWindow() {
            InitializeComponent();
            InitializeAliens(); // Set alien images and add list members
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

        // Method will initialize aliens for use, brute force crap
        private void InitializeAliens()
        {
            // Load top row alien images
            pbAlien1.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien2.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien3.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien4.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien5.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien6.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien7.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien8.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien9.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien10.Image = Image.FromFile("resources/textures/Alien3_1.png");
            pbAlien11.Image = Image.FromFile("resources/textures/Alien3_1.png");

            // Load second from top and middle row alien images
            pbAlien12.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien13.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien14.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien15.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien16.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien17.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien18.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien19.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien20.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien21.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien22.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien23.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien24.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien25.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien26.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien27.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien28.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien29.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien30.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien31.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien32.Image = Image.FromFile("resources/textures/Alien2_1.png");
            pbAlien33.Image = Image.FromFile("resources/textures/Alien2_1.png");

            // Load bottom two row alien images
            pbAlien34.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien35.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien36.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien37.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien38.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien39.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien40.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien41.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien42.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien43.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien44.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien45.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien46.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien47.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien48.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien49.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien50.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien51.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien52.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien53.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien54.Image = Image.FromFile("resources/textures/Alien1_1.png");
            pbAlien55.Image = Image.FromFile("resources/textures/Alien1_1.png");

            // Create list of aliens (get ready for this mess)
            // Create Alien objects
            Alien alien1 = new Alien();
            Alien alien2 = new Alien();
            Alien alien3 = new Alien();
            Alien alien4 = new Alien();
            Alien alien5 = new Alien();
            Alien alien6 = new Alien();
            Alien alien7 = new Alien();
            Alien alien8 = new Alien();
            Alien alien9 = new Alien();
            Alien alien10 = new Alien();
            Alien alien11 = new Alien();
            Alien alien12 = new Alien();
            Alien alien13 = new Alien();
            Alien alien14 = new Alien();
            Alien alien15 = new Alien();
            Alien alien16 = new Alien();
            Alien alien17 = new Alien();
            Alien alien18 = new Alien();
            Alien alien19 = new Alien();
            Alien alien20 = new Alien();
            Alien alien21 = new Alien();
            Alien alien22 = new Alien();
            Alien alien23 = new Alien();
            Alien alien24 = new Alien();
            Alien alien25 = new Alien();
            Alien alien26 = new Alien();
            Alien alien27 = new Alien();
            Alien alien28 = new Alien();
            Alien alien29 = new Alien();
            Alien alien30 = new Alien();
            Alien alien31 = new Alien();
            Alien alien32 = new Alien();
            Alien alien33 = new Alien();
            Alien alien34 = new Alien();
            Alien alien35 = new Alien();
            Alien alien36 = new Alien();
            Alien alien37 = new Alien();
            Alien alien38 = new Alien();
            Alien alien39 = new Alien();
            Alien alien40 = new Alien();
            Alien alien41 = new Alien();
            Alien alien42 = new Alien();
            Alien alien43 = new Alien();
            Alien alien44 = new Alien();
            Alien alien45 = new Alien();
            Alien alien46 = new Alien();
            Alien alien47 = new Alien();
            Alien alien48 = new Alien();
            Alien alien49 = new Alien();
            Alien alien50 = new Alien();
            Alien alien51 = new Alien();
            Alien alien52 = new Alien();
            Alien alien53 = new Alien();
            Alien alien54 = new Alien();
            Alien alien55 = new Alien();

            // Add Alien objects to list
            AlienList.Add(alien1);
            AlienList.Add(alien2);
            AlienList.Add(alien3);
            AlienList.Add(alien4);
            AlienList.Add(alien5);
            AlienList.Add(alien6);
            AlienList.Add(alien7);
            AlienList.Add(alien8);
            AlienList.Add(alien9);
            AlienList.Add(alien10);
            AlienList.Add(alien11);
            AlienList.Add(alien12);
            AlienList.Add(alien13);
            AlienList.Add(alien14);
            AlienList.Add(alien15);
            AlienList.Add(alien16);
            AlienList.Add(alien17);
            AlienList.Add(alien18);
            AlienList.Add(alien19);
            AlienList.Add(alien20);
            AlienList.Add(alien21);
            AlienList.Add(alien22);
            AlienList.Add(alien23);
            AlienList.Add(alien24);
            AlienList.Add(alien25);
            AlienList.Add(alien26);
            AlienList.Add(alien27);
            AlienList.Add(alien28);
            AlienList.Add(alien29);
            AlienList.Add(alien30);
            AlienList.Add(alien31);
            AlienList.Add(alien32);
            AlienList.Add(alien33);
            AlienList.Add(alien34);
            AlienList.Add(alien35);
            AlienList.Add(alien36);
            AlienList.Add(alien37);
            AlienList.Add(alien38);
            AlienList.Add(alien39);
            AlienList.Add(alien40);
            AlienList.Add(alien41);
            AlienList.Add(alien42);
            AlienList.Add(alien43);
            AlienList.Add(alien44);
            AlienList.Add(alien45);
            AlienList.Add(alien46);
            AlienList.Add(alien47);
            AlienList.Add(alien48);
            AlienList.Add(alien49);
            AlienList.Add(alien50);
            AlienList.Add(alien51);
            AlienList.Add(alien52);
            AlienList.Add(alien53);
            AlienList.Add(alien54);
            AlienList.Add(alien55);
        } // this method sucks
    }
}
