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
    public partial class frmreturns : Form
    {

        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        private string appuserid;
        private int selcustomer;
        private string oldpartvalue;
        private int selgrid1;

        private int selgrid2num;
        private bool notdelrow;

        private int seledunits = 0;

        public frmreturns()
        {
            InitializeComponent();
        }
        public frmreturns(string userid)
        {
            InitializeComponent();
            appuserid = userid;
        }
        private void frmreturns_Load(object sender, EventArgs e)
        {
                       dataGridView1.Rows.Clear();
            //loadgridonce = false;
            fillcmbdata(cmbgroups, true, "Tgroups", "groupname", "IDgroup", "isactive = true");
            fillcmbdata(cmbtyps, true, "Tproducttypes", "producttype", "producttypeid", "isactive = true");
            fillcmbdata(cmbcustomer1, true, "Tcustomers", "customername", "customerid", "isactive = true");
            fillcmbdata(cmbuser1, true, "Tusers", "username", "ID", "");

            fillcmbdata(cmbcustomer, false, "Tcustomers", "customername", "customerid", "isactive = true");
            fillcmbdata(cmbuser, false, "Tusers", "username", "ID", "");
           
            
            setselcombo(cmbuser, appuserid);
            newbill();
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
        private void newbill()
        {
            dataGridView2.Rows.Clear();

            txtsumtotal.Text = "0";
            //txtpayed.Text = "0";
            //txtremender.Text = "0";
            btnaddtobill.Enabled = true;
            btnaddbill.Enabled = true;
            btndelrow.Enabled = true;
            dataGridView2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            BindGrid();

        }

        private void BindGrid()
        {
            string selstr = "SELECT * FROM Qproductsforreturn where productid > 0 ";
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

                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dataGridView1.Rows.Add(rownuma.ToString(), reader["id"].ToString(), reader["productid"].ToString(), reader["productname"].ToString(), reader["groupname"].ToString(), reader["producttype"].ToString(), reader["numofunits"].ToString(), reader["pricevalueofone"].ToString(), reader["magdate"].ToString(), reader["expdate"].ToString(), reader["customername"].ToString(), reader["username"].ToString(), reader["billid"].ToString(), reader["datebill"].ToString());
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtponamesel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtproid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seledunits = 0;
            if (e.RowIndex >= 0)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int proid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtproid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtponamesel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    seledunits = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                  
                    txtpriceafteroffer.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtunits.Text = seledunits.ToString();
                    txtsumafteroffer.Text = Convert.ToString(seledunits * Convert.ToDecimal(txtpriceafteroffer.Text));
 


                }
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

        private void txtpriceafteroffer_TextChanged(object sender, EventArgs e)
        {
            decimal number1 = 0;
            int number2 = 0;
            if (decimal.TryParse(txtpriceafteroffer.Text.Trim(), out number1) == true && int.TryParse(txtunits.Text.Trim(), out number2) == true)
            {
                txtsumafteroffer.Text = Convert.ToString(Convert.ToInt16(txtunits.Text) * Convert.ToDecimal(txtpriceafteroffer.Text));
            }
        }

        private void txtunits_Leave(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(txtunits.Text.Trim(), out number) == true)
            {
                if (Convert.ToInt16(txtunits.Text) < 1)
                {
                    MessageBox.Show("خطأ في عدد الوحدات يجب ادخال عدد الوحدات", "ادخل عدد الوحدات");
                }
                else if (Convert.ToInt16(txtunits.Text) > seledunits )
                {
                    MessageBox.Show("خطأ في عدد الوحدات يجب ان يكون اقل من الوحدات المباعة", "ادخل عدد الوحدات");
                }
                else
                {
                    if (txtpriceafteroffer.TextLength > 0)
                    {
                        txtsumafteroffer.Text = Convert.ToString(Convert.ToInt16(txtunits.Text) * Convert.ToDecimal(txtpriceafteroffer.Text));
                    }
                }

                //textBox value is a number
            }
            else
            {
                //not a number
                MessageBox.Show("برجاء ادخال عدد الوحدات بصورة صحيحة ارقام", "ادخل عدد الوحدات");
                txtunits.Text = "";
            }
        }

        private void btnaddtobill_Click(object sender, EventArgs e)
        {
            if (cheackprobilldata() == true)
            {
                fillnewbillrow();
            }
        }
        private void fillnewbillrow()
        {
            dataGridView2.Rows.Add(dataGridView2.Rows.Count + 1, txtid.Text, txtproid.Text, txtponamesel.Text, txtunits.Text, txtpriceafteroffer.Text, txtsumafteroffer.Text);
            txtsumtotal.Text = Convert.ToString(Convert.ToDecimal(txtsumtotal.Text) + Convert.ToDecimal(txtsumafteroffer.Text));
        }
        private bool cheackprobilldata()
        {
            if (txtid.TextLength < 1)
            {
                MessageBox.Show("يجب اختيار المنتج اولا", "خطأ ادراج في الفاتورة");
                return false;
            }
            decimal dnumber = 0;
            if (decimal.TryParse(txtpriceafteroffer.Text.Trim(), out dnumber) == false || txtpriceafteroffer.TextLength == 0)
            {
                MessageBox.Show("خطأ في سعر الوحدة بعد الخصم", "خطأ ادراج في الفاتورة");
                return false;
            }
            int number = 0;
            if (int.TryParse(txtunits.Text.Trim(), out number) == false || txtunits.TextLength == 0)
            {
                MessageBox.Show("خطأ في عدد الوحدات", "خطأ ادراج في الفاتورة");
                return false;
            }
            if (txtsumafteroffer.TextLength == 0)
            {
                MessageBox.Show("خطأ في اجمالي السعر", "خطأ ادراج في الفاتورة");
                return false;
            }
            else
            {
                if (Convert.ToDecimal(txtsumafteroffer.Text) == 0)
                {
                    MessageBox.Show("خطأ في اجمالي السعر", "خطأ ادراج في الفاتورة");
                    return false;
                }
            }
            return true;
        }

        private void btndelrow_Click(object sender, EventArgs e)
        {
            if (selgrid2num >= 0)
            {
                if (MessageBox.Show("هل تريد حذف المنتج " + dataGridView2.Rows[selgrid2num].Cells[3].Value.ToString(), " حذف منتج من فاتورة", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    txtsumtotal.Text = Convert.ToString(Convert.ToDecimal(txtsumtotal.Text) - Convert.ToDecimal(dataGridView2.Rows[selgrid2num].Cells[6].Value.ToString()));
                    dataGridView2.Rows.RemoveAt(selgrid2num);
                    renumbergrid(dataGridView2,0);
                }
            }
        }

        private void dataGridView2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (notdelrow == false)
            {
                renumbergrid(dataGridView2, 0);
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المنتج " + dataGridView2.Rows[selgrid2num].Cells[3].Value.ToString(), " حذف منتج من فاتورة", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                txtsumtotal.Text = Convert.ToString(Convert.ToDecimal(txtsumtotal.Text) - Convert.ToDecimal(e.Row.Cells[6].Value.ToString()));
                notdelrow = false;
            }
            else
            {
                notdelrow = true;
                e.Cancel = true;
            }
        }

        private void btnnewselbill_Click(object sender, EventArgs e)
        {
            newbill();

        }

        private void btnaddbill_Click(object sender, EventArgs e)
        {
            savenewbill();


        }
        private void savenewbill()
        {
            int customerid;
            //int operatiotype = 1;
            string operationdate;
            string sumtotal;
            
            
            string billid;

            try
            {
                if (cheackbilldata() == true)
                {
                    customerid = Convert.ToInt16(cmbcustomer.SelectedValue.ToString());
                    operationdate = dateTimePicker1.Value.ToShortDateString();
                    sumtotal = txtsumtotal.Text;
  
                    billid = "0";
                    if (txtbillbookid.TextLength > 0)
                    {
                        billid = txtbillbookid.Text;
                    }


                    //if (newoperationid > 0)
                    //{

                    OleDbConnection con = new OleDbConnection();

                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();

                    string upstr = "INSERT INTO Toperations (userid,customerid,operationtype,billid,datebill,totalbill)  ";
                    string valuesstr = " VALUES (" + appuserid + "," + customerid + "," + 3 + ",'" + billid + "', # " + operationdate + "# ," + sumtotal + ")";
                    upstr = upstr + valuesstr;
                    cmd.CommandText = upstr;
                    //cmd = new OleDbCommand();
                    int sonuc = cmd.ExecuteNonQuery();
                    con.Close();
                    if (sonuc > 0)
                    {
                        long newoperationid = getlastid("Toperations", "seloperationid");
                        savebillitems(newoperationid);

                        savecustomerparts(customerid, sumtotal);
                        
                    }
                    MessageBox.Show(" تم حفظ الفاتورة بنجاح" + "\n" + "اضغط فاتورة جديدة ", "حفظ فاتورة");
                    btnaddtobill.Enabled = false;
                    btnaddbill.Enabled = false;
                    btndelrow.Enabled = false;
                    dataGridView2.Enabled = false;

                    dataGridView1.Rows.Clear();
                    BindGrid();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأاضافة عمليه فاتورة بيع ");
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
                MessageBox.Show(ex.ToString(), "خطأ اضافة باقي حساب فاتورة");
            }

        }
        private void savebillitems(long operationid)
        {
            try
            {

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                con.Open();
                for (int rownum = 0; rownum < dataGridView2.Rows.Count; rownum++)
                {

                    int id = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[1].Value.ToString());
                    int typid = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[2].Value.ToString());

                    int avilableunits = 0;

                    if (dataGridView2.Rows[rownum].Cells[4].Value.ToString().Length != 0)
                    { avilableunits = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[4].Value.ToString()); }
                    decimal selprice = Convert.ToDecimal(dataGridView2.Rows[rownum].Cells[5].Value.ToString());

                    cmd = new OleDbCommand();
                    cmd.Connection = con;

                    upstr = "INSERT INTO Tbilldata (operationid,productid,numofunits,pricevalueofone)  ";
                    string valuesstr = " VALUES (" + operationid + "," + id + "," + avilableunits + "," + selprice + ")";
                    upstr = upstr + valuesstr;
                    cmd.CommandText = upstr;

                    int sonuc = cmd.ExecuteNonQuery();

                    if (sonuc > 0)
                    {

                        cmd = new OleDbCommand();
                        upstr = "UPDATE Tproductstore SET  avilable=(avilable + " + avilableunits + ") WHERE id=" + id;
                        cmd.CommandText = upstr;
                        cmd.Connection = con;
                        int sonuc2 = cmd.ExecuteNonQuery();

                        if (sonuc2 > 0)
                        {
                            updatetotalatstor(typid,con);
                        }
                        else
                        {
                            MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rownum);
                        }
                    }


                   
                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            
        }

        private void updatetotalatstor(int proid, OleDbConnection con)
        {

            try
            {

                int avilableunits = 0;

                string sel = "select  sum (avilable) as sumall FROM Tproductstore WHERE productid=" + proid;
                string upstr;
                //OleDbConnection con = new OleDbConnection();
                //con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
        //        con.Open();
                cmd.CommandText = sel;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {//www.csharp-console-example.com
                    avilableunits = Convert.ToInt16(reader[0]);
                }
                cmd = new OleDbCommand();
                cmd.Connection = con;
                upstr = "UPDATE Tproducts SET  total=" + avilableunits + " WHERE productid=" + proid;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
            //    con.Close();
                if (sonuc > 0)
                {
                    //dataGridView1.Rows[selrowatdg1].Cells[3].Value = avilableunits;
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث المنتج " + proid);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private long getlastid(string tblname, string colname)
        {
            long newid = 0;

            string sel = "select  max ( " + colname + " )as maxid  from " + tblname;
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = sel;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {//www.csharp-console-example.com
                    if (reader.IsDBNull(0))
                    {
                        newid = 1;
                    }
                    else
                    { newid = Convert.ToInt16(reader["maxid"]); }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "خطأ اكبر id");
            }
            return newid;
        }
        private bool cheackbilldata()
        {
            if (dataGridView2.Rows.Count < 1)
            {
                MessageBox.Show("يجب ادخال منتجات", "خطأ اضافة فاتورة مرتجعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToDecimal(txtsumtotal.Text) <= 0)
            {
                MessageBox.Show("يجب ادخال قيمة مدفوعة", "خطأ اضافة فاتورة مرتجعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbcustomer.Text == "")
            {
                MessageBox.Show("يجب اختيار عميل", "خطأ اضافة فاتورة مرتجعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selgrid2num = e.RowIndex;
        }
    }
}
