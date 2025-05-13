namespace basicUI
{
    partial class LeaderBoard
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.이름 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.점수 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.등수 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.등수,
            this.이름,
            this.점수});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(784, 524);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // 이름
            // 
            this.이름.DisplayIndex = 0;
            // 
            // 점수
            // 
            this.점수.DisplayIndex = 1;
            // 
            // 등수
            // 
            this.등수.DisplayIndex = 2;
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 524);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LeaderBoard";
            this.Text = "LeaderBoard";
            this.Load += new System.EventHandler(this.LeaderBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 등수;
        private System.Windows.Forms.ColumnHeader 이름;
        private System.Windows.Forms.ColumnHeader 점수;
    }
}