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
    public partial class frmmain : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        public frmmain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
     

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            fillcmbdata(cmbgroups, true, "mansak", "mashaername", "mashaerid", "");
            fillcmbdata(cmbtyps, true, "regons", "regonname", "regonid", "");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button6.BackColor = Color.Red;
                
            }
            else
            {
                button6.BackColor = Color.Green;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button7.BackColor = Color.Red;

            }
            else
            {
                button7.BackColor = Color.Green;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button8.BackColor = Color.Red;

            }
            else
            {
                button8.BackColor = Color.Green;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button15.BackColor = Color.Red;

            }
            else
            {
                button15.BackColor = Color.Green;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button9.BackColor = Color.Red;

            }
            else
            {
                button9.BackColor = Color.Green;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button14.BackColor = Color.Red;

            }
            else
            {
                button14.BackColor = Color.Green;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button13.BackColor = Color.Red;

            }
            else
            {
                button13.BackColor = Color.Green;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button12.BackColor = Color.Red;

            }
            else
            {
                button12.BackColor = Color.Green;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button11.BackColor = Color.Red;

            }
            else
            {
                button11.BackColor = Color.Green;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button10.BackColor = Color.Red;

            }
            else
            {
                button10.BackColor = Color.Green;
            }
        }

    }
}
