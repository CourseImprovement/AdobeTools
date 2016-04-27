namespace AdobeView
{
    partial class View
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountBtn = new System.Windows.Forms.Button();
            this.MtgBtn = new System.Windows.Forms.Button();
            this.AOExp = new System.Windows.Forms.Button();
            this.mtgExp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 29);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(60)))), ((int)(((byte)(61)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(270, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adobe Connect Tools";
            // 
            // AccountBtn
            // 
            this.AccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(131)))), ((int)(((byte)(221)))));
            this.AccountBtn.FlatAppearance.BorderSize = 0;
            this.AccountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountBtn.ForeColor = System.Drawing.Color.White;
            this.AccountBtn.Location = new System.Drawing.Point(30, 86);
            this.AccountBtn.Name = "AccountBtn";
            this.AccountBtn.Size = new System.Drawing.Size(276, 98);
            this.AccountBtn.TabIndex = 3;
            this.AccountBtn.Text = "New Account / Office";
            this.AccountBtn.UseVisualStyleBackColor = false;
            this.AccountBtn.Click += new System.EventHandler(this.AccountBtn_Click);
            // 
            // MtgBtn
            // 
            this.MtgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(131)))), ((int)(((byte)(221)))));
            this.MtgBtn.FlatAppearance.BorderSize = 0;
            this.MtgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MtgBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MtgBtn.ForeColor = System.Drawing.Color.White;
            this.MtgBtn.Location = new System.Drawing.Point(30, 190);
            this.MtgBtn.Name = "MtgBtn";
            this.MtgBtn.Size = new System.Drawing.Size(276, 98);
            this.MtgBtn.TabIndex = 4;
            this.MtgBtn.Text = "New Meetings";
            this.MtgBtn.UseVisualStyleBackColor = false;
            this.MtgBtn.Click += new System.EventHandler(this.MtgBtn_Click);
            // 
            // AOExp
            // 
            this.AOExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(131)))), ((int)(((byte)(221)))));
            this.AOExp.FlatAppearance.BorderSize = 0;
            this.AOExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AOExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.AOExp.ForeColor = System.Drawing.Color.White;
            this.AOExp.Location = new System.Drawing.Point(29, 294);
            this.AOExp.Name = "AOExp";
            this.AOExp.Size = new System.Drawing.Size(136, 54);
            this.AOExp.TabIndex = 4;
            this.AOExp.Text = "Account/Office Template";
            this.AOExp.UseVisualStyleBackColor = false;
            this.AOExp.Click += new System.EventHandler(this.AOExp_Click);
            // 
            // mtgExp
            // 
            this.mtgExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(131)))), ((int)(((byte)(221)))));
            this.mtgExp.FlatAppearance.BorderSize = 0;
            this.mtgExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mtgExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mtgExp.ForeColor = System.Drawing.Color.White;
            this.mtgExp.Location = new System.Drawing.Point(171, 294);
            this.mtgExp.Name = "mtgExp";
            this.mtgExp.Size = new System.Drawing.Size(136, 54);
            this.mtgExp.TabIndex = 4;
            this.mtgExp.Text = "Meetings Template";
            this.mtgExp.UseVisualStyleBackColor = false;
            this.mtgExp.Click += new System.EventHandler(this.mtgExp_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(332, 371);
            this.Controls.Add(this.mtgExp);
            this.Controls.Add(this.AOExp);
            this.Controls.Add(this.MtgBtn);
            this.Controls.Add(this.AccountBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adobe Connect Admin";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AccountBtn;
        private System.Windows.Forms.Button MtgBtn;
        private System.Windows.Forms.Button AOExp;
        private System.Windows.Forms.Button mtgExp;
    }
}