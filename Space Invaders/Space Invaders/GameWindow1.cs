﻿using SpaceInvaders;
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
        double gameTicks = 0; // Internal game clock
        double speedMultiplier = 1; // Modifies speed of game clock as more aliens are killed
        int numAliensLeft = 55; // Tracks how many aliens remain
        int score = 0; // Track the player's close
        private const int rightSideDifference = 68;
        private const int projectileSpeed = 7;
        private bool isShotFired = false; // Checks if player has active projectile
        private int soundStep = 1; // Alien movement sound counter
        private int deathTimer = 0; // Death timer for alien explosion
        private int alienAnimation = 0; // Alien animation step counter
        private List<Alien> AlienList = new List<Alien>();
        private List<PictureBox> AlienPBList = new List<PictureBox>();

        public GameWindow() {
            InitializeComponent();
            InitializeAliens(); // Create list of aliens and their graphics
        }

        private void alienSpeed_Tick(object sender, EventArgs e) // Controls speed of aliens throughout the game
        { 
            gameTicks = Math.Round((gameTicks * speedMultiplier), 2);
            debugTimer.Text = $"{gameTicks}"; // TEMPORARY LABEL TO TRACK SPEED MULTIPLIER
            if (gameTicks >= 15) { // Move aliens after 15 ticks
                PlaySound(1);
                AlienAnimation();
                gameTicks = 0; // Reset counter to 0 for next alien movement
            }
            ++gameTicks;
        }

        private void playerMovement_Tick(object sender, EventArgs e) // Timer handles all player movements and inputs
        {
            debugXLocation.Text = player.Location.X.ToString(); // TEMPORARY LABEL TO DISPLAY PLAYER'S X LOCATION

            if (Keyboard.IsKeyDown(Key.Left)) // Move left
            {
                if (player.Location.X > 0)
                    player.Location = new Point(player.Location.X - 2, player.Location.Y);
            }
            else if (Keyboard.IsKeyDown(Key.Right)) // Move right
            {
                if (player.Location.X < this.Width - rightSideDifference) // Calculate current width of form
                    player.Location = new Point(player.Location.X + 2, player.Location.Y);
            }
            if (Keyboard.IsKeyDown(Key.Up)) // Shoot projectile
            {
                if (!isShotFired)
                {
                    isShotFired = true;
                    playerProjectile.Location = new Point(player.Location.X + (25), player.Location.Y);
                    playerProjectile.Visible = true;
                    PlaySound(3);
                }
            }

            if (!isShotFired) return;
            playerProjectile.Location = new Point(playerProjectile.Location.X, playerProjectile.Location.Y - projectileSpeed);
            isShotFired = ProjectileEvent();
        }

        private bool ProjectileEvent() // Checks for out of bounds projectile
        { 
            if (playerProjectile.Location.Y < 0) {
                playerProjectile.Visible = false;
                return false;
            }
            return true;
        }

        private void projectileCollision_Tick(object sender, EventArgs e) // Checks for player projectile collision with alien
        {
            for (int i = 0; i < 55; i++) {
                if (playerProjectile.Bounds.IntersectsWith(AlienPBList[i].Bounds) && (AlienList[i].GetState() == 1) && isShotFired) { // Checks for bullet intersecting alien, if the alien is alive, and there if there is an active bullet
                    playerProjectile.Visible = false; // Hides player's projectile
                    isShotFired = false; // Disables player's projectile
                    KillAlien(ref i);
                }
            }
        }

        private void alienDeath_Tick(object sender, EventArgs e) // Handles removing alien explosion after death
        { 
            ++deathTimer;
            if (deathTimer == 10) { // After 10 ticks, remove the explosion and reset the timer
                for (int i = 0; i < 55; i++) {
                    if (AlienList[i].GetState() == 0) { // If the alien has a pending death animation...
                        AlienPBList[i].Visible = false; // Disable alien image
                        alienDeath.Enabled = false; // Turn timer off until next death
                    }
                }
                deathTimer = 0; // Reset timer
            }
        }

        private void InitializeAliens() // Builds lists for aliens and their graphics
        { 
            // Create and add Alien objects to list
            AlienList.Add(new Alien(3, pbAlien1.Image));
            AlienList.Add(new Alien(3, pbAlien2.Image));
            AlienList.Add(new Alien(3, pbAlien3.Image));
            AlienList.Add(new Alien(3, pbAlien4.Image));
            AlienList.Add(new Alien(3, pbAlien5.Image));
            AlienList.Add(new Alien(3, pbAlien6.Image));
            AlienList.Add(new Alien(3, pbAlien7.Image));
            AlienList.Add(new Alien(3, pbAlien8.Image));
            AlienList.Add(new Alien(3, pbAlien9.Image));
            AlienList.Add(new Alien(3, pbAlien10.Image));
            AlienList.Add(new Alien(3, pbAlien11.Image));
            AlienList.Add(new Alien(2, pbAlien12.Image));
            AlienList.Add(new Alien(2, pbAlien13.Image));
            AlienList.Add(new Alien(2, pbAlien14.Image));
            AlienList.Add(new Alien(2, pbAlien15.Image));
            AlienList.Add(new Alien(2, pbAlien16.Image));
            AlienList.Add(new Alien(2, pbAlien17.Image));
            AlienList.Add(new Alien(2, pbAlien18.Image));
            AlienList.Add(new Alien(2, pbAlien19.Image));
            AlienList.Add(new Alien(2, pbAlien20.Image));
            AlienList.Add(new Alien(2, pbAlien21.Image));
            AlienList.Add(new Alien(2, pbAlien22.Image));
            AlienList.Add(new Alien(2, pbAlien23.Image));
            AlienList.Add(new Alien(2, pbAlien24.Image));
            AlienList.Add(new Alien(2, pbAlien25.Image));
            AlienList.Add(new Alien(2, pbAlien26.Image));
            AlienList.Add(new Alien(2, pbAlien27.Image));
            AlienList.Add(new Alien(2, pbAlien28.Image));
            AlienList.Add(new Alien(2, pbAlien29.Image));
            AlienList.Add(new Alien(2, pbAlien30.Image));
            AlienList.Add(new Alien(2, pbAlien31.Image));
            AlienList.Add(new Alien(2, pbAlien32.Image));
            AlienList.Add(new Alien(2, pbAlien33.Image));
            AlienList.Add(new Alien(1, pbAlien34.Image));
            AlienList.Add(new Alien(1, pbAlien35.Image));
            AlienList.Add(new Alien(1, pbAlien36.Image));
            AlienList.Add(new Alien(1, pbAlien37.Image));
            AlienList.Add(new Alien(1, pbAlien38.Image));
            AlienList.Add(new Alien(1, pbAlien39.Image));
            AlienList.Add(new Alien(1, pbAlien40.Image));
            AlienList.Add(new Alien(1, pbAlien41.Image));
            AlienList.Add(new Alien(1, pbAlien42.Image));
            AlienList.Add(new Alien(1, pbAlien43.Image));
            AlienList.Add(new Alien(1, pbAlien44.Image));
            AlienList.Add(new Alien(1, pbAlien45.Image));
            AlienList.Add(new Alien(1, pbAlien46.Image));
            AlienList.Add(new Alien(1, pbAlien47.Image));
            AlienList.Add(new Alien(1, pbAlien48.Image));
            AlienList.Add(new Alien(1, pbAlien49.Image));
            AlienList.Add(new Alien(1, pbAlien50.Image));
            AlienList.Add(new Alien(1, pbAlien51.Image));
            AlienList.Add(new Alien(1, pbAlien52.Image));
            AlienList.Add(new Alien(1, pbAlien53.Image));
            AlienList.Add(new Alien(1, pbAlien54.Image));
            AlienList.Add(new Alien(1, pbAlien55.Image));

            // Add pictureboxes to list
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

        private void AlienAnimation() // Cycle through animations for aliens
        { 
            foreach (var item in AlienList) {
                switch (alienAnimation) {
                    case 0: {
                        if (item.GetAlienType() == 1)
                            item.SetImage(Image.FromFile("resources/textures/Alien1_2.png"));
                        if (item.GetAlienType() == 2)
                            item.SetImage(Image.FromFile("resources/textures/Alien2_2.png"));
                        if (item.GetAlienType() == 3)
                            item.SetImage(Image.FromFile("resources/textures/Alien3_2.png"));
                        break;
                    }
                    case 1: {
                        if (item.GetAlienType() == 1)
                            item.SetImage(Image.FromFile("resources/textures/Alien1_1.png"));
                        if (item.GetAlienType() == 2)
                            item.SetImage(Image.FromFile("resources/textures/Alien2_1.png"));
                        if (item.GetAlienType() == 3)
                            item.SetImage(Image.FromFile("resources/textures/Alien3_1.png"));
                        break;
                    }
                }
            }

            // Update images
            for (int i = 0; i < 55; i++) {
                if (AlienList[i].GetState() == 1) {
                    AlienPBList[i].Image = AlienList[i].GetImage();
                }
            }

            // Switch animation step
            switch (alienAnimation) {
                case 0: {
                    ++alienAnimation;
                    break;
                }
                case 1: {
                    --alienAnimation;
                    break;
                }
            }
        }

        private void PlaySound(int input) // Handles various game sounds    
        { 
            var sp = new System.Windows.Media.MediaPlayer();
            switch (input) {
                // Alien movement 'music'
                case 1 when soundStep == 1: {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick1.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;
                    break;
                }
                case 1 when soundStep == 2: {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick2.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;
                    break;
                }
                case 1 when soundStep == 3: {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick3.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    ++soundStep;
                    break;
                }
                case 1 when soundStep == 4: {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/tick4.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    soundStep = 1;
                    break;
                }
                case 2: { // Alien death sound

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/alienDeath.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    break;
                }
                case 3: { // Player shoot projectile sound
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "resources/sounds/playerShoot.wav");
                    sp.Open(new System.Uri(path));
                    sp.Play();
                    break;
                }
            }
        }

        private void KillAlien(ref int i) // Handles process of killing an alien
        { 
            AlienList[i].SetState(0); // Sets alien state to 'dead'
            AlienPBList[i].Image = Image.FromFile("resources/textures/AlienDeath.png"); // Replaces alien image with death animation
            speedMultiplier *= 1.01; // When an alien dies, increase game speed by 1%
            PlaySound(2); // Play death sound
            playerScore.Text = ($"{score += 10}"); // Add 10 points to score
            --numAliensLeft; // Decrement number of aliens remaining
            debugCount.Text = $"{numAliensLeft}"; // TEMPORARY LABEL TO DISPLAY HOW MANY ALIENS HAVE BEEN KILLED
            alienDeath.Enabled = true; // Starts timer to remove alien explosion
        }

        private void CheckEndGame() {
            if (numAliensLeft == 0) { // If player wins...

            }
            if (true) { // If aliens reach the end point and take over Earth, NYI

            }
        }


    }
}
