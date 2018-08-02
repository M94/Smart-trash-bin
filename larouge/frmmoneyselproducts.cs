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
    public partial class frmmoneyselproducts : Form
    {

        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;


        public frmmoneyselproducts()
        {
            InitializeComponent();
        }

        private void frmmoneyselproducts_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //loadgridonce = false;
            fillcmbdata(cmbgroups, true, "Tgroups", "groupname", "IDgroup", "isactive = true");
            fillcmbdata(cmbtyps, true, "Tproducttypes", "producttype", "producttypeid", "isactive = true");
            fillcmbdata(cmbcustomer1, true, "Tcustomers", "customername", "customerid", "isactive = true");
            fillcmbdata(cmbuser1, true, "Tusers", "username", "ID", "");

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

        private void btmsearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            BindGrid();

        }

        private void BindGrid()
        {
            string selstr = "SELECT * FROM Qproductsforreturn where productid > 0 ";
            txtsumbase.Text = "0";
            txtsumsel.Text = "0";
            txtsumgain.Text = "0";
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();
                int rownuma = 1;
                if (Convert.ToInt16(cmbgroups.SelectedValue) != 0)
                { selstr = selstr + " and productgroupid=" + cmbgroups.SelectedValue; }
                if (Convert.ToInt16(cmbtyps.SelectedValue) != 0)
                { selstr = selstr + " and typeid=" + cmbtyps.SelectedValue; }
                if (txtproductname.TextLength > 0)
                { selstr = selstr + " and productname like '%" + txtproductname.Text + "%' "; }

                if (Convert.ToInt16(cmbuser1.SelectedValue) != 0)
                { selstr = selstr + " and userid=" + cmbuser1.SelectedValue; }

                if (Convert.ToInt16(cmbcustomer1.SelectedValue) != 0)
                { selstr = selstr + " and customerid=" + cmbcustomer1.SelectedValue; }

                if (txtbillnum1.TextLength > 0)
                { selstr = selstr + " and billid = '" + txtbillnum1.Text + "' "; }

                selstr = selstr + " and datebill between # " + dtbfrom.Value.ToShortDateString() + "# and # " + dtpto.Value.ToShortDateString() + "#";
                decimal sumbase=0;
                decimal sumselprice=0;
                decimal totgain=0;

                decimal baeprice=0;
                decimal selprice=0;
                int units=0;
                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();
                        baeprice = Convert.ToDecimal(reader["pricevalueofonebase"].ToString());
                        selprice = Convert.ToDecimal(reader["pricevalueofone"].ToString());
                        units = Convert.ToUInt16(reader["numofunits"].ToString());

                        dataGridView1.Rows.Add(rownuma.ToString(), reader["id"].ToString(), reader["productid"].ToString(), reader["operationid"].ToString(), reader["productname"].ToString(), reader["groupname"].ToString(), reader["producttype"].ToString(), reader["numofunits"].ToString(), reader["pricevalueofonebase"].ToString(), baeprice * units, reader["pricevalueofone"].ToString(), selprice * units, reader["datebill"].ToString(), reader["billid"].ToString(), reader["customername"].ToString(), reader["username"].ToString());
 

                        sumbase=sumbase+baeprice * units;
                        sumselprice = sumselprice + selprice * units;
                        totgain=sumselprice  - sumbase ;

                        
                        rownuma++;
                    }
                    txtsumbase.Text = Convert.ToString(sumbase);
                    txtsumsel.Text = Convert.ToString(sumselprice);
                    txtsumgain.Text = Convert.ToString(totgain);


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

    }
}
