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
    public partial class frmotherbilltypes : Form
    {

        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        private string appuserid;
        private int slegrid1;

        public frmotherbilltypes()
        {
            InitializeComponent();
        }
        public frmotherbilltypes(string userid)
        {
            InitializeComponent();
            appuserid = userid;
        }

        private void frmotherbilltypes_Load(object sender, EventArgs e)
        {
            fillcmbdata(cmbuser, true, "Tusers", "username", "ID", "");
            fillcmbdata(cmboptypes, true, "Toperationtypes", "operationtypename", "operationtypeid", "");

            fillcmbdata(cmbuser2, false, "Tusers", "username", "ID", "");
            fillcmbdata(cmboptypes2, false, "Toperationtypes", "operationtypename", "operationtypeid", "");

            setselcombo(cmbuser2, appuserid);

            fillcmbgridcell(cmbusergrid, "Tusers", "username", "ID", "");
            fillcmbgridcell(cmbopgrid, "Toperationtypes", "operationtypename", "operationtypeid", "");
            
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            BindGrid();
            Bindsum();
        }
        private void BindGrid()
        {
            string selstr = "SELECT * FROM Qoperationstypes where seloperationid > 0 ";
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();
                int rownuma = 1;
                if (Convert.ToInt16(cmboptypes.SelectedValue) != 0)
                { selstr = selstr + " and operationtype =" + cmboptypes.SelectedValue; }
                
                 

                if (Convert.ToInt16(cmbuser.SelectedValue) != 0)
                { selstr = selstr + " and userid=" + cmbuser.SelectedValue; }

                if (checkBox1.Checked == true)
                {
                    selstr = selstr + " and operationtype > 3 ";
                }
 

                if (txtbillnum1.TextLength > 0)
                { selstr = selstr + " and billid = '" + txtbillnum1.Text + "' "; }

                selstr = selstr + " and datebill between # " + dtbfrom.Value.ToShortDateString() + "# and # " + dtpto.Value.ToShortDateString() + "#";

                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dataGridView1.Rows.Add(rownuma.ToString(), reader["seloperationid"].ToString(), reader["operationtype"].ToString(), reader["totalbill"].ToString(), reader["userid"].ToString(), reader["billid"].ToString(), reader["datebill"].ToString());
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
        private void Bindsum()
        {
            txtsumtotal.Text = "0";
            if (checkBox1.Checked == true)
            {
                string selstr = "SELECT sum(totalbill)as sumtotal FROM Qoperationstypes where seloperationid > 0 ";
                try
                {
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();

                    cmd.Connection = con;

                    con.Open();

                    if (Convert.ToInt16(cmboptypes.SelectedValue) != 0)
                    { selstr = selstr + " and operationtype =" + cmboptypes.SelectedValue; }



                    if (Convert.ToInt16(cmbuser.SelectedValue) != 0)
                    { selstr = selstr + " and userid=" + cmbuser.SelectedValue; }

                    if (checkBox1.Checked == true)
                    {
                        selstr = selstr + " and operationtype > 3 ";
                    }


                    if (txtbillnum1.TextLength > 0)
                    { selstr = selstr + " and billid = '" + txtbillnum1.Text + "' "; }

                    selstr = selstr + " and datebill between # " + dtbfrom.Value.ToShortDateString() + "# and # " + dtpto.Value.ToShortDateString() + "#";

                    using (cmd = new OleDbCommand(selstr, con))
                    {
                        cmd.CommandType = CommandType.Text;


                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // dataGridView2.Rows.Add();


                            txtsumtotal.Text = reader[0].ToString();

                        }



                    }



                    con.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            //avilableunits = 0;
            if (e.RowIndex >= 0)
            {
                slegrid1 = e.RowIndex;
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {

                    int proid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txttid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    setselcombo(cmboptypes2, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    txtpartvalue.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    setselcombo(cmbuser2, dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    txtbillbookid.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                }
                else
                {
                    fillnewbill();
                }
            }
        }
        private void fillcmbgridcell(DataGridViewComboBoxColumn cmbname ,string tbname,string dispalystr,string itvalue,string wherestr)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;

                con.Open();
                string selstr = "select * from "+ tbname  ;
                if (wherestr.Length > 0)
                {
                    selstr = selstr + wherestr;
                }


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;

                    dt.Columns.Add("printedString");
                    dt.Columns.Add("comboboxValue");
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();

                        dt.Rows.Add(reader[itvalue].ToString(), reader[dispalystr].ToString());
                        // dg.Rows.Add(rownum.ToString(), reader["IDgroup"].ToString(), reader["groupname"].ToString(), reader["isactive"].ToString());
                        //rownum++;
                    }
                    cmbname.DataSource = dt;
                    cmbname.DisplayMember = dt.Columns[1].ColumnName;
                    cmbname.ValueMember = dt.Columns[0].ColumnName;

                }


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ فاتورة مصروفات");
            }
        }
        private void fillnewbill()
        {
            txttid.Text = "0";
            cmboptypes2.Text = "";
            txtpartvalue.Text = "0";
            setselcombo(cmbuser2, appuserid);
            txtbillbookid.Text = "0";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (txttid.TextLength > 0 && dataGridView1.Rows[slegrid1].Cells[0].Value != null)
            {
                string id = txttid.Text.ToString();
                if (MessageBox.Show("هل تريد حذف هذه الفاتورة او العملية", "حذف فاتورة مصروفات", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    deleterecordid("Toperations", " seloperationid =" + id);
                    dataGridView1.Rows.RemoveAt(slegrid1);
                    renumbergrid(dataGridView1, 0);
                }
                Bindsum(); 
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
                MessageBox.Show(ex.ToString(), "خطأحذف فاتورة");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (checkpartsvalues() == true)
            {
                if (txttid.Text == "0")
                {
                    addnewbill();
                }
                else
                {
                    updatebill();
                }
                Bindsum();
            }

        }
        private bool checkpartsvalues()
        {
            decimal number1 = 0;
            if (decimal.TryParse(txtpartvalue.Text.Trim(), out number1) == false)
            {
                MessageBox.Show("ادخل قيمة الفاتورة بصورة صحيحة! ", "خطأ دخال قيمة فاتورة");
                return false;
            }
            if (Convert.ToDecimal(txtpartvalue.Text) <= 0)
            {
                MessageBox.Show("يجب ادخال قيمة الفاتورة اولا ", "بند مالي");
                return false;
            }

            if (cmboptypes2.Text == "")
            {
                MessageBox.Show("يجب اختيار البند", "خطأ اضافة فاتورة مصروفات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void addnewbill()
        {
            try
            {
                int operationid = Convert.ToInt16(cmboptypes2.SelectedValue.ToString());
                string operationdate = dateTimePicker1.Value.ToShortDateString();
                string sumtotal = txtpartvalue.Text;
                string billid = txtbillbookid.Text;


                OleDbConnection con = new OleDbConnection();

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();

                string upstr = "INSERT INTO Toperations (userid,customerid,operationtype,billid,datebill,totalbill)  ";
                string valuesstr = " VALUES (" + appuserid + ",1," + operationid + ",'" + billid + "', # " + operationdate + "# ," + sumtotal + ")";
                upstr = upstr + valuesstr;
                cmd.CommandText = upstr;
                //cmd = new OleDbCommand();
                int sonuc = cmd.ExecuteNonQuery();
                //con.Close();
                if (sonuc > 0)
                {
                    upstr = "select max(seloperationid) as maxid from Toperations";
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = upstr;
                     int addId = 1;
                     reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {//www.csharp-console-example.com
                         addId = Convert.ToInt16(reader[0]);
                     }
                    MessageBox.Show(" تم حفظ الفاتورة بنجاح" + "\n" + "اضغط فاتورة جديدة ", "حفظ فاتورة");
                    BindGridatlastrow(con, " where seloperationid =" + addId);
                   // dataGridView1.Rows.Add(dataGridView1.Rows.Count, addId, operationid, sumtotal, appuserid, billid, Convert.ToDateTime(operationdate).ToShortDateString());

                }
                else
                {
                    MessageBox.Show("لم يتم الحفظ");
                }
 
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأاضافة عمليه فاتورة بيع ");
            }
        }
        private void updatebill()
        {
            try
            {
                string selopid = txttid.Text;
                int operationid = Convert.ToInt16(cmboptypes2.SelectedValue.ToString());
                string operationdate = dateTimePicker1.Value.ToShortDateString();
                string sumtotal = txtpartvalue.Text;
                string billid = txtbillbookid.Text;
                string userid = cmbuser2.SelectedValue.ToString();

                OleDbConnection con = new OleDbConnection();

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();

                string upstr = "update Toperations set operationtype= " + operationid + ",billid= '" + billid + "',datebill=# " + operationdate + "# ,totalbill=" + sumtotal ;

                upstr = upstr + " where seloperationid=" + selopid;
                cmd.CommandText = upstr;
                //cmd = new OleDbCommand();
                int sonuc = cmd.ExecuteNonQuery();
                
                if (sonuc > 0)
                {
                    BindGridatrownum(con, " where seloperationid =" + selopid , slegrid1);
                    //dataGridView1.Rows[slegrid1].Cells[2].Value = operationid;
                    //dataGridView1.Rows[slegrid1].Cells[3].Value = sumtotal;
                    //dataGridView1.Rows[slegrid1].Cells[4].Value = userid;
                    //dataGridView1.Rows[slegrid1].Cells[5].Value = billid;
                    //dataGridView1.Rows[slegrid1].Cells[6].Value = operationdate;

                }
                MessageBox.Show(" تم حفظ الفاتورة بنجاح" + "\n" + "اضغط فاتورة جديدة ", "حفظ فاتورة");
                con.Close();
               
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل عمليه فاتورة بيع ");
            }
        }

        private void BindGridatlastrow(OleDbConnection con,string wherestr)
        {
            string selstr = "SELECT * FROM Qoperationstypes  " + wherestr;
            try
            {
                //OleDbConnection con = new OleDbConnection();
               // con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

              //  con.Open();
   
                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dataGridView1.Rows.Add(dataGridView1.Rows.Count, reader["seloperationid"].ToString(), reader["operationtype"].ToString(), reader["totalbill"].ToString(), reader["userid"].ToString(), reader["billid"].ToString(), reader["datebill"].ToString());
                       
                    }



                }


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BindGridatrownum(OleDbConnection con, string wherestr,int rownum)
        {
            string selstr = "SELECT * FROM Qoperationstypes  " + wherestr;
            try
            {
                //OleDbConnection con = new OleDbConnection();
                // con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                //  con.Open();

                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();

                        dataGridView1.Rows.RemoveAt(rownum);
                        DataGridViewRow dgvrow=new DataGridViewRow();
                        dgvrow.CreateCells(dataGridView1);
                        dgvrow.Cells[0].Value = (rownum+1).ToString();
                        dgvrow.Cells[1].Value=reader["seloperationid"].ToString();
                        dgvrow.Cells[2].Value=reader["operationtype"].ToString();
                        dgvrow.Cells[3].Value=reader["totalbill"].ToString();
                        dgvrow.Cells[4].Value=reader["userid"].ToString();
                        dgvrow.Cells[5].Value=reader["billid"].ToString();
                        dgvrow.Cells[6].Value=reader["datebill"].ToString();
                        

                        dataGridView1.Rows.Insert(rownum, dgvrow);
                        dataGridView1.Rows[rownum].Selected = true;
                        
                    }



                }


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
