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
    public partial class frmusers : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        static OleDbDataAdapter ad;
        static int selgrid;

        public frmusers()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmusers_Load(object sender, EventArgs e)
        {
            fillcmblevel();

            
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
                string selstr = "select * from Tlevels";


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;

                    dt.Columns.Add("printedString");
                    dt.Columns.Add("comboboxValue");
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();

                        dt.Rows.Add(reader["levelid"].ToString(), reader["levelname"].ToString());
                        // dg.Rows.Add(rownum.ToString(), reader["IDgroup"].ToString(), reader["groupname"].ToString(), reader["isactive"].ToString());
                        //rownum++;
                    }
   

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


                        dg.Rows.Add(rownum.ToString(), reader["ID"].ToString(), reader["username"].ToString(), reader["userpassword"].ToString(), reader["userlevel"].ToString(), reader["isactive"].ToString());
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

        private void btndel_Click(object sender, EventArgs e)
        {
           
   
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
                upstr = "delete * from "+ tblname ;
                if (wherestr.Length > 0)
                {
                    upstr= upstr +"  WHERE " + wherestr;
                    
                }
                cmd.CommandText = upstr;
                cmd.Connection = con;
                int sonuc2 = cmd.ExecuteNonQuery();
                if (sonuc2 >0)
                {
                    MessageBox.Show("تم الحذف");
                }
                con.Close();
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ تعديل بيانات مستخدم");
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                selgrid = e.RowIndex;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
 
        }

        private bool savetablefromgrid(DataGridView dg, string tbname,int rowi)
        {

            int rowd;
            int proid = 0;
            string namepro = "";
            string userpassword="";
            string userlevel;
            bool isactive = true;
            string upstr;
            //decimal remend = 0;
            //string customerdata = "";
            rowd=rowi+1;
            try
            {
               

                    if (dg.Rows[rowi].Cells[2].Value != null)
                    {
                        namepro = dg.Rows[rowi].Cells[2].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("ادخل الاسم في الصف رقم " + rowd);
                        namepro = "";
                        return false;
                    }
                    if (dg.Rows[rowi].Cells[3].Value != null)
                    {
                        userpassword = dg.Rows[rowi].Cells[3].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("ادخل كلمة المرور في الصف رقم " + rowd);
                        userpassword = "";
                        return false;
                    }
                    if (dg.Rows[rowi].Cells[4].Value != null)
                    {
                        userlevel = dg.Rows[rowi].Cells[4].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("ادخل المستوى في الصف رقم " + rowd);
                        userpassword = "";
                        return false;
                    }
                    if (dg.Rows[rowi].Cells[5].Value != null)
                    {
                        if (dg.Rows[rowi].Cells[5].Value.ToString() == "True")
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
                        upstr = "UPDATE " + tbname + " SET  isactive=" + isactive + " ,username='" + namepro + "',userpassword = '" + userpassword + "' , userlevel=" + userlevel + " where ID = " + proid;

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
                        upstr = "insert into " + tbname + "( isactive,username,userpassword,userlevel) values (" + isactive + " ,'" + namepro + "','" + userpassword + "'," + userlevel + ")";

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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void renumbergrid(DataGridView dg, int colindex)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                dg.Rows[i].Cells[colindex].Value = Convert.ToString(i + 1);
            }
        }
    }
}
