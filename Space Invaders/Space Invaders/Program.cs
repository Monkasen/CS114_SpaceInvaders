using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SpaceInvaders {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            if (MainMenu.gameMode == 1) {
                Application.Run(new GameWindow());
    }
            else if (MainMenu.gameMode == 2){
                MessageBox.Show("Not yet implemented!");
            }
        }
    }
}
