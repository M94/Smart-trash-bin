using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using System.Data.OleDb;

namespace larouge
{
    public partial class frmlogin : Form
    {
   // static OleDbConnection con;
    static OleDbCommand cmd;
    static OleDbDataReader reader;
    public int userlevel;
    private string usernamesel;
    private string useridsel;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

            fillcmbdata(comp, false, "Tlevels", "levelname", "levelid", "");
           // setselcombo(comp, appuserid);
 
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
                //OleDbCommand OCMD = null;
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

            if (checknotnulltxtbox() == true)
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                try
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT userlevel as usl,ID FROM Tusers where username='" + txtusername.Text + "' and userpassword='" + txtpassword.Text + "'";
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {//www.csharp-console-example.com

                            //MessageBox.Show("welcome");
                            userlevel = Convert.ToInt16(reader.GetValue(0));
                            useridsel = Convert.ToString(reader.GetValue(1));
                            usernamesel = txtusername.Text;
                            //MessageBox.Show(userlevel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة", "خطأ دخول", MessageBoxButtons.OK);

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("غير قادر على الاتصال بقاعدة البيانات ؟!");
                }
                
            }
            switch (userlevel)
            {
                case 0:

                    break;
                case 1:
                 this.Hide();
                 //frmmain fm = new frmmain();
                 MDIParent1 fm = new MDIParent1();
                    
                    fm.Show();                
                    break;
                case 2:
                    break;
            }
            
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checknotnulltxtbox()
        {
            if  (txtusername.TextLength==0 )
            {
                MessageBox.Show("ادخل اسم المستخدم", "ادخل اسم المستخدم", MessageBoxButtons.OK);
                txtusername.Focus();
                return false;
            }
            else
            {

                if (txtpassword.TextLength == 0)
                {
                    MessageBox.Show("ادخل كلمة المرور", "ادخل كلمة المرور", MessageBoxButtons.OK);
                    txtpassword.Focus();
                    return false;
                }
                return true;
               
            }
        }

        private void comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comp.SelectedIndex == 1)
            {
                fillcmbdata(COMPCAMP, false, "companies", "companyname", "companyid", " companylevel='2'");
                COMPCAMP.Visible = true;
            }
            else if (comp.SelectedIndex == 0)
            {

                COMPCAMP.Visible = false;
            }
            else
            {
                fillcmbdata(COMPCAMP, false, "companies", "companyname", "companyid", " companylevel='3'");
            }
        }

    }
}
