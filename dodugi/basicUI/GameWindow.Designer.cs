namespace basicUI
{
    partial class GameWindow
    {
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.ptHeart1 = new System.Windows.Forms.PictureBox();
            this.ptHeart2 = new System.Windows.Forms.PictureBox();
            this.ptHeart3 = new System.Windows.Forms.PictureBox();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.timer8 = new System.Windows.Forms.Timer(this.components);
            this.timer9 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 150);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(571, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 150);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(911, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 150);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(181, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 150);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(571, 372);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 150);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(911, 372);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 150);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(181, 612);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 150);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(571, 612);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 150);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(911, 612);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(150, 150);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(33, 41);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(61, 18);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "score:";
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.AutoSize = true;
            this.lblScoreValue.Location = new System.Drawing.Point(100, 41);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(51, 18);
            this.lblScoreValue.TabIndex = 10;
            this.lblScoreValue.Text = "value";
            // 
            // ptHeart1
            // 
            this.ptHeart1.Location = new System.Drawing.Point(51, 805);
            this.ptHeart1.Name = "ptHeart1";
            this.ptHeart1.Size = new System.Drawing.Size(100, 93);
            this.ptHeart1.TabIndex = 11;
            this.ptHeart1.TabStop = false;
            // 
            // ptHeart2
            // 
            this.ptHeart2.Location = new System.Drawing.Point(209, 805);
            this.ptHeart2.Name = "ptHeart2";
            this.ptHeart2.Size = new System.Drawing.Size(100, 93);
            this.ptHeart2.TabIndex = 12;
            this.ptHeart2.TabStop = false;
            // 
            // ptHeart3
            // 
            this.ptHeart3.Location = new System.Drawing.Point(358, 805);
            this.ptHeart3.Name = "ptHeart3";
            this.ptHeart3.Size = new System.Drawing.Size(100, 93);
            this.ptHeart3.TabIndex = 13;
            this.ptHeart3.TabStop = false;
            // 
            // btnGameStart
            // 
            this.btnGameStart.Location = new System.Drawing.Point(1059, 820);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(165, 59);
            this.btnGameStart.TabIndex = 14;
            this.btnGameStart.Text = "Start";
            this.btnGameStart.UseVisualStyleBackColor = true;
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 920);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.ptHeart3);
            this.Controls.Add(this.ptHeart2);
            this.Controls.Add(this.ptHeart1);
            this.Controls.Add(this.lblScoreValue);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "GameWindow";
            this.Text = "GamePlay";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptHeart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreValue;
        private System.Windows.Forms.PictureBox ptHeart1;
        private System.Windows.Forms.PictureBox ptHeart2;
        private System.Windows.Forms.PictureBox ptHeart3;
        private System.Windows.Forms.Button btnGameStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.Timer timer8;
        private System.Windows.Forms.Timer timer9;
    }
}