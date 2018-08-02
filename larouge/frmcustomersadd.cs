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
    public partial class frmcustomersadd : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        private string appuserid;
        private int selcustomer;
        private string oldpartvalue;
        private int selgrid1;

        DateTimePicker dtp2 = new DateTimePicker();
      //  Rectangle _Rectangle2;

        public frmcustomersadd()
        {
            InitializeComponent();
        }
        public frmcustomersadd(string userid)
        {
            InitializeComponent();
            appuserid = userid;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmcustomersadd_Load(object sender, EventArgs e)
        {
            fillcmbdata(cmbuser, false, "Tusers", "username", "ID", "");
            setselcombo(cmbuser, appuserid);

            dataGridView2.Controls.Add(dtp2);
            dtp2.Visible = false;
            dtp2.Format = DateTimePickerFormat.Custom;
            dtp2.TextChanged += new EventHandler(dtp_TextChange2);
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
            string wherestr = "";
            switch (cmbisactive.Text.ToString())
            {
                case "الكل":
                    break;
                case "النشط فقط":
                    wherestr = " where isactive=true";
                    break;
                case "الغير نشط فقط":
                    wherestr = " where isactive=false";
                    break;
                case "لديه حساب غير مسدد":
                    wherestr = " where remendermony > 0";
                    break;
            }

            if (txtproductname.TextLength > 0)
            { wherestr = wherestr + " and customername like '%" + txtproductname.Text + "%' "; }
            fillgridfromtable(dataGridView1, "Tcustomers", 3, wherestr);
        }
        private void fillgridfromtable(DataGridView dg, string tblname, int nm, string wherecon)
        {
            dataGridView1.Rows.Clear();
            string selstr = "SELECT * FROM  " + tblname;
            int rownum = 1;
            if (wherecon.ToString().Length != 0)
            {
                selstr = selstr + wherecon;
            }
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dg.Rows.Add(rownum.ToString(), reader["customerid"].ToString(), reader["customername"].ToString(), reader["isactive"].ToString(), reader["remendermony"].ToString(), reader["customerdata"].ToString());
                        rownum++;
                    }



                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            savetablefromgrid(dataGridView1, "Tcustomers");
        }
        private void savetablefromgrid(DataGridView dg, string tbname)
        {

            int rowd;
            int proid = 0;
            string namepro = "";
            bool isactive = true;
            string upstr;
            decimal remend = 0;
            string customerdata="";
            try
            {
                for (int rowi = 0; rowi < dg.Rows.Count - 1; rowi++)
                {
                    rowd = rowi + 1;

                    if (dg.Rows[rowi].Cells[2].Value != null)
                    {
                        namepro = dg.Rows[rowi].Cells[2].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("ادخل الاسم في الصف رقم " + rowd);
                        namepro = "";
                    }
                    if (dg.Rows[rowi].Cells[3].Value != null)
                    {
                        if (dg.Rows[rowi].Cells[3].Value.ToString() == "True")
                        {
                            isactive = true;
                        }
                        else
                        {
                            isactive = false;
                        }
                    }
                    else
                    {
                        isactive = false;
                    }
                    if (dg.Rows[rowi].Cells[4].Value != null)
                    {
                        remend =Convert.ToDecimal( dg.Rows[rowi].Cells[4].Value.ToString());

                    }
                    if (dg.Rows[rowi].Cells[5].Value != null)
                    {
                        customerdata = dg.Rows[rowi].Cells[5].Value.ToString();

                    }
                    if (dg.Rows[rowi].Cells[1].Value != null)
                    {
                        proid = Convert.ToInt16(dg.Rows[rowi].Cells[1].Value.ToString());

                        OleDbConnection con = new OleDbConnection();

                        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                        cmd = new OleDbCommand();
                        cmd.Connection = con;
                        con.Open();
                        upstr = "UPDATE " + tbname + " SET  isactive=" + isactive + " ,customername='" + namepro + "',remendermony = " + remend + " , customerdata='" + customerdata + "' where customerid = " + proid;

                        cmd.CommandText = upstr;

                        int sonuc = cmd.ExecuteNonQuery();
                        con.Close();
                        if (sonuc > 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rowd);
                        }

                    }
                    else
                    {

                        OleDbConnection con = new OleDbConnection();

                        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                        cmd = new OleDbCommand();
                        cmd.Connection = con;
                        con.Open();
                        upstr = "insert into " + tbname + "( isactive,customername,remendermony,customerdata) values (" + isactive + " ,'" + namepro + "'," + remend + ",'" + customerdata+"')";

                        cmd.CommandText = upstr;

                        int sonuc = cmd.ExecuteNonQuery();
                        con.Close();
                        if (sonuc > 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rowd);
                        }

                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            string wherestr = "";
            switch (cmbisactive.Text.ToString())
            {
                case "الكل":
                    break;
                case "النشط فقط":
                    wherestr = " where isactive=true";
                    break;
                case "الغير نشط فقط":
                    wherestr = " where isactive=false";
                    break;
                case "لديه حساب غير مسدد":
                    wherestr = " where remendermony > 0";
                    break;
            }

            if (txtproductname.TextLength > 0)
            { wherestr = wherestr + " and customername like '%" + txtproductname.Text + "%' "; }
            fillgridfromtable(dataGridView1, "Tcustomers", 3, wherestr);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                selgrid1 = e.RowIndex;

                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    selcustomer = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lblcustomerid.Text = Convert.ToString(selcustomer);
                    
                }
                else
                {
                    selcustomer = 0;
                    lblcustomerid.Text = "0";
                }
                fillgridcustomer(dataGridView2, "QCustomerparts", 4, " where customerid=" + selcustomer + " ORDER BY payeddate DESC");
            }
        }
        private void fillgridcustomer(DataGridView dg, string tblname, int nm, string wherecon)
        {
            dg.Rows.Clear();
            string selstr = "SELECT * FROM  " + tblname;
            int rownum = 1;
            if (wherecon.ToString().Length != 0)
            {
                selstr = selstr + wherecon;
            }
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dg.Rows.Add(rownum.ToString(), reader["ID"].ToString(),  reader["payeddate"].ToString(), reader["payedvalue"].ToString(), reader["username"].ToString());
                        rownum++;
                    }



                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    txtpartid.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dateTimePicker1.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtpartvalue.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    oldpartvalue = txtpartvalue.Text;
                }
                else
                {
                    txtpartid.Text = "";
                    txtpartvalue.Text = "";
                }
  
            }
        }
        private void dtp_TextChange2(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = dtp2.Text.ToString();
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void btnupdatepro_Click(object sender, EventArgs e)
        {
            if (txtpartid.Text == "")
            {
                MessageBox.Show("يجب اختيار القسط المراد تعديله اولا " + "\n" + "اذا كان جديد اضغط اضافة جديد", "تعديل قسط");
                
            }
            else  if (checkpartsvalues() == true)
            {
                returncustomerparts(Convert.ToInt16(lblcustomerid.Text), oldpartvalue);
                try
                {
                    decimal remendmony = Convert.ToDecimal(txtpartvalue.Text);

                    OleDbConnection con = new OleDbConnection();
                    string upstr;
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    con.Open();
                    cmd = new OleDbCommand();
                    upstr = "UPDATE Tcustomers SET  remendermony=(remendermony - " + remendmony + ") WHERE customerid=" + lblcustomerid.Text;
                    cmd.CommandText = upstr;
                    cmd.Connection = con;
                    int sonuc2 = cmd.ExecuteNonQuery();
                    if (sonuc2 > 0)
                    { 
                        cmd = new OleDbCommand();
                        upstr = "UPDATE Tcustomerpartsmony SET  payedvalue= " + txtpartvalue.Text + ",payeddate=#" + dateTimePicker1.Text + "# WHERE ID=" + txtpartid.Text;
                        cmd.CommandText = upstr;
                        cmd.Connection = con;
                        sonuc2 = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("تم الحفظ");
                    updatecustomerrow(Convert.ToInt16(lblcustomerid.Text), selgrid1);
                    fillgridcustomer(dataGridView2, "QCustomerparts", 4, " where customerid=" + selcustomer + " ORDER BY payeddate DESC");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "خطأ تعديل حساب عميل");
                }

            }
        }
        private bool checkpartsvalues()
        {
           
            if (Convert.ToDecimal(txtpartvalue.Text) <= 0)
            {
                MessageBox.Show("يجب ادخال قيمة القسط المراد تعديله اولا ", "تعديل قسط");
                return false;
            }
            return true;
        }

        private void btnnewpro_Click(object sender, EventArgs e)
        {
            if (checkpartsvalues() == true)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection();

                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();

                    string upstr = "INSERT INTO Tcustomerpartsmony (userid,customerid,payeddate,payedvalue)  ";
                    string valuesstr = " VALUES (" + appuserid + "," + lblcustomerid.Text + ",#" + dateTimePicker1.Text + "#," + txtpartvalue.Text + ")";
                    upstr = upstr + valuesstr;
                    cmd.CommandText = upstr;
                    //cmd = new OleDbCommand();
                    int sonuc = cmd.ExecuteNonQuery();
                    con.Close();
                    if (sonuc > 0)
                    {
                        savecustomerparts(Convert.ToInt16( lblcustomerid.Text), txtpartvalue.Text);
                    }
                    MessageBox.Show("تم الحفظ");
                    fillgridcustomer(dataGridView2, "QCustomerparts", 4, " where customerid=" + selcustomer + " ORDER BY payeddate DESC");
                    updatecustomerrow(Convert.ToInt16(lblcustomerid.Text), selgrid1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "خطأ اضافة قسط جديد");
                }
            }
        }

        private void savecustomerparts(int customerid, string remend)
        {
            try
            {
                decimal remendmony = Convert.ToDecimal(remend);

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                cmd = new OleDbCommand();
                upstr = "UPDATE Tcustomers SET  remendermony=(remendermony - " + remendmony + ") WHERE customerid=" + customerid;
                cmd.CommandText = upstr;
                cmd.Connection = con;
                int sonuc2 = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل حساب عميل");
            }

        }
        private void updatecustomerrow(int customerid, int rownum)
        {
            try
            {
                

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                cmd = new OleDbCommand();
                upstr = "select * from Tcustomers  WHERE customerid=" + customerid;
                cmd.CommandText = upstr;
                cmd.Connection = con;
                cmd.CommandText = upstr;
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {//www.csharp-console-example.com
                    dataGridView1.Rows[rownum].Cells[4].Value = Convert.ToString(reader["remendermony"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل حساب عميل");
            }
        }
        private void returncustomerparts(int customerid, string remend)
        {
            try
            {
                decimal remendmony = Convert.ToDecimal(remend);

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                cmd = new OleDbCommand();
                upstr = "UPDATE Tcustomers SET  remendermony=(remendermony + " + remendmony + ") WHERE customerid=" + customerid;
                cmd.CommandText = upstr;
                cmd.Connection = con;
                int sonuc2 = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل حساب عميل");
            }

        }

        private void btndel_Click(object sender, EventArgs e)
        {

        }

        private void btndelpro_Click(object sender, EventArgs e)
        {
            if (txtpartid.TextLength > 0)
            {
                if (MessageBox.Show("هل تريد حذف هذا القسط", "حذف قسط", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    deletcustomerpart(selcustomer, Convert.ToInt16(txtpartid.Text), Convert.ToDecimal(txtpartvalue.Text));
                }
            }
        }
        private void deletcustomerpart(int customerid, int partid, decimal partvalue)
        {
            try
            {
                //decimal remendmony = Convert.ToDecimal(remend);

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                cmd = new OleDbCommand();
                upstr = "UPDATE Tcustomers SET  remendermony=(remendermony + " + partvalue + ") WHERE customerid=" + customerid;
                cmd.CommandText = upstr;
                cmd.Connection = con;
                int sonuc2 = cmd.ExecuteNonQuery();
                if (sonuc2 > 0)
                {
                    cmd = new OleDbCommand();
                    upstr = "delete * from Tcustomerpartsmony  WHERE ID=" + partid;
                    cmd.CommandText = upstr;
                    cmd.Connection = con;
                    sonuc2 = cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("تم الحذف");

                con.Close();
                updatecustomerrow(Convert.ToInt16(lblcustomerid.Text), selgrid1);
                fillgridcustomer(dataGridView2, "QCustomerparts", 4, " where customerid=" + selcustomer + " ORDER BY payeddate DESC");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل حساب عميل");
            }
        }
    }
}
