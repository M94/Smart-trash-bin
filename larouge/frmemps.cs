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

    public partial class frmemps : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        static OleDbDataAdapter ad;
        static int selgrid;


        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

 

        public frmemps()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmemps_Load(object sender, EventArgs e)
        {
            fillcmblevel();

            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

            fillgridfromtable(dataGridView1, "Temps", 4, "");
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
        }
        private void fillcmblevel()
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
                string selstr = "select * from Temppos";


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;

                    dt.Columns.Add("printedString");
                    dt.Columns.Add("comboboxValue");
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();

                        dt.Rows.Add(reader["ID"].ToString(), reader["posname"].ToString());
                        // dg.Rows.Add(rownum.ToString(), reader["IDgroup"].ToString(), reader["groupname"].ToString(), reader["isactive"].ToString());
                        //rownum++;
                    }
                    cmblevel.DataSource = dt;
                    cmblevel.DisplayMember = dt.Columns[1].ColumnName;
                    cmblevel.ValueMember = dt.Columns[0].ColumnName;

                }


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ مستخدم");
            }
        }
        private void fillgridfromtable(DataGridView dg, string tblname, int nm, string wherecon)
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


                        dg.Rows.Add(rownum.ToString(), reader["empid"].ToString(), reader["empname"].ToString(), reader["emppos"].ToString(), reader["salary"].ToString(), reader["empdata"].ToString(), reader["startdate"].ToString(), reader["enddate"].ToString(), reader["isactive"].ToString());
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selgrid = e.RowIndex;
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {
                                   
          
                    case "startdt1":

                        _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                        dtp.Visible = true;

                        break;
                    case "enddt1":

                        _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                        dtp.Visible = true;

                        break;
                }
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtp.Visible = false;
            renumbergrid(dataGridView1, 0);
        }

        private void renumbergrid(DataGridView dg, int colindex)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                dg.Rows[i].Cells[colindex].Value = Convert.ToString(i + 1);
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (selgrid >= 0)
            {
                string id = dataGridView1.Rows[selgrid].Cells[1].Value.ToString();
                if (MessageBox.Show("هل تريد حذف هذا الموظف؟", "حذف موظف", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    deleterecordid("Temps", " empid =" + id);
                }
                fillgridfromtable(dataGridView1, "Temps", 4, "");
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
                MessageBox.Show(ex.ToString(), "خطأ حذف بيانات موظف");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (selgrid >= 0)
            {

                if (savetablefromgrid(dataGridView1, "Temps", selgrid) == true)
                {
                    fillgridfromtable(dataGridView1, "Temps", 4, "");
                }
            }
        }

        private bool savetablefromgrid(DataGridView dg, string tbname, int rowi)
        {

            int rowd;
            int proid = 0;
            string empname = "";
            string emppos = "";
            string empdata="";
            string salary = "";
            string startdate = "";
            string enddate = "";
            bool isactive = true;
            string upstr;
            //decimal remend = 0;
            //string customerdata = "";
            rowd = rowi + 1;
            try
            {


                if (dg.Rows[rowi].Cells[2].Value != null)
                {
                    empname = dg.Rows[rowi].Cells[2].Value.ToString();

                }
                else
                {
                    MessageBox.Show("ادخل الاسم في الصف رقم " + rowd);
                    empname = "";
                    return false;
                }
                if (dg.Rows[rowi].Cells[3].Value != null)
                {
                    emppos = dg.Rows[rowi].Cells[3].Value.ToString();

                }
                else
                {
                    MessageBox.Show("ادخل الوظيفة في الصف رقم " + rowd);
                    emppos = "";
                    return false;
                }
                if (dg.Rows[rowi].Cells[4].Value != null)
                {
                   salary = dg.Rows[rowi].Cells[4].Value.ToString();

                }
                else
                {
                    MessageBox.Show("ادخل الراتب في الصف رقم " + rowd);
                    salary = "";
                    return false;
                }


                if (dg.Rows[rowi].Cells[5].Value != null)
                {
                    empdata = dg.Rows[rowi].Cells[5].Value.ToString();

                }
                else
                {

                    empdata = "";
                    
                }


                if (dg.Rows[rowi].Cells[6].Value != null)
                {
                    startdate = dg.Rows[rowi].Cells[6].Value.ToString();

                }
                else
                {
                    startdate = "";
                    
                }

                if (dg.Rows[rowi].Cells[7].Value != null)
                {
                    enddate = dg.Rows[rowi].Cells[7].Value.ToString();

                }
                else
                {
                    enddate = "";
                    
                }

                if (dg.Rows[rowi].Cells[8].Value != null)
                {
                    if (dg.Rows[rowi].Cells[8].Value.ToString() == "True")
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

                if (dg.Rows[rowi].Cells[1].Value != null)
                {
                    proid = Convert.ToInt16(dg.Rows[rowi].Cells[1].Value.ToString());

                    OleDbConnection con = new OleDbConnection();

                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    upstr = "UPDATE " + tbname + " SET  isactive=" + isactive + " ,empname='" + empname + "',emppos = " + emppos + " , salary=" + salary + ",empdata='" + empdata + "'";
                    if (startdate.Length >0 )
                    {upstr = upstr + ",startdate = #" + startdate + "#";}
                    if (enddate.Length >0 )
                    {upstr = upstr + ",enddate = #" + enddate + "#";}
                    upstr = upstr + " where empid = " + proid;

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
                    upstr = "insert into " + tbname + "( isactive,empname,emppos,salary,empdata";
                    string valuestr = " values (" + isactive + " ,'" + empname + "'," + emppos + "," + salary + ",'" + empdata + "'";
                    if (startdate.Length >0 )
                    {
                        upstr = upstr + ",startdate " ;
                        valuestr = valuestr + " ,#" + startdate + "#";
                    }
                    if (enddate.Length >0 )
                    {
                        upstr = upstr + ",enddate ";
                        valuestr = valuestr + " ,#" + enddate + "#";
                    }
                    upstr = upstr + ")"  + valuestr + ")";
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
                return true;
            }

            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }



        }
    }
}
