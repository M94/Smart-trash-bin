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
    public partial class frmoperationtypes : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        static int selgrid;
        static int operationtypeid;
        static string operationtypename;

        public frmoperationtypes()
        {
            InitializeComponent();
        }

        private void frmoperationtypes_Load(object sender, EventArgs e)
        {
            fillgridfromtable(dataGridView1, "Toperationtypes", 3, "");

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


                        dg.Rows.Add(rownum.ToString(), reader["operationtypeid"].ToString(), reader["operationtypename"].ToString());
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {

                selgrid = e.RowIndex;
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    operationtypeid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    operationtypename = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    

                }
                else
                {
                    operationtypeid = 0;
                    operationtypename = "0";
                }
                txtID.Text = Convert.ToString(operationtypeid);
                txtponame.Text = operationtypename;
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (selgrid >= 0)
            {

                if (savetablefromgrid(dataGridView1, "Toperationtypes", selgrid) == true)
                {
                    fillgridfromtable(dataGridView1, "Toperationtypes", 4, "");
                }
            }
        }

        private bool savetablefromgrid(DataGridView dg, string tbname, int rowi)
        {

            int rowd;
            int proid = 0;
            string namepro = "";
            
            string upstr;
            //decimal remend = 0;
            //string customerdata = "";
            rowd = rowi + 1;
            try
            {


                if (txtponame.TextLength > 3 )
                {
                    namepro = txtponame.Text.ToString();

                }
                else
                {
                    MessageBox.Show("ادخل الاسم في الصف رقم " + rowd);
                    namepro = "";
                    return false;
                }
 
 
                if (dg.Rows[rowi].Cells[1].Value != null)
                {
                    proid = Convert.ToInt16(dg.Rows[rowi].Cells[1].Value.ToString());

                    OleDbConnection con = new OleDbConnection();

                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();
                    upstr = "UPDATE " + tbname + " SET  operationtypename='" + namepro + "' where operationtypeid = " + proid;

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
                    upstr = "insert into " + tbname + "( operationtypename) values ('" + namepro + "')";

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

        private void btndel_Click(object sender, EventArgs e)
        {
            if (txtID.TextLength > 0  )
            {
                string id = txtID.Text;
                if (Convert.ToInt16(txtID.Text) > 3)
                {

                    if (MessageBox.Show("هل تريد حذف هذا البند" + txtponame.Text + "?", "حذف بند", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        deleterecordid("Toperationtypes", " operationtypeid =" + id);
                    }
                    fillgridfromtable(dataGridView1, "Toperationtypes", 4, "");
                }
                else
                {
                    MessageBox.Show("لا يمكن حذف هذا البند" + txtponame.Text + "?", "حذف بند");
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
                MessageBox.Show(ex.ToString(), "خطأ حذف بند مصروفات");
            }
        }
    }
}
