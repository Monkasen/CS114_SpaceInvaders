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
            this.highScoreTextSP = new System.Windows.Forms.Label();
            this.highScoreTextMP = new System.Windows.Forms.Label();
            this.highScoreSP1 = new System.Windows.Forms.Label();
            this.highScoreSP2 = new System.Windows.Forms.Label();
            this.highScoreSP3 = new System.Windows.Forms.Label();
            this.highScoreMP3 = new System.Windows.Forms.Label();
            this.highScoreMP2 = new System.Windows.Forms.Label();
            this.highScoreMP1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // titleImage
            // 
            this.titleImage.Image = ((System.Drawing.Image)(resources.GetObject("titleImage.Image")));
            this.titleImage.Location = new System.Drawing.Point(84, 49);
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
            this.onePlayerButton.Font = new System.Drawing.Font("Space Invaders", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.onePlayerButton.Location = new System.Drawing.Point(84, 469);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(235, 45);
            this.onePlayerButton.TabIndex = 1;
            this.onePlayerButton.Text = " 1 - Player";
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
            this.twoPlayerButton.Font = new System.Drawing.Font("Space Invaders", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.twoPlayerButton.Location = new System.Drawing.Point(447, 469);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(235, 45);
            this.twoPlayerButton.TabIndex = 2;
            this.twoPlayerButton.Text = " 2-Player";
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.twoPlayerButton_Click);
            // 
            // highScoreTextSP
            // 
            this.highScoreTextSP.AutoSize = true;
            this.highScoreTextSP.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreTextSP.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreTextSP.Location = new System.Drawing.Point(110, 558);
            this.highScoreTextSP.Name = "highScoreTextSP";
            this.highScoreTextSP.Size = new System.Drawing.Size(189, 33);
            this.highScoreTextSP.TabIndex = 3;
            this.highScoreTextSP.Text = "highScores";
            // 
            // highScoreTextMP
            // 
            this.highScoreTextMP.AutoSize = true;
            this.highScoreTextMP.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreTextMP.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreTextMP.Location = new System.Drawing.Point(474, 558);
            this.highScoreTextMP.Name = "highScoreTextMP";
            this.highScoreTextMP.Size = new System.Drawing.Size(189, 33);
            this.highScoreTextMP.TabIndex = 4;
            this.highScoreTextMP.Text = "highScores";
            // 
            // highScoreSP1
            // 
            this.highScoreSP1.AutoSize = true;
            this.highScoreSP1.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreSP1.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreSP1.Location = new System.Drawing.Point(152, 608);
            this.highScoreSP1.Name = "highScoreSP1";
            this.highScoreSP1.Size = new System.Drawing.Size(33, 33);
            this.highScoreSP1.TabIndex = 11;
            this.highScoreSP1.Text = "0";
            this.highScoreSP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreSP2
            // 
            this.highScoreSP2.AutoSize = true;
            this.highScoreSP2.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreSP2.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreSP2.Location = new System.Drawing.Point(152, 658);
            this.highScoreSP2.Name = "highScoreSP2";
            this.highScoreSP2.Size = new System.Drawing.Size(33, 33);
            this.highScoreSP2.TabIndex = 12;
            this.highScoreSP2.Text = "0";
            this.highScoreSP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreSP3
            // 
            this.highScoreSP3.AutoSize = true;
            this.highScoreSP3.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreSP3.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreSP3.Location = new System.Drawing.Point(152, 708);
            this.highScoreSP3.Name = "highScoreSP3";
            this.highScoreSP3.Size = new System.Drawing.Size(33, 33);
            this.highScoreSP3.TabIndex = 13;
            this.highScoreSP3.Text = "0";
            this.highScoreSP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreMP3
            // 
            this.highScoreMP3.AutoSize = true;
            this.highScoreMP3.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreMP3.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreMP3.Location = new System.Drawing.Point(517, 708);
            this.highScoreMP3.Name = "highScoreMP3";
            this.highScoreMP3.Size = new System.Drawing.Size(33, 33);
            this.highScoreMP3.TabIndex = 19;
            this.highScoreMP3.Text = "0";
            this.highScoreMP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreMP2
            // 
            this.highScoreMP2.AutoSize = true;
            this.highScoreMP2.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreMP2.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreMP2.Location = new System.Drawing.Point(517, 658);
            this.highScoreMP2.Name = "highScoreMP2";
            this.highScoreMP2.Size = new System.Drawing.Size(33, 33);
            this.highScoreMP2.TabIndex = 18;
            this.highScoreMP2.Text = "0";
            this.highScoreMP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreMP1
            // 
            this.highScoreMP1.AutoSize = true;
            this.highScoreMP1.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreMP1.ForeColor = System.Drawing.SystemColors.Control;
            this.highScoreMP1.Location = new System.Drawing.Point(517, 608);
            this.highScoreMP1.Name = "highScoreMP1";
            this.highScoreMP1.Size = new System.Drawing.Size(33, 33);
            this.highScoreMP1.TabIndex = 17;
            this.highScoreMP1.Text = "0";
            this.highScoreMP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(108, 708);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "3.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(473, 708);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 33);
            this.label9.TabIndex = 16;
            this.label9.Text = "3.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(473, 658);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 33);
            this.label10.TabIndex = 15;
            this.label10.Text = "2.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(476, 608);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 33);
            this.label11.TabIndex = 14;
            this.label11.Text = "1.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(108, 658);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "2.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Space Invaders", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(111, 608);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "1.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(766, 933);
            this.Controls.Add(this.highScoreMP3);
            this.Controls.Add(this.highScoreMP2);
            this.Controls.Add(this.highScoreMP1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.highScoreSP3);
            this.Controls.Add(this.highScoreSP2);
            this.Controls.Add(this.highScoreSP1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.highScoreTextMP);
            this.Controls.Add(this.highScoreTextSP);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox titleImage;
        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.Label highScoreTextSP;
        private System.Windows.Forms.Label highScoreTextMP;
        private System.Windows.Forms.Label highScoreSP1;
        private System.Windows.Forms.Label highScoreSP2;
        private System.Windows.Forms.Label highScoreSP3;
        private System.Windows.Forms.Label highScoreMP3;
        private System.Windows.Forms.Label highScoreMP2;
        private System.Windows.Forms.Label highScoreMP1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}