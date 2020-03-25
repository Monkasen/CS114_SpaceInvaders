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
        private List<System.Windows.Forms.PictureBox> AlienPBList = new List<PictureBox>();

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
                AlienAnimation(); // Handles animations for alien movement
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
                invaderTest.Enabled = false;
                alienDeath.Enabled = false;
                deathTimer = 0;
            }
        }

        // Method will initialize aliens for use, brute force it broski
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

            // Create Alien objects
            Alien alien1 = new Alien(3, pbAlien1.Image);
            Alien alien2 = new Alien(3, pbAlien2.Image);
            Alien alien3 = new Alien(3, pbAlien3.Image);
            Alien alien4 = new Alien(3, pbAlien4.Image);
            Alien alien5 = new Alien(3, pbAlien5.Image);
            Alien alien6 = new Alien(3, pbAlien6.Image);
            Alien alien7 = new Alien(3, pbAlien7.Image);
            Alien alien8 = new Alien(3, pbAlien8.Image);
            Alien alien9 = new Alien(3, pbAlien9.Image);
            Alien alien10 = new Alien(3, pbAlien10.Image);
            Alien alien11 = new Alien(3, pbAlien11.Image);
            Alien alien12 = new Alien(2, pbAlien12.Image);
            Alien alien13 = new Alien(2, pbAlien13.Image);
            Alien alien14 = new Alien(2, pbAlien14.Image);
            Alien alien15 = new Alien(2, pbAlien15.Image);
            Alien alien16 = new Alien(2, pbAlien16.Image);
            Alien alien17 = new Alien(2, pbAlien17.Image);
            Alien alien18 = new Alien(2, pbAlien18.Image);
            Alien alien19 = new Alien(2, pbAlien19.Image);
            Alien alien20 = new Alien(2, pbAlien20.Image);
            Alien alien21 = new Alien(2, pbAlien21.Image);
            Alien alien22 = new Alien(2, pbAlien22.Image);
            Alien alien23 = new Alien(2, pbAlien23.Image);
            Alien alien24 = new Alien(2, pbAlien24.Image);
            Alien alien25 = new Alien(2, pbAlien25.Image);
            Alien alien26 = new Alien(2, pbAlien26.Image);
            Alien alien27 = new Alien(2, pbAlien27.Image);
            Alien alien28 = new Alien(2, pbAlien28.Image);
            Alien alien29 = new Alien(2, pbAlien29.Image);
            Alien alien30 = new Alien(2, pbAlien30.Image);
            Alien alien31 = new Alien(2, pbAlien31.Image);
            Alien alien32 = new Alien(2, pbAlien32.Image);
            Alien alien33 = new Alien(2, pbAlien33.Image);
            Alien alien34 = new Alien(1, pbAlien34.Image);
            Alien alien35 = new Alien(1, pbAlien35.Image);
            Alien alien36 = new Alien(1, pbAlien36.Image);
            Alien alien37 = new Alien(1, pbAlien37.Image);
            Alien alien38 = new Alien(1, pbAlien38.Image);
            Alien alien39 = new Alien(1, pbAlien39.Image);
            Alien alien40 = new Alien(1, pbAlien40.Image);
            Alien alien41 = new Alien(1, pbAlien41.Image);
            Alien alien42 = new Alien(1, pbAlien42.Image);
            Alien alien43 = new Alien(1, pbAlien43.Image);
            Alien alien44 = new Alien(1, pbAlien44.Image);
            Alien alien45 = new Alien(1, pbAlien45.Image);
            Alien alien46 = new Alien(1, pbAlien46.Image);
            Alien alien47 = new Alien(1, pbAlien47.Image);
            Alien alien48 = new Alien(1, pbAlien48.Image);
            Alien alien49 = new Alien(1, pbAlien49.Image);
            Alien alien50 = new Alien(1, pbAlien50.Image);
            Alien alien51 = new Alien(1, pbAlien51.Image);
            Alien alien52 = new Alien(1, pbAlien52.Image);
            Alien alien53 = new Alien(1, pbAlien53.Image);
            Alien alien54 = new Alien(1, pbAlien54.Image);
            Alien alien55 = new Alien(1, pbAlien55.Image);

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

            // Add pictureboxes
            AlienPBList.Add(pbAlien1);
            AlienPBList.Add(pbAlien2);
            AlienPBList.Add(pbAlien3);
            AlienPBList.Add(pbAlien4);
            AlienPBList.Add(pbAlien5);
            AlienPBList.Add(pbAlien6);
            AlienPBList.Add(pbAlien7);
            AlienPBList.Add(pbAlien8);
            AlienPBList.Add(pbAlien9);
            AlienPBList.Add(pbAlien10);
            AlienPBList.Add(pbAlien11);
            AlienPBList.Add(pbAlien12);
            AlienPBList.Add(pbAlien13);
            AlienPBList.Add(pbAlien14);
            AlienPBList.Add(pbAlien15);
            AlienPBList.Add(pbAlien16);
            AlienPBList.Add(pbAlien17);
            AlienPBList.Add(pbAlien18);
            AlienPBList.Add(pbAlien19);
            AlienPBList.Add(pbAlien20);
            AlienPBList.Add(pbAlien21);
            AlienPBList.Add(pbAlien22);
            AlienPBList.Add(pbAlien23);
            AlienPBList.Add(pbAlien24);
            AlienPBList.Add(pbAlien25);
            AlienPBList.Add(pbAlien26);
            AlienPBList.Add(pbAlien27);
            AlienPBList.Add(pbAlien28);
            AlienPBList.Add(pbAlien29);
            AlienPBList.Add(pbAlien30);
            AlienPBList.Add(pbAlien31);
            AlienPBList.Add(pbAlien32);
            AlienPBList.Add(pbAlien33);
            AlienPBList.Add(pbAlien34);
            AlienPBList.Add(pbAlien35);
            AlienPBList.Add(pbAlien36);
            AlienPBList.Add(pbAlien37);
            AlienPBList.Add(pbAlien38);
            AlienPBList.Add(pbAlien39);
            AlienPBList.Add(pbAlien40);
            AlienPBList.Add(pbAlien41);
            AlienPBList.Add(pbAlien42);
            AlienPBList.Add(pbAlien43);
            AlienPBList.Add(pbAlien44);
            AlienPBList.Add(pbAlien45);
            AlienPBList.Add(pbAlien46);
            AlienPBList.Add(pbAlien47);
            AlienPBList.Add(pbAlien48);
            AlienPBList.Add(pbAlien49);
            AlienPBList.Add(pbAlien50);
            AlienPBList.Add(pbAlien51);
            AlienPBList.Add(pbAlien52);
            AlienPBList.Add(pbAlien53);
            AlienPBList.Add(pbAlien54);
            AlienPBList.Add(pbAlien55);
        } 

        private void AlienAnimation() {
            foreach (var item in AlienList) {
                if (alienAnimation == 0) {
                    if (item.GetAlienType() == 1) {
                        item.SetImage(Image.FromFile("resources/textures/Alien1_2.png"));
                    }
                    else if (item.GetAlienType() == 2) {
                        item.SetImage(Image.FromFile("resources/textures/Alien2_2.png"));
                    }
                    else if (item.GetAlienType() == 3) {
                        item.SetImage(Image.FromFile("resources/textures/Alien3_2.png"));
                    }
                    ++alienAnimation;
                }
                else if (alienAnimation == 1) {
                    if (item.GetAlienType() == 1) {
                        item.SetImage(Image.FromFile("resources/textures/Alien1_1.png"));
                    }
                    else if (item.GetAlienType() == 2) {
                        item.SetImage(Image.FromFile("resources/textures/Alien2_1.png"));
                    }
                    else if (item.GetAlienType() == 3) {
                        item.SetImage(Image.FromFile("resources/textures/Alien3_1.png"));
                    }
                    --alienAnimation;
                }
            }

            // Update images
            for (int i = 0; i < 55; i++)
                AlienPBList[i].Image = AlienList[i].GetImage();
                /*foreach (var item in AlienList) {
                    // Update top row alien images
                    pbAlien1.Image = item.GetImage();
                    pbAlien2.Image = item.GetImage();
                    pbAlien3.Image = item.GetImage();
                    pbAlien4.Image = item.GetImage();
                    pbAlien5.Image = item.GetImage();
                    pbAlien6.Image = item.GetImage();
                    pbAlien7.Image = item.GetImage();
                    pbAlien8.Image = item.GetImage();
                    pbAlien9.Image = item.GetImage();
                    pbAlien10.Image = item.GetImage();
                    pbAlien11.Image = item.GetImage();
    
                    // Update second from top and middle row alien images
                    pbAlien12.Image = item.GetImage();
                    pbAlien13.Image = item.GetImage();
                    pbAlien14.Image = item.GetImage();
                    pbAlien15.Image = item.GetImage();
                    pbAlien16.Image = item.GetImage();
                    pbAlien17.Image = item.GetImage();
                    pbAlien18.Image = item.GetImage();
                    pbAlien19.Image = item.GetImage();
                    pbAlien20.Image = item.GetImage();
                    pbAlien21.Image = item.GetImage();
                    pbAlien22.Image = item.GetImage();
                    pbAlien23.Image = item.GetImage();
                    pbAlien24.Image = item.GetImage();
                    pbAlien25.Image = item.GetImage();
                    pbAlien26.Image = item.GetImage();
                    pbAlien27.Image = item.GetImage();
                    pbAlien28.Image = item.GetImage();
                    pbAlien29.Image = item.GetImage();
                    pbAlien30.Image = item.GetImage();
                    pbAlien31.Image = item.GetImage();
                    pbAlien32.Image = item.GetImage();
                    pbAlien33.Image = item.GetImage();
    
                    // Update bottom two row alien images
                    pbAlien34.Image = item.GetImage();
                    pbAlien35.Image = item.GetImage();
                    pbAlien36.Image = item.GetImage();
                    pbAlien37.Image = item.GetImage();
                    pbAlien38.Image = item.GetImage();
                    pbAlien39.Image = item.GetImage();
                    pbAlien40.Image = item.GetImage();
                    pbAlien41.Image = item.GetImage();
                    pbAlien42.Image = item.GetImage();
                    pbAlien43.Image = item.GetImage();
                    pbAlien44.Image = item.GetImage();
                    pbAlien45.Image = item.GetImage();
                    pbAlien46.Image = item.GetImage();
                    pbAlien47.Image = item.GetImage();
                    pbAlien48.Image = item.GetImage();
                    pbAlien49.Image = item.GetImage();
                    pbAlien50.Image = item.GetImage();
                    pbAlien51.Image = item.GetImage();
                    pbAlien52.Image = item.GetImage();
                    pbAlien53.Image = item.GetImage();
                    pbAlien54.Image = item.GetImage();
                    pbAlien55.Image = item.GetImage();
                }*/
        }
    }
}
