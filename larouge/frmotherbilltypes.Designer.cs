namespace larouge
{
    partial class frmotherbilltypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmotherbilltypes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbopgrid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbusergrid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtbfrom = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.txtbillnum1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbuser = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmboptypes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtsumtotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btndel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.cmbuser2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtbillbookid = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txttid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboptypes2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpartvalue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.dtpto);
            this.groupBox1.Controls.Add(this.dtbfrom);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtbillnum1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmbuser);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmboptypes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(935, 420);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جدول المصروفات";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(216, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(166, 23);
            this.checkBox1.TabIndex = 68;
            this.checkBox1.Text = "مصروفات اضافية فقط";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.cmbopgrid,
            this.Column4,
            this.cmbusergrid,
            this.Column6,
            this.Column7});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(16, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(903, 319);
            this.dataGridView1.TabIndex = 61;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "id";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // cmbopgrid
            // 
            this.cmbopgrid.HeaderText = "البند";
            this.cmbopgrid.Name = "cmbopgrid";
            this.cmbopgrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbopgrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmbopgrid.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "المبلغ";
            this.Column4.Name = "Column4";
            // 
            // cmbusergrid
            // 
            this.cmbusergrid.HeaderText = "المستخدم";
            this.cmbusergrid.Name = "cmbusergrid";
            this.cmbusergrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbusergrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmbusergrid.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "تسلسل الفاتورة";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "تاريخ الفاتورة";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(454, 56);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(159, 27);
            this.dtpto.TabIndex = 65;
            // 
            // dtbfrom
            // 
            this.dtbfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbfrom.Location = new System.Drawing.Point(704, 56);
            this.dtbfrom.Name = "dtbfrom";
            this.dtbfrom.Size = new System.Drawing.Size(174, 27);
            this.dtbfrom.TabIndex = 65;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label20.Location = new System.Drawing.Point(324, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 19);
            this.label20.TabIndex = 64;
            this.label20.Text = "تسلسل الفاتورة";
            // 
            // txtbillnum1
            // 
            this.txtbillnum1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtbillnum1.Location = new System.Drawing.Point(216, 19);
            this.txtbillnum1.Name = "txtbillnum1";
            this.txtbillnum1.Size = new System.Drawing.Size(102, 24);
            this.txtbillnum1.TabIndex = 63;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label22.Location = new System.Drawing.Point(619, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 19);
            this.label22.TabIndex = 61;
            this.label22.Text = "إلى";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label21.Location = new System.Drawing.Point(884, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 19);
            this.label21.TabIndex = 61;
            this.label21.Text = "من";
            // 
            // cmbuser
            // 
            this.cmbuser.FormattingEnabled = true;
            this.cmbuser.Location = new System.Drawing.Point(454, 23);
            this.cmbuser.Name = "cmbuser";
            this.cmbuser.Size = new System.Drawing.Size(159, 27);
            this.cmbuser.TabIndex = 60;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label19.Location = new System.Drawing.Point(617, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 19);
            this.label19.TabIndex = 59;
            this.label19.Text = "المستخدم";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Image = global::larouge.Properties.Resources.Search_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(49, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "بحث";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmboptypes
            // 
            this.cmboptypes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboptypes.FormattingEnabled = true;
            this.cmboptypes.Location = new System.Drawing.Point(703, 26);
            this.cmboptypes.Name = "cmboptypes";
            this.cmboptypes.Size = new System.Drawing.Size(175, 24);
            this.cmboptypes.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(884, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "البند";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.Location = new System.Drawing.Point(12, 434);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 19);
            this.label12.TabIndex = 67;
            this.label12.Text = "الاجمالي";
            // 
            // txtsumtotal
            // 
            this.txtsumtotal.Enabled = false;
            this.txtsumtotal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtsumtotal.Location = new System.Drawing.Point(99, 434);
            this.txtsumtotal.Name = "txtsumtotal";
            this.txtsumtotal.Size = new System.Drawing.Size(113, 24);
            this.txtsumtotal.TabIndex = 66;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox2.Controls.Add(this.btndel);
            this.groupBox2.Controls.Add(this.btnsave);
            this.groupBox2.Controls.Add(this.cmbuser2);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtbillbookid);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.txttid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmboptypes2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtpartvalue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(218, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 122);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.LavenderBlush;
            this.btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btndel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.Red;
            this.btndel.Image = global::larouge.Properties.Resources.Trash_Delete_icon;
            this.btndel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndel.Location = new System.Drawing.Point(16, 57);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(108, 46);
            this.btndel.TabIndex = 68;
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
            this.btnsave.Location = new System.Drawing.Point(130, 57);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(108, 46);
            this.btnsave.TabIndex = 66;
            this.btnsave.Text = "حفظ";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // cmbuser2
            // 
            this.cmbuser2.Enabled = false;
            this.cmbuser2.FormattingEnabled = true;
            this.cmbuser2.Location = new System.Drawing.Point(255, 68);
            this.cmbuser2.Name = "cmbuser2";
            this.cmbuser2.Size = new System.Drawing.Size(159, 27);
            this.cmbuser2.TabIndex = 65;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label15.Location = new System.Drawing.Point(420, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 19);
            this.label15.TabIndex = 64;
            this.label15.Text = "المستخدم";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label11.Location = new System.Drawing.Point(566, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 19);
            this.label11.TabIndex = 63;
            this.label11.Text = "التاريخ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label16.Location = new System.Drawing.Point(598, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 19);
            this.label16.TabIndex = 62;
            this.label16.Text = "تسلسل الفاتورة";
            // 
            // txtbillbookid
            // 
            this.txtbillbookid.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtbillbookid.Location = new System.Drawing.Point(504, 70);
            this.txtbillbookid.Name = "txtbillbookid";
            this.txtbillbookid.Size = new System.Drawing.Size(88, 24);
            this.txtbillbookid.TabIndex = 61;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(419, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 27);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // txttid
            // 
            this.txttid.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttid.Location = new System.Drawing.Point(624, 20);
            this.txttid.Name = "txttid";
            this.txttid.ReadOnly = true;
            this.txttid.Size = new System.Drawing.Size(52, 23);
            this.txttid.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(682, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "ID";
            // 
            // cmboptypes2
            // 
            this.cmboptypes2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboptypes2.FormattingEnabled = true;
            this.cmboptypes2.Location = new System.Drawing.Point(171, 23);
            this.cmboptypes2.Name = "cmboptypes2";
            this.cmboptypes2.Size = new System.Drawing.Size(175, 24);
            this.cmboptypes2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(352, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "البند";
            // 
            // txtpartvalue
            // 
            this.txtpartvalue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpartvalue.Location = new System.Drawing.Point(16, 26);
            this.txtpartvalue.Name = "txtpartvalue";
            this.txtpartvalue.Size = new System.Drawing.Size(94, 23);
            this.txtpartvalue.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(116, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "المبلغ";
            // 
            // btnclose
            // 
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Image = global::larouge.Properties.Resources.l_ic_ne_de_sortie_déconnexion_et_production_débouché_symbole_plat_78854268;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(55, 487);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(123, 58);
            this.btnclose.TabIndex = 67;
            this.btnclose.Text = "غلق";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmotherbilltypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(952, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtsumtotal);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmotherbilltypes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مصروفات اضافية";
            this.Load += new System.EventHandler(this.frmotherbilltypes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtbfrom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtbillnum1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbuser;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmboptypes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txttid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpartvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbuser2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtbillbookid;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ComboBox cmboptypes2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtsumtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbopgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbusergrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}