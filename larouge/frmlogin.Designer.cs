namespace larouge
{
    partial class frmlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comp = new System.Windows.Forms.ComboBox();
            this.COMPCAMP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtusername.Location = new System.Drawing.Point(160, 61);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(196, 36);
            this.txtusername.TabIndex = 1;
            this.txtusername.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(362, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "اسم المستخدم";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtpassword.Location = new System.Drawing.Point(160, 117);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(196, 36);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.Tag = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.Location = new System.Drawing.Point(398, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "كلمة المرور";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnlogin.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnlogin.Location = new System.Drawing.Point(25, 70);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(117, 36);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Tag = "3";
            this.btnlogin.Text = "دخول";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncancle
            // 
            this.btncancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btncancle.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btncancle.Location = new System.Drawing.Point(25, 112);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(117, 36);
            this.btncancle.TabIndex = 4;
            this.btncancle.Tag = "4";
            this.btncancle.Text = "إلغاء";
            this.btncancle.UseVisualStyleBackColor = false;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::larouge.Properties.Resources.key_icon;
            this.pictureBox2.Location = new System.Drawing.Point(25, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 45);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // comp
            // 
            this.comp.FormattingEnabled = true;
            this.comp.Location = new System.Drawing.Point(238, 12);
            this.comp.Name = "comp";
            this.comp.Size = new System.Drawing.Size(244, 21);
            this.comp.TabIndex = 6;
            this.comp.SelectedIndexChanged += new System.EventHandler(this.comp_SelectedIndexChanged);
            // 
            // COMPCAMP
            // 
            this.COMPCAMP.FormattingEnabled = true;
            this.COMPCAMP.Location = new System.Drawing.Point(12, 12);
            this.COMPCAMP.Name = "COMPCAMP";
            this.COMPCAMP.Size = new System.Drawing.Size(220, 21);
            this.COMPCAMP.TabIndex = 7;
            this.COMPCAMP.Visible = false;
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(518, 211);
            this.Controls.Add(this.COMPCAMP);
            this.Controls.Add(this.comp);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دخول النظام";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btncancle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comp;
        private System.Windows.Forms.ComboBox COMPCAMP;
    }
}

