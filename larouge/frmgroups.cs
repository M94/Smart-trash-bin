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
    public partial class frmgroups : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        static int selgrid;

        public frmgroups()
        {
            InitializeComponent();
        }

        private void frmgroups_Load(object sender, EventArgs e)
        {
            fillgridfromtable(dataGridView1, "Tgroups", 3, "");
  
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


                        dg.Rows.Add(rownum.ToString(), reader["IDgroup"].ToString(), reader["groupname"].ToString(), reader["isactive"].ToString());
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            savetablefromgrid(dataGridView1 ,"Tgroups");
        }
        private void savetablefromgrid(DataGridView dg, string tbname)
        {

         int rowd;
            int proid=0;
            string namepro = "";
            bool isactive = true;
            string upstr;
            try
            {
                for (int rowi = 0; rowi < dg.Rows.Count-1; rowi++)
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
                    if (dg.Rows[rowi].Cells[1].Value != null)
                    {
                        proid = Convert.ToInt16(dg.Rows[rowi].Cells[1].Value.ToString());

                        OleDbConnection con = new OleDbConnection();
                        
                        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                        cmd = new OleDbCommand();
                        cmd.Connection = con;
                        con.Open();
                        upstr = "UPDATE " + tbname + " SET  isactive=" + isactive + " ,groupname='" + namepro + "' where IDgroup = " + proid;

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
                        upstr = "insert into " + tbname + "( isactive,groupname) values (" + isactive + " ,'" + namepro + "')";

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
            fillgridfromtable(dataGridView1, "Tgroups", 3, "");
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (selgrid >= 0)
            {
                string id = dataGridView1.Rows[selgrid].Cells[1].Value.ToString();
                if (MessageBox.Show("هل تريد حذف هذا التصنيف", "حذف تصنيف", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    deleterecordid("Tgroups", " IDgroup =" + id);
                }
                fillgridfromtable(dataGridView1, "Tgroups", 4, "");
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
                MessageBox.Show(ex.ToString(), "خطأ حذف تصنيف");
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
                selgrid = e.RowIndex;
            }
        }
    }
}
