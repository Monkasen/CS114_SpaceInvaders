using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace SpaceInvaders {
    public partial class MainMenu : Form {
        public static short gameMode = 0;
        string[] scoresSP = new string[] { "0", "0", "0" };
        string[] scoresMP = new string[] { "0", "0", "0" };
        string fileNameSP = Path.Combine(Environment.CurrentDirectory, "highscoreSingle.txt");
        string fileNameMP = Path.Combine(Environment.CurrentDirectory, "highscoreMulti.txt");

        public MainMenu()
        {
            InitializeComponent();
            UseCustomFont();

            // Add singleplayer highscores to a list
            using (StreamReader fileRead = new StreamReader(fileNameSP)) {
                scoresSP[0] = fileRead.ReadLine();
                scoresSP[1] = fileRead.ReadLine();
                scoresSP[2] = fileRead.ReadLine();
            }
            highScoreSP1.Text = scoresSP[0];
            highScoreSP2.Text = scoresSP[1];
            highScoreSP3.Text = scoresSP[2];

            // Add multiplayer highscores to a list
            using (StreamReader fileRead = new StreamReader(fileNameMP)) {
                scoresMP[0] = fileRead.ReadLine();
                scoresMP[1] = fileRead.ReadLine();
                scoresMP[2] = fileRead.ReadLine();
            }
            highScoreMP1.Text = scoresMP[0];
            highScoreMP2.Text = scoresMP[1];
            highScoreMP3.Text = scoresMP[2];
        }


        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            Close();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            gameMode = 2;
            Close();
        }

        private void UseCustomFont()
        {
            PrivateFontCollection customFont = new PrivateFontCollection();

            customFont.AddFontFile("SpaceInvadersFont.ttf");

            onePlayerButton.Font = new Font(customFont.Families[0], 24);
            twoPlayerButton.Font = new Font(customFont.Families[0], 24);

            highScoreTextSP.Font = new Font(customFont.Families[0], 18);
            highScoreTextMP.Font = new Font(customFont.Families[0], 18);

            highScoreSP1.Font = new Font(customFont.Families[0], 18);
            highScoreSP2.Font = new Font(customFont.Families[0], 18);
            highScoreSP3.Font = new Font(customFont.Families[0], 18);

            highScoreMP1.Font = new Font(customFont.Families[0], 18);
            highScoreMP2.Font = new Font(customFont.Families[0], 18);
            highScoreMP3.Font = new Font(customFont.Families[0], 18);
        }
    }
}
