namespace larouge
{
    partial class frmmoneyselproducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmoneyselproducts));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsumgain = new System.Windows.Forms.TextBox();
            this.txtsumsel = new System.Windows.Forms.TextBox();
            this.txtsumbase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtbfrom = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.txtbillnum1 = new System.Windows.Forms.TextBox();
            this.cmbcustomer1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.cmbuser1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btmsearch = new System.Windows.Forms.Button();
            this.cmbtyps = new System.Windows.Forms.ComboBox();
            this.cmbgroups = new System.Windows.Forms.ComboBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.numcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colexpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnprint = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtsumgain);
            this.groupBox2.Controls.Add(this.txtsumsel);
            this.groupBox2.Controls.Add(this.txtsumbase);
            this.groupBox2.Location = new System.Drawing.Point(12, 480);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 88);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(221, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "صافي الربح";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(455, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "اجمالي سعر البيع";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(455, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "اجمالي سعر الشراء";
            // 
            // txtsumgain
            // 
            this.txtsumgain.Enabled = false;
            this.txtsumgain.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtsumgain.Location = new System.Drawing.Point(57, 16);
            this.txtsumgain.Name = "txtsumgain";
            this.txtsumgain.Size = new System.Drawing.Size(148, 24);
            this.txtsumgain.TabIndex = 3;
            this.txtsumgain.Text = "0";
            // 
            // txtsumsel
            // 
            this.txtsumsel.Enabled = false;
            this.txtsumsel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtsumsel.Location = new System.Drawing.Point(320, 54);
            this.txtsumsel.Name = "txtsumsel";
            this.txtsumsel.Size = new System.Drawing.Size(113, 24);
            this.txtsumsel.TabIndex = 3;
            this.txtsumsel.Text = "0";
            // 
            // txtsumbase
            // 
            this.txtsumbase.Enabled = false;
            this.txtsumbase.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtsumbase.Location = new System.Drawing.Point(320, 17);
            this.txtsumbase.Name = "txtsumbase";
            this.txtsumbase.Size = new System.Drawing.Size(113, 24);
            this.txtsumbase.TabIndex = 3;
            this.txtsumbase.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpto);
            this.groupBox1.Controls.Add(this.dtbfrom);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtbillnum1);
            this.groupBox1.Controls.Add(this.cmbcustomer1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtproductname);
            this.groupBox1.Controls.Add(this.cmbuser1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btmsearch);
            this.groupBox1.Controls.Add(this.cmbtyps);
            this.groupBox1.Controls.Add(this.cmbgroups);
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1080, 457);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المنتجات المباعة";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(124, 54);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(136, 20);
            this.dtpto.TabIndex = 65;
            // 
            // dtbfrom
            // 
            this.dtbfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbfrom.Location = new System.Drawing.Point(338, 57);
            this.dtbfrom.Name = "dtbfrom";
            this.dtbfrom.Size = new System.Drawing.Size(136, 20);
            this.dtbfrom.TabIndex = 65;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label20.Location = new System.Drawing.Point(202, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 19);
            this.label20.TabIndex = 64;
            this.label20.Text = "تسلسل الفاتورة";
            // 
            // txtbillnum1
            // 
            this.txtbillnum1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtbillnum1.Location = new System.Drawing.Point(124, 21);
            this.txtbillnum1.Name = "txtbillnum1";
            this.txtbillnum1.Size = new System.Drawing.Size(72, 24);
            this.txtbillnum1.TabIndex = 63;
            // 
            // cmbcustomer1
            // 
            this.cmbcustomer1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbcustomer1.FormattingEnabled = true;
            this.cmbcustomer1.Location = new System.Drawing.Point(817, 56);
            this.cmbcustomer1.Name = "cmbcustomer1";
            this.cmbcustomer1.Size = new System.Drawing.Size(177, 24);
            this.cmbcustomer1.TabIndex = 62;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label22.Location = new System.Drawing.Point(266, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 19);
            this.label22.TabIndex = 61;
            this.label22.Text = "إلى";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label21.Location = new System.Drawing.Point(480, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 19);
            this.label21.TabIndex = 61;
            this.label21.Text = "من";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label18.Location = new System.Drawing.Point(1000, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 19);
            this.label18.TabIndex = 61;
            this.label18.Text = "العميل";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numcount,
            this.Column3,
            this.dataGridViewTextBoxColumn1,
            this.operationid,
            this.proname,
            this.colgroup,
            this.coltype,
            this.Column6,
            this.colexpdate,
            this.Column7,
            this.dataGridViewTextBoxColumn4,
            this.Column8,
            this.Column5,
            this.Column4,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(8, 87);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 361);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // txtproductname
            // 
            this.txtproductname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductname.Location = new System.Drawing.Point(338, 24);
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(143, 23);
            this.txtproductname.TabIndex = 20;
            // 
            // cmbuser1
            // 
            this.cmbuser1.FormattingEnabled = true;
            this.cmbuser1.Location = new System.Drawing.Point(563, 56);
            this.cmbuser1.Name = "cmbuser1";
            this.cmbuser1.Size = new System.Drawing.Size(159, 21);
            this.cmbuser1.TabIndex = 60;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label19.Location = new System.Drawing.Point(726, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 19);
            this.label19.TabIndex = 59;
            this.label19.Text = "المستخدم";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "اسم الصنف";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1000, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "التصنيف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(785, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "النوع";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-74, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "التصنيفات";
            // 
            // btmsearch
            // 
            this.btmsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btmsearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmsearch.ForeColor = System.Drawing.Color.Blue;
            this.btmsearch.Image = global::larouge.Properties.Resources.Search_icon;
            this.btmsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btmsearch.Location = new System.Drawing.Point(7, 37);
            this.btmsearch.Name = "btmsearch";
            this.btmsearch.Size = new System.Drawing.Size(94, 43);
            this.btmsearch.TabIndex = 16;
            this.btmsearch.Text = "بحث";
            this.btmsearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btmsearch.UseVisualStyleBackColor = true;
            this.btmsearch.Click += new System.EventHandler(this.btmsearch_Click);
            // 
            // cmbtyps
            // 
            this.cmbtyps.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtyps.FormattingEnabled = true;
            this.cmbtyps.Location = new System.Drawing.Point(642, 24);
            this.cmbtyps.Name = "cmbtyps";
            this.cmbtyps.Size = new System.Drawing.Size(137, 24);
            this.cmbtyps.TabIndex = 14;
            // 
            // cmbgroups
            // 
            this.cmbgroups.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgroups.FormattingEnabled = true;
            this.cmbgroups.Location = new System.Drawing.Point(852, 26);
            this.cmbgroups.Name = "cmbgroups";
            this.cmbgroups.Size = new System.Drawing.Size(142, 24);
            this.cmbgroups.TabIndex = 15;
            // 
            // btnclose
            // 
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Image = global::larouge.Properties.Resources.l_ic_ne_de_sortie_déconnexion_et_production_débouché_symbole_plat_78854268;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(967, 520);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(113, 48);
            this.btnclose.TabIndex = 64;
            this.btnclose.Text = "غلق";
            this.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // numcount
            // 
            this.numcount.Frozen = true;
            this.numcount.HeaderText = "م";
            this.numcount.Name = "numcount";
            this.numcount.ReadOnly = true;
            this.numcount.Width = 50;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "id";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "productid";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // operationid
            // 
            this.operationid.Frozen = true;
            this.operationid.HeaderText = "operationid";
            this.operationid.Name = "operationid";
            this.operationid.Visible = false;
            this.operationid.Width = 30;
            // 
            // proname
            // 
            this.proname.Frozen = true;
            this.proname.HeaderText = "المنتج";
            this.proname.Name = "proname";
            this.proname.ReadOnly = true;
            this.proname.Width = 200;
            // 
            // colgroup
            // 
            this.colgroup.HeaderText = "التصنيف";
            this.colgroup.Name = "colgroup";
            this.colgroup.ReadOnly = true;
            // 
            // coltype
            // 
            this.coltype.HeaderText = "نوع الوحدة";
            this.coltype.Name = "coltype";
            this.coltype.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "الوحدات المباعة";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // colexpdate
            // 
            this.colexpdate.HeaderText = "سعر شراء الوحدة";
            this.colexpdate.Name = "colexpdate";
            this.colexpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colexpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "اجمالي شراء";
            this.Column7.Name = "Column7";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "سعر بيع الوحدة";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "اجمالي بيع";
            this.Column8.Name = "Column8";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "تاريخ الفاتورة";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "تسلسل الفاتورة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "العميل";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "المستخدم";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(788, 520);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(113, 48);
            this.btnprint.TabIndex = 65;
            this.btnprint.Text = "معاينة طباعة";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // frmmoneyselproducts
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1096, 580);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmmoneyselproducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "صافي ربح مبيعات منتجات";
            this.Load += new System.EventHandler(this.frmmoneyselproducts_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsumgain;
        private System.Windows.Forms.TextBox txtsumbase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtbfrom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtbillnum1;
        private System.Windows.Forms.ComboBox cmbcustomer1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.ComboBox cmbuser1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btmsearch;
        private System.Windows.Forms.ComboBox cmbtyps;
        private System.Windows.Forms.ComboBox cmbgroups;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsumsel;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridViewTextBoxColumn numcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn proname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colexpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnprint;
    }
}