using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input; // For key events

namespace SpaceInvaders {
    public partial class MainMenu : Form  {
        public static short gameMode = 0;
        string[] scores = new string[] { "0", "0", "0" };
        string fileName = Path.Combine(Environment.CurrentDirectory, "highscore.txt");

        public MainMenu() {
            InitializeComponent();
            
            //if the file doesn't exist, create it
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
                for (int i = 0; i < 3; i++)
                {
                    File.WriteAllLines(fileName, scores);
                }
            }
            using (StreamReader fileRead = new StreamReader(fileName))
            {
                scores[0] = fileRead.ReadLine();
                scores[1] = fileRead.ReadLine();
                scores[2] = fileRead.ReadLine();
            }
        }


        private void onePlayerButton_Click(object sender, EventArgs e) {
            gameMode = 1;
            Close();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e) {
            gameMode = 2;
            Close();
        }
    }
}
