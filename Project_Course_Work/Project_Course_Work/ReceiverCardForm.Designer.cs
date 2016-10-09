namespace Project_Course_Work
{
    partial class ReceiverCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiverCardForm));
            this.Card180 = new System.Windows.Forms.Button();
            this.Card90 = new System.Windows.Forms.Button();
            this.Card60 = new System.Windows.Forms.Button();
            this.Card40 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Card180
            // 
            this.Card180.BackgroundImage = global::Project_Course_Work.Properties.Resources._180;
            this.Card180.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card180.FlatAppearance.BorderSize = 0;
            this.Card180.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Card180.Location = new System.Drawing.Point(310, 198);
            this.Card180.Name = "Card180";
            this.Card180.Size = new System.Drawing.Size(292, 180);
            this.Card180.TabIndex = 3;
            this.Card180.UseVisualStyleBackColor = true;
            this.Card180.Click += new System.EventHandler(this.Card180_Click);
            // 
            // Card90
            // 
            this.Card90.BackgroundImage = global::Project_Course_Work.Properties.Resources._90;
            this.Card90.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card90.FlatAppearance.BorderSize = 0;
            this.Card90.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Card90.Location = new System.Drawing.Point(12, 198);
            this.Card90.Name = "Card90";
            this.Card90.Size = new System.Drawing.Size(292, 180);
            this.Card90.TabIndex = 2;
            this.Card90.UseVisualStyleBackColor = true;
            this.Card90.Click += new System.EventHandler(this.Card90_Click);
            // 
            // Card60
            // 
            this.Card60.BackgroundImage = global::Project_Course_Work.Properties.Resources._60;
            this.Card60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card60.FlatAppearance.BorderSize = 0;
            this.Card60.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Card60.Location = new System.Drawing.Point(310, 12);
            this.Card60.Name = "Card60";
            this.Card60.Size = new System.Drawing.Size(292, 180);
            this.Card60.TabIndex = 1;
            this.Card60.UseVisualStyleBackColor = true;
            this.Card60.Click += new System.EventHandler(this.Card60_Click);
            // 
            // Card40
            // 
            this.Card40.BackgroundImage = global::Project_Course_Work.Properties.Resources._40;
            this.Card40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card40.FlatAppearance.BorderSize = 0;
            this.Card40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Card40.Location = new System.Drawing.Point(12, 12);
            this.Card40.Name = "Card40";
            this.Card40.Size = new System.Drawing.Size(292, 180);
            this.Card40.TabIndex = 0;
            this.Card40.UseVisualStyleBackColor = true;
            this.Card40.Click += new System.EventHandler(this.Card40_Click);
            // 
            // ReceiverCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 387);
            this.Controls.Add(this.Card180);
            this.Controls.Add(this.Card90);
            this.Controls.Add(this.Card60);
            this.Controls.Add(this.Card40);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReceiverCard";
            this.Text = "ReceiverCard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Card40;
        private System.Windows.Forms.Button Card60;
        private System.Windows.Forms.Button Card90;
        private System.Windows.Forms.Button Card180;
    }
}