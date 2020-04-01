namespace SpaceInvaders {
    partial class MainMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.titleImage = new System.Windows.Forms.PictureBox();
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // titleImage
            // 
            this.titleImage.Image = ((System.Drawing.Image)(resources.GetObject("titleImage.Image")));
            this.titleImage.Location = new System.Drawing.Point(35, 12);
            this.titleImage.Name = "titleImage";
            this.titleImage.Size = new System.Drawing.Size(598, 294);
            this.titleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.titleImage.TabIndex = 0;
            this.titleImage.TabStop = false;
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.onePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.ForeColor = System.Drawing.Color.Black;
            this.onePlayerButton.Image = ((System.Drawing.Image)(resources.GetObject("onePlayerButton.Image")));
            this.onePlayerButton.Location = new System.Drawing.Point(35, 387);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(235, 67);
            this.onePlayerButton.TabIndex = 1;
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.twoPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.twoPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.twoPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayerButton.ForeColor = System.Drawing.Color.Black;
            this.twoPlayerButton.Image = ((System.Drawing.Image)(resources.GetObject("twoPlayerButton.Image")));
            this.twoPlayerButton.Location = new System.Drawing.Point(398, 387);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(235, 67);
            this.twoPlayerButton.TabIndex = 2;
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.twoPlayerButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(671, 827);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(this.onePlayerButton);
            this.Controls.Add(this.titleImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox titleImage;
        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayerButton;
    }
}