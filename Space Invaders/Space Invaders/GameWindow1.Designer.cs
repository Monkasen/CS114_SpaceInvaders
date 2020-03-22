namespace SpaceInvaders {
    partial class GameWindow {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.alienSpeed = new System.Windows.Forms.Timer(this.components);
            this.timerCount = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.playerMovement = new System.Windows.Forms.Timer(this.components);
            this.xLocation = new System.Windows.Forms.Label();
            this.invaderTest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTest)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "increase speed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1";
            // 
            // alienSpeed
            // 
            this.alienSpeed.Enabled = true;
            this.alienSpeed.Interval = 50;
            this.alienSpeed.Tick += new System.EventHandler(this.alienSpeed_Tick);
            // 
            // timerCount
            // 
            this.timerCount.AutoSize = true;
            this.timerCount.ForeColor = System.Drawing.Color.White;
            this.timerCount.Location = new System.Drawing.Point(483, 170);
            this.timerCount.Name = "timerCount";
            this.timerCount.Size = new System.Drawing.Size(57, 13);
            this.timerCount.TabIndex = 2;
            this.timerCount.Text = "timerCount";
            // 
            // player
            // 
            this.player.Image = global::Space_Invaders.Properties.Resources.PlayerShip;
            this.player.Location = new System.Drawing.Point(373, 769);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(52, 32);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 3;
            this.player.TabStop = false;
            // 
            // playerMovement
            // 
            this.playerMovement.Enabled = true;
            this.playerMovement.Interval = 1;
            this.playerMovement.Tick += new System.EventHandler(this.playerMovement_Tick);
            // 
            // xLocation
            // 
            this.xLocation.AutoSize = true;
            this.xLocation.ForeColor = System.Drawing.Color.Coral;
            this.xLocation.Location = new System.Drawing.Point(349, 400);
            this.xLocation.Name = "xLocation";
            this.xLocation.Size = new System.Drawing.Size(35, 13);
            this.xLocation.TabIndex = 4;
            this.xLocation.Text = "label2";
            // 
            // invaderTest
            // 
            this.invaderTest.Location = new System.Drawing.Point(149, 318);
            this.invaderTest.Name = "invaderTest";
            this.invaderTest.Size = new System.Drawing.Size(52, 32);
            this.invaderTest.TabIndex = 5;
            this.invaderTest.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(799, 827);
            this.Controls.Add(this.invaderTest);
            this.Controls.Add(this.xLocation);
            this.Controls.Add(this.player);
            this.Controls.Add(this.timerCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "GameWindow";
            this.Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer alienSpeed;
        private System.Windows.Forms.Label timerCount;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer playerMovement;
        private System.Windows.Forms.Label xLocation;
        private System.Windows.Forms.PictureBox invaderTest;
    }
}

