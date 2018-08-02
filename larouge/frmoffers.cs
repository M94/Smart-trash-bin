using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Globalization;
using System.Configuration;
using System.Data.OleDb;


namespace larouge
{
    public partial class frmoffers : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        private string offerproductid;
        private int slegrid1;

        private bool findproduct;

        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

        public frmoffers()
        {
            InitializeComponent();
            findproduct = false;
        }
        public frmoffers(string proid)
        {
            offerproductid = proid;
            InitializeComponent();
            findproduct = true;
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmoffers_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //loadgridonce = false;

            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

            fillcmbdata(cmbgroups, true, "Tgroups", "groupname", "IDgroup", "isactive = true");
            fillcmbdata(cmbtyps, true, "Tproducttypes", "producttype", "producttypeid", "isactive = true");
            if (findproduct == true)
            {
                txtproid.Text = offerproductid;
                BindGridoffer("Qoffers");
            }
 
  
        }
        private void setselcombo(ComboBox cmb, string fval)
        {
            int Selected = 0;
            int count = cmb.Items.Count;
            for (int i = 0; (i <= (count - 1)); i++)
            {
                cmb.SelectedIndex = i;
                if (Convert.ToString(cmb.SelectedValue) == fval)
                {
                    Selected = i;
                }

            }

            cmb.SelectedIndex = Selected;
        }
        private void fillcmbdata(ComboBox cmbname, bool addall, string tblname, string dsmember, string idcol, string wherecon)
        {
            OleDbConnection con = new OleDbConnection();
            try
            {
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();

                //create command    
                // OleDbCommand OCMD = null;
                string strall = "SELECT " + idcol + " ,  " + dsmember + " FROM " + tblname;

                if (wherecon.ToString().Length > 0)
                {
                    strall = strall + " where " + wherecon;
                }
                cmd.CommandText = strall;
                //execute command
                reader = cmd.ExecuteReader();

                //load datareader to datatable       
                DataTable DT = new DataTable();

                DT.Load(reader);
                if (addall == true)
                {
                    DataRow dr = DT.NewRow();
                    dr[0] = 0;
                    dr[1] = "غير محدد";
                    DT.Rows.InsertAt(dr, 0);
                }
                //attach datatable to combobox
                cmbname.DisplayMember = dsmember;
                cmbname.ValueMember = idcol;
                cmbname.DataSource = DT;

                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            if (checkBox1.Checked == true)
            {
                BindGridoffer("Qoffers");
            }
            else
            {
                BindGridoffer("Qproductandoffer");
            }


        }

        private void BindGridoffer(string tblname)
        {
            string selstr = "SELECT * FROM " + tblname + "  where productid > 0 ";
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();
                int rownuma = 1;
                if (txtproid.TextLength > 0)
                {
                    if (Convert.ToInt16(txtproid.Text) > 0)
                    {
                        selstr = selstr + " and proid = " + txtproid.Text;
                    }
                }
                if (Convert.ToInt16(cmbgroups.SelectedValue) != 0)
                { selstr = selstr + " and productgroupid=" + cmbgroups.SelectedValue; }
                if (Convert.ToInt16(cmbtyps.SelectedValue) != 0)
                { selstr = selstr + " and typeid=" + cmbtyps.SelectedValue; }
                if (txtproductname.TextLength > 0)
                { selstr = selstr + " and productname like '%" + txtproductname.Text + "%' "; }

                // = selstr + " and isactive=true";

                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dataGridView1.Rows.Add(rownuma.ToString(), reader["ID"].ToString(), reader["proid"].ToString(), reader["productname"].ToString(), reader["groupname"].ToString(), reader["producttype"].ToString(), reader["offertype"].ToString(), reader["offerprice"].ToString(), reader["staratdate"].ToString(), reader["enddate"].ToString(), reader["numofpeaces"].ToString());
                        rownuma++;
                    }



                }



                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            renumbergrid(dataGridView1, 0);
        }
        private void renumbergrid(DataGridView dg, int colindex)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                dg.Rows[i].Cells[colindex].Value = Convert.ToString(i + 1);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                slegrid1 = e.RowIndex;

                
                    switch (dataGridView1.Columns[e.ColumnIndex].Name)
                    {
                        case "colmagdate":

                            _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                            dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                            dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                            dtp.Visible = true;

                            break;
                        case "colexpdate":

                            _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                            dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                            dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                            dtp.Visible = true;

                            break;
                    }
               

            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (slegrid1 >= 0)
            {
                string id;
                if (MessageBox.Show("هل تريد حذف هذا المنتج من العروض ؟" + "\r\n" + dataGridView1.Rows[slegrid1].Cells[3].Value.ToString(), "حذف مستخدم", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    id = dataGridView1.Rows[slegrid1].Cells[1].Value.ToString();
                    deleterecordid("Toffers", " ID =" + id);
                }
            }
        }
        private void deleterecordid(string tblname, string wherestr)
        {
            try
            {
                //decimal remendmony = Convert.ToDecimal(remend);

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                cmd = new OleDbCommand();
                upstr = "delete * from " + tblname;
                if (wherestr.Length > 0)
                {
                    upstr = upstr + "  WHERE " + wherestr;

                }
                cmd.CommandText = upstr;
                cmd.Connection = con;
                int sonuc2 = cmd.ExecuteNonQuery();
                if (sonuc2 > 0)
                {
                    MessageBox.Show("تم الحذف");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ حذف عرض");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (slegrid1 >= 0)
            {
                if (checkoffervalue(slegrid1, dataGridView1) == true)
                {

                    if (dataGridView1.Rows[slegrid1].Cells[1].Value != "" )
                    {
                        string id = dataGridView1.Rows[slegrid1].Cells[1].Value.ToString();
                        Updateoffer(id, slegrid1);
                    }
                    else
                    {
                        insertnewoffer(slegrid1);
                    }
                }
            }
        }
        private bool checkoffervalue(int rowi ,DataGridView dg)
        {
            int rowd = rowi + 1;
            if (dg.Rows[rowi].Cells[7].Value != null)
            {
                decimal number = 0;
                
                if (decimal.TryParse(dg.Rows[rowi].Cells[7].Value.ToString().Trim(), out number) != true)
                {
                    MessageBox.Show("ادخل سعر الوحدة في العرض بصورة صحيحة في الصف رقم " + rowd, "عرض اسعار");
                    return false;
                }


            }
            else
            {
                MessageBox.Show("ادخل سعر الوحدة في العرض في الصف رقم " + rowd, "عرض اسعار");
                
                return false;
            }
            return true;
        }
        private void Updateoffer(string id, int rowi)
        {
            int rowd;
            int proid = 0;
            string priceoffer = "";
            string offerstr = "";
            string offersdate="";
            string offeredate="";
            string offerunits="";
            string upstr;
            //decimal remend = 0;
            //string customerdata = "";
            rowd = rowi + 1;
            try
            {

                if (dataGridView1.Rows[rowi].Cells[6].Value != null)
                {
                    offerstr = dataGridView1.Rows[rowi].Cells[6].Value.ToString();

                }

                if (dataGridView1.Rows[rowi].Cells[7].Value != null)
                {
                    priceoffer = dataGridView1.Rows[rowi].Cells[7].Value.ToString();

                }

               if (dataGridView1.Rows[rowi].Cells[8].Value != null)
                {
                    offersdate = dataGridView1.Rows[rowi].Cells[8].Value.ToString();

                }
                if (dataGridView1.Rows[rowi].Cells[9].Value != null)
                {
                    offeredate = dataGridView1.Rows[rowi].Cells[9].Value.ToString();

                }

                if (dataGridView1.Rows[rowi].Cells[10].Value != null)
                {
                    
                    if (dataGridView1.Rows[rowi].Cells[10].Value != "True")
                    {
                        int number = 0;
                        if (int.TryParse(dataGridView1.Rows[rowi].Cells[10].Value.ToString().Trim(), out number)== true)
                        {
                           offerunits = dataGridView1.Rows[rowi].Cells[10].Value.ToString();
                        }
                    }
                }
  
    
                    proid = Convert.ToInt16(dataGridView1.Rows[rowi].Cells[2].Value.ToString());

                    OleDbConnection con = new OleDbConnection();

                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    upstr = "UPDATE Toffers SET  offerprice=" + priceoffer ;
                if (offerstr.Length >0 )
                {
                    upstr = upstr + ",offertype = '" + offerstr + "'" ;
                }
                else
                {
                    upstr = upstr + ",offertype =null";
                }
                if (offersdate.Length >0 )
                {
                    upstr = upstr + " , staratdate=#" + offersdate + "#" ;
                }
                else
                {
                    upstr = upstr + ",staratdate =null";
                }
                if (offeredate.Length >0 )
                {
                    upstr = upstr + " , enddate=#" + offeredate + "#" ;
                }
                else
                {
                    upstr = upstr + ",enddate =null";
                }

                if (offerunits.Length >0 )
                {
                    upstr = upstr + " , numofpeaces=" + offerunits  ;
                }
                else
                {
                    upstr = upstr + ",numofpeaces =null";
                }

                 upstr = upstr + "  where ID = " + id;

                    cmd.CommandText = upstr;

                    int sonuc = cmd.ExecuteNonQuery();
                    con.Close();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("تم التحديث", "تحديث عرض");
                    }
                    else
                    {
                        MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rowd);
                    }

             

            }

            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
                
            }


        }
        private void insertnewoffer(int rowi)
        {

            int rowd;
            int proid = 0;
            string priceoffer = "";
            string offerstr = "";
            string offersdate = "";
            string offeredate = "";
            string offerunits = "";
            string upstr;
            string valuesstr;
            //decimal remend = 0;
            //string customerdata = "";
            rowd = rowi + 1;
            try
            {

                if (dataGridView1.Rows[rowi].Cells[6].Value != "")
                {
                    offerstr = dataGridView1.Rows[rowi].Cells[6].Value.ToString();

                }

                if (dataGridView1.Rows[rowi].Cells[7].Value != "")
                {
                    priceoffer = dataGridView1.Rows[rowi].Cells[7].Value.ToString();

                }

                if (dataGridView1.Rows[rowi].Cells[8].Value != "")
                {
                    offersdate = dataGridView1.Rows[rowi].Cells[8].Value.ToString();

                }
                if (dataGridView1.Rows[rowi].Cells[9].Value != "")
                {
                    offeredate = dataGridView1.Rows[rowi].Cells[9].Value.ToString();

                }

                if (dataGridView1.Rows[rowi].Cells[10].Value != "")
                {

                    if (dataGridView1.Rows[rowi].Cells[10].Value != "True")
                    {
                        int number = 0;
                        if (int.TryParse(dataGridView1.Rows[rowi].Cells[10].Value.ToString().Trim(), out number) != true)
                        {
                            offerunits = dataGridView1.Rows[rowi].Cells[10].Value.ToString();
                        }
                    }
                }


                proid = Convert.ToInt16(dataGridView1.Rows[rowi].Cells[2].Value.ToString());

                OleDbConnection con = new OleDbConnection();

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                upstr = "insert into  Toffers ( productIdstore,offerprice";
                valuesstr = " values (" + proid + " ," + priceoffer;

                if (offerstr.Length > 0)
                {
                    upstr = upstr + ",offertype ";
                    valuesstr = valuesstr + "," + offerstr;
                }
                if (offersdate.Length > 0)
                {
                    upstr = upstr + ",staratdate ";
                    valuesstr=valuesstr +",#" + offersdate + "#";
                    
                }
  
                if (offeredate.Length > 0)
                {
                    upstr = upstr + ",enddate ";
                    valuesstr = valuesstr + ",#" + offeredate + "#";
                    
                }

                if (offerunits.Length > 0)
                {
                  
                    upstr = upstr + ",numofpeaces ";
                    valuesstr = valuesstr + "," + offerunits ;
                }
                upstr = upstr + ")";
                valuesstr = valuesstr + ")";
                upstr = upstr + valuesstr;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                con.Close();
                if (sonuc > 0)
                {
                    MessageBox.Show("تم اضافة العرض بنجاح", "اضافة عرض");
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء اضافة العرض   " + rowd);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString (), "خطأ اثناء اضافة العرض   " + rowd);
            }
                

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }
    }
}
