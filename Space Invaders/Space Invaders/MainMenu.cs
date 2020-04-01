using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input; // For key events

namespace SpaceInvaders {
    public partial class MainMenu : Form  {
        public static short gameMode = 0;
        public MainMenu() {
            InitializeComponent();
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
