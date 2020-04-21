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

            string fileName = Path.Combine(Environment.CurrentDirectory, "highscore.txt");
            string[] scores = new string[] { "0", "0", "0" };
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

            if (MainMenu.gameMode == 1) {
                Application.Run(new GameWindow());
    }
            else if (MainMenu.gameMode == 2){
                MessageBox.Show("Not yet implemented!");
            }
        }
    }
}
