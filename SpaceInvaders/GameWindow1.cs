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

namespace SpaceInvaders {
    public partial class GameWindow : Form {
        double speedMultiplier = 1;
        double gameTicks = 1;
        int buttonCount = 1;



        public GameWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { //TEMPORARY BUTTON TO INCREASE ALIEN SPEED, NORMALLY DONE BY KILLING ALIENS
            speedMultiplier = speedMultiplier * 1.01;
            ++buttonCount;
            label1.Text = $"{buttonCount}"; //TEMPORARY LABEL TO DISPLAY HOW MANY ALIENS HAVE BEEN KILLED, MAX IS 55 IN NORMAL GAME
        }

        private void alienSpeed_Tick(object sender, EventArgs e) {
            gameTicks = gameTicks * speedMultiplier;
            timerCount.Text = $"{gameTicks}"; //TEMPORARY LABEL TO TRACK SPEED MULTIPLIER
            if (gameTicks >= 50) {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "quack.wav");
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(path);
                sp.Play();
                gameTicks = 0;
            }
            ++gameTicks;
        }
    }
}
