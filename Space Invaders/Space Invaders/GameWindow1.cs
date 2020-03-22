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
        private int formRightSideDifference = 68;


        public GameWindow() {
            InitializeComponent();
            player.Image = Image.FromFile("resources/textures/PlayerShip.png"); // Load player ship (dunno if necessary)
        }

        private void button1_Click(object sender, EventArgs e) { //TEMPORARY BUTTON TO INCREASE ALIEN SPEED, NORMALLY DONE BY KILLING ALIENS
            speedMultiplier = speedMultiplier * 1.01;
            ++buttonCount;
            label1.Text = $"{buttonCount}"; //TEMPORARY LABEL TO DISPLAY HOW MANY ALIENS HAVE BEEN KILLED, MAX IS 55 IN NORMAL GAME
            invaderTest.Image = Image.FromFile("resources/textures/Alien1_1.png"); // TEST IMAGE LOADING
        }

        private void alienSpeed_Tick(object sender, EventArgs e) {
            gameTicks = gameTicks * speedMultiplier;
            timerCount.Text = $"{gameTicks}"; //TEMPORARY LABEL TO TRACK SPEED MULTIPLIER
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
            xLocation.Text = player.Location.X.ToString(); // TEST DELETE ME

            if (Keyboard.IsKeyDown(Key.Left)) // Move left
            {
                if(player.Location.X > 0)
                    player.Location = new Point(player.Location.X - 2, player.Location.Y);
            }
            else if (Keyboard.IsKeyDown(Key.Right)) // Move right
            {
                if(player.Location.X < this.Width - formRightSideDifference) // Calculate current width in case we change this in the future
                    player.Location = new Point(player.Location.X + 2, player.Location.Y);
            }
        }
    }
}
