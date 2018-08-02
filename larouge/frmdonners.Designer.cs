namespace larouge
{
    partial class frmdonners
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdonners));
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblcustomerid = new System.Windows.Forms.Label();
            this.cmbuser = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colisactive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colmony = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbisactive = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtpartid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpartvalue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndelpro = new System.Windows.Forms.Button();
            this.btnnewpro = new System.Windows.Forms.Button();
            this.btnupdatepro = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmonyval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluseradd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtproductname
            // 
            this.txtproductname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductname.Location = new System.Drawing.Point(266, 17);
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(143, 23);
            this.txtproductname.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "اسم المورد";
            // 
            // lblcustomerid
            // 
            this.lblcustomerid.AutoSize = true;
            this.lblcustomerid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblcustomerid.Location = new System.Drawing.Point(948, 17);
            this.lblcustomerid.Name = "lblcustomerid";
            this.lblcustomerid.Size = new System.Drawing.Size(18, 19);
            this.lblcustomerid.TabIndex = 44;
            this.lblcustomerid.Text = "0";
            // 
            // cmbuser
            // 
            this.cmbuser.Enabled = false;
            this.cmbuser.FormattingEnabled = true;
            this.cmbuser.Location = new System.Drawing.Point(712, 14);
            this.cmbuser.Name = "cmbuser";
            this.cmbuser.Size = new System.Drawing.Size(159, 27);
            this.cmbuser.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label15.Location = new System.Drawing.Point(626, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 19);
            this.label15.TabIndex = 42;
            this.label15.Text = "المستخدم";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.Column1,
            this.Column2,
            this.colisactive,
            this.colmony,
            this.coldata});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(497, 376);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // num
            // 
            this.num.Frozen = true;
            this.num.HeaderText = "م";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Width = 30;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "المورد";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // colisactive
            // 
            this.colisactive.HeaderText = "نشط";
            this.colisactive.Name = "colisactive";
            this.colisactive.Width = 60;
            // 
            // colmony
            // 
            this.colmony.HeaderText = "له باقي";
            this.colmony.Name = "colmony";
            this.colmony.Width = 50;
            // 
            // coldata
            // 
            this.coldata.HeaderText = "بيانات المورد";
            this.coldata.Name = "coldata";
            this.coldata.Width = 50;
            // 
            // cmbisactive
            // 
            this.cmbisactive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbisactive.FormattingEnabled = true;
            this.cmbisactive.Items.AddRange(new object[] {
            "الكل",
            "النشط فقط",
            "الغير نشط فقط",
            "له حساب غير مسدد"});
            this.cmbisactive.Location = new System.Drawing.Point(10, 17);
            this.cmbisactive.Name = "cmbisactive";
            this.cmbisactive.Size = new System.Drawing.Size(140, 24);
            this.cmbisactive.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btndelpro);
            this.groupBox1.Controls.Add(this.btnnewpro);
            this.groupBox1.Controls.Add(this.btnupdatepro);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(515, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 434);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ادراج مبالغ ماليه للمورد";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.txtpartid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtpartvalue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(147, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 78);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 27);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // txtpartid
            // 
            this.txtpartid.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpartid.Location = new System.Drawing.Point(208, 19);
            this.txtpartid.Name = "txtpartid";
            this.txtpartid.ReadOnly = true;
            this.txtpartid.Size = new System.Drawing.Size(52, 23);
            this.txtpartid.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(266, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "ID";
            // 
            // txtpartvalue
            // 
            this.txtpartvalue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpartvalue.Location = new System.Drawing.Point(97, 49);
            this.txtpartvalue.Name = "txtpartvalue";
            this.txtpartvalue.Size = new System.Drawing.Size(127, 23);
            this.txtpartvalue.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(230, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "المبلغ";
            // 
            // btndelpro
            // 
            this.btndelpro.BackColor = System.Drawing.Color.LavenderBlush;
            this.btndelpro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btndelpro.Image = global::larouge.Properties.Resources.Trash_Delete_icon;
            this.btndelpro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelpro.Location = new System.Drawing.Point(8, 298);
            this.btndelpro.Name = "btndelpro";
            this.btndelpro.Size = new System.Drawing.Size(116, 45);
            this.btndelpro.TabIndex = 11;
            this.btndelpro.Text = "حذف";
            this.btndelpro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelpro.UseVisualStyleBackColor = false;
            this.btndelpro.Click += new System.EventHandler(this.btndelpro_Click);
            // 
            // btnnewpro
            // 
            this.btnnewpro.Image = ((System.Drawing.Image)(resources.GetObject("btnnewpro.Image")));
            this.btnnewpro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnewpro.Location = new System.Drawing.Point(196, 382);
            this.btnnewpro.Name = "btnnewpro";
            this.btnnewpro.Size = new System.Drawing.Size(116, 45);
            this.btnnewpro.TabIndex = 10;
            this.btnnewpro.Text = "اضافة جديد";
            this.btnnewpro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnewpro.UseVisualStyleBackColor = true;
            this.btnnewpro.Click += new System.EventHandler(this.btnnewpro_Click);
            // 
            // btnupdatepro
            // 
            this.btnupdatepro.Image = ((System.Drawing.Image)(resources.GetObject("btnupdatepro.Image")));
            this.btnupdatepro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnupdatepro.Location = new System.Drawing.Point(318, 382);
            this.btnupdatepro.Name = "btnupdatepro";
            this.btnupdatepro.Size = new System.Drawing.Size(116, 45);
            this.btnupdatepro.TabIndex = 9;
            this.btnupdatepro.Text = "تعديل";
            this.btnupdatepro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdatepro.UseVisualStyleBackColor = true;
            this.btnupdatepro.Click += new System.EventHandler(this.btnupdatepro_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.partid,
            this.coldate,
            this.colmonyval,
            this.coluseradd});
            this.dataGridView2.Location = new System.Drawing.Point(6, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(441, 262);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
            this.dataGridView2.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView2_ColumnWidthChanged);
            this.dataGridView2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView2_Scroll);
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "م";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 30;
            // 
            // partid
            // 
            this.partid.Frozen = true;
            this.partid.HeaderText = "id";
            this.partid.Name = "partid";
            this.partid.ReadOnly = true;
            this.partid.Width = 30;
            // 
            // coldate
            // 
            this.coldate.HeaderText = "التاريخ";
            this.coldate.Name = "coldate";
            this.coldate.ReadOnly = true;
            // 
            // colmonyval
            // 
            this.colmonyval.HeaderText = "المبلغ";
            this.colmonyval.Name = "colmonyval";
            this.colmonyval.ReadOnly = true;
            // 
            // coluseradd
            // 
            this.coluseradd.HeaderText = "المستخدم";
            this.coluseradd.Name = "coluseradd";
            this.coluseradd.ReadOnly = true;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.LavenderBlush;
            this.btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btndel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.Red;
            this.btndel.Image = global::larouge.Properties.Resources.Trash_Delete_icon;
            this.btndel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndel.Location = new System.Drawing.Point(136, 441);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(108, 44);
            this.btndel.TabIndex = 40;
            this.btndel.Text = "حذف";
            this.btndel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnsave.Image = global::larouge.Properties.Resources.Save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(22, 441);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(108, 46);
            this.btnsave.TabIndex = 39;
            this.btnsave.Text = "حفظ";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.Blue;
            this.btnsearch.Image = global::larouge.Properties.Resources.Search_icon;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsearch.Location = new System.Drawing.Point(415, 5);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(94, 43);
            this.btnsearch.TabIndex = 37;
            this.btnsearch.Text = "بحث";
            this.btnsearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Image = global::larouge.Properties.Resources.l_ic_ne_de_sortie_déconnexion_et_production_débouché_symbole_plat_78854268;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(284, 441);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(104, 44);
            this.btnclose.TabIndex = 36;
            this.btnclose.Text = "غلق";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmdonners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(980, 492);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtproductname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblcustomerid);
            this.Controls.Add(this.cmbuser);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cmbisactive);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnclose);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmdonners";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "شاشة الموردين";
            this.Load += new System.EventHandler(this.frmdonners_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcustomerid;
        private System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colisactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmony;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldata;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox cmbisactive;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtpartid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpartvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndelpro;
        private System.Windows.Forms.Button btnnewpro;
        private System.Windows.Forms.Button btnupdatepro;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn partid;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmonyval;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluseradd;
    }
}