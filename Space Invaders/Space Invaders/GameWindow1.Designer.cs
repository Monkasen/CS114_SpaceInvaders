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
            this.debugButton = new System.Windows.Forms.Button();
            this.debugCount = new System.Windows.Forms.Label();
            this.alienSpeed = new System.Windows.Forms.Timer(this.components);
            this.debugTimer = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.playerMovement = new System.Windows.Forms.Timer(this.components);
            this.debugXLocation = new System.Windows.Forms.Label();
            this.invaderTest = new System.Windows.Forms.PictureBox();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.playerProjectile = new System.Windows.Forms.PictureBox();
            this.projectileCollision = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTest)).BeginInit();
            this.debugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerProjectile)).BeginInit();
            this.SuspendLayout();
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(3, 3);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(134, 20);
            this.debugButton.TabIndex = 0;
            this.debugButton.Text = "increase speed";
            this.debugButton.UseVisualStyleBackColor = true;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // debugCount
            // 
            this.debugCount.AutoSize = true;
            this.debugCount.Location = new System.Drawing.Point(44, 32);
            this.debugCount.Name = "debugCount";
            this.debugCount.Size = new System.Drawing.Size(65, 13);
            this.debugCount.TabIndex = 1;
            this.debugCount.Text = "debugCount";
            // 
            // alienSpeed
            // 
            this.alienSpeed.Enabled = true;
            this.alienSpeed.Interval = 50;
            this.alienSpeed.Tick += new System.EventHandler(this.alienSpeed_Tick);
            // 
            // debugTimer
            // 
            this.debugTimer.AutoSize = true;
            this.debugTimer.ForeColor = System.Drawing.Color.Black;
            this.debugTimer.Location = new System.Drawing.Point(163, 7);
            this.debugTimer.Name = "debugTimer";
            this.debugTimer.Size = new System.Drawing.Size(63, 13);
            this.debugTimer.TabIndex = 2;
            this.debugTimer.Text = "debugTimer";
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
            // debugXLocation
            // 
            this.debugXLocation.AutoSize = true;
            this.debugXLocation.ForeColor = System.Drawing.Color.Black;
            this.debugXLocation.Location = new System.Drawing.Point(163, 32);
            this.debugXLocation.Name = "debugXLocation";
            this.debugXLocation.Size = new System.Drawing.Size(85, 13);
            this.debugXLocation.TabIndex = 4;
            this.debugXLocation.Text = "debugXLocation";
            // 
            // invaderTest
            // 
            this.invaderTest.Location = new System.Drawing.Point(149, 318);
            this.invaderTest.Name = "invaderTest";
            this.invaderTest.Size = new System.Drawing.Size(52, 32);
            this.invaderTest.TabIndex = 5;
            this.invaderTest.TabStop = false;
            this.invaderTest.Visible = false;
            // 
            // debugPanel
            // 
            this.debugPanel.BackColor = System.Drawing.Color.LightGray;
            this.debugPanel.Controls.Add(this.debugButton);
            this.debugPanel.Controls.Add(this.debugTimer);
            this.debugPanel.Controls.Add(this.debugXLocation);
            this.debugPanel.Controls.Add(this.debugCount);
            this.debugPanel.Location = new System.Drawing.Point(-1, 0);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(255, 56);
            this.debugPanel.TabIndex = 6;
            // 
            // playerProjectile
            // 
            this.playerProjectile.Location = new System.Drawing.Point(12, 799);
            this.playerProjectile.Name = "playerProjectile";
            this.playerProjectile.Size = new System.Drawing.Size(4, 16);
            this.playerProjectile.TabIndex = 7;
            this.playerProjectile.TabStop = false;
            this.playerProjectile.Visible = false;
            // 
            // projectileCollision
            // 
            this.projectileCollision.Enabled = true;
            this.projectileCollision.Tick += new System.EventHandler(this.projectileCollision_Tick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(799, 827);
            this.Controls.Add(this.playerProjectile);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.invaderTest);
            this.Controls.Add(this.player);
            this.Name = "GameWindow";
            this.Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTest)).EndInit();
            this.debugPanel.ResumeLayout(false);
            this.debugPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerProjectile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button debugButton;
        private System.Windows.Forms.Label debugCount;
        private System.Windows.Forms.Timer alienSpeed;
        private System.Windows.Forms.Label debugTimer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer playerMovement;
        private System.Windows.Forms.Label debugXLocation;
        private System.Windows.Forms.PictureBox invaderTest;
        private System.Windows.Forms.Panel debugPanel;
        private System.Windows.Forms.PictureBox playerProjectile;
        private System.Windows.Forms.Timer projectileCollision;
    }
}

