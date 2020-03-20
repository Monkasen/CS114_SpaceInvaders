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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "increase speed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
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
            this.timerCount.Location = new System.Drawing.Point(564, 196);
            this.timerCount.Name = "timerCount";
            this.timerCount.Size = new System.Drawing.Size(68, 15);
            this.timerCount.TabIndex = 2;
            this.timerCount.Text = "timerCount";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 954);
            this.Controls.Add(this.timerCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "GameWindow";
            this.Text = "Space Invaders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer alienSpeed;
        private System.Windows.Forms.Label timerCount;
    }
}

