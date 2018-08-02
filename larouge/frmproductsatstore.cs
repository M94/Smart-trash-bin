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
    public partial class frmproductsatstore : Form
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        static bool loadgridonce;
        static int selrowatdg1;
        static int selrowatdg2;
        static bool addnewitem;

        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

        DateTimePicker dtp2 = new DateTimePicker();
        Rectangle _Rectangle2;

        public frmproductsatstore()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
  
        }

        private void frmproductsatstore_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            loadgridonce = false;
            fillcmbdata(cmbgroups,true, "Tgroups", "groupname", "IDgroup" ,"isactive = true");
            fillcmbdata(cmbtyps, true, "Tproducttypes", "producttype", "producttypeid", "isactive = true");

            fillcmbdata(cmbgroups2, false, "Tgroups", "groupname", "IDgroup", "isactive = true");
            fillcmbdata(cmbtyps2, false, "Tproducttypes", "producttype", "producttypeid", "isactive = true");     
            
            dataGridView3.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);

            dataGridView2.Controls.Add(dtp2);
            dtp2.Visible = false;
            dtp2.Format = DateTimePickerFormat.Custom;
            dtp2.TextChanged += new EventHandler(dtp_TextChange2);

        }
        private void fillcmbdata(ComboBox cmbname,bool addall,string tblname,string dsmember,string idcol,string wherecon)
        {
            OleDbConnection con = new OleDbConnection();
            try
            {
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;
                
                con.Open();
                
                //create command    
                OleDbCommand OCMD = null;
                string strall="SELECT " +  idcol + " ,  " + dsmember + " FROM " + tblname;

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
                    DataRow dr=DT.NewRow();
                    dr[0] = 0;
                    dr[1] = "غير محدد";
                    DT.Rows.InsertAt(dr,0); }
                //attach datatable to combobox
                cmbname.DisplayMember = dsmember;
                cmbname.ValueMember = idcol ;
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
            
             searchproducts();

        }
        private void searchproducts()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            BindGrid();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                selrowatdg1 = 0;
                //dataGridView2.Rows.Remove(dataGridView1.Rows[0]);
                if (dataGridView1.Rows[0].Cells[1].Value != null)
                {
                    int proid = Convert.ToInt16(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    filldatagriddata(proid);
                    lblproid.Text = proid.ToString();
                    selproduct(proid);
                }
            }
        }
        private void BindGrid()
        {
            string selstr = "SELECT * FROM Qtotalproducts where productid > 0 ";
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();
                int rownuma = 1;
                if (Convert.ToInt16 (cmbgroups.SelectedValue) != 0)
                { selstr = selstr + " and productgroupid=" + cmbgroups.SelectedValue; }
                if (Convert.ToInt16(cmbtyps.SelectedValue) != 0)
                { selstr = selstr + " and typeid=" + cmbtyps.SelectedValue; }
                if (txtproductname.TextLength > 0)
                { selstr = selstr + " and productname like '%"+ txtproductname.Text + "%' "; }
                switch (cmbisactive.Text.ToString())
                {
                    case "الكل":
                        break;
                    case "النشط فقط":
                        selstr = selstr + " and isactive=true";
                        break;
                    case "الغير نشط فقط":
                        selstr = selstr + " and isactive=false";
                        break;
                }


                using (cmd = new OleDbCommand(selstr, con))
                {
                    cmd.CommandType = CommandType.Text;


                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // dataGridView2.Rows.Add();


                        dataGridView1.Rows.Add(rownuma.ToString(),reader["productid"].ToString(), reader["productname"].ToString(), reader["total"].ToString(), reader["producttype"].ToString(), reader["groupname"].ToString(), reader["isactive"].ToString());
                        rownuma++;
                    }



                }


                //using ( cmd = new OleDbCommand(selstr, con))
                //{
                //    cmd.CommandType = CommandType.Text;
 
                //    using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                //    {
                        
                //        using (DataTable dt = new DataTable())
                //        {
                //            sda.Fill(dt);

                //            if (dataGridView1.Rows.Count == 0  && loadgridonce==false)
                //            {
                //                //Set AutoGenerateColumns False
                //                dataGridView1.AutoGenerateColumns = false;
                //                loadgridonce = true;
                //                //Set Columns Count
                //                dataGridView1.ColumnCount = 6;

                //                //Add Columns
                //                dataGridView1.Columns[0].Name = "productid";
                //                dataGridView1.Columns[0].HeaderText = "كود المنتج";
                //                dataGridView1.Columns[0].DataPropertyName = "productid";

                //                dataGridView1.Columns[1].HeaderText = "المنتج";
                //                dataGridView1.Columns[1].Name = "productname";
                //                dataGridView1.Columns[1].DataPropertyName = "productname";

                //                dataGridView1.Columns[2].Name = "total";
                //                dataGridView1.Columns[2].HeaderText = "الوحدات المتوفرة";
                //                dataGridView1.Columns[2].DataPropertyName = "total";

                //                dataGridView1.Columns[3].Name = "producttype";
                //                dataGridView1.Columns[3].HeaderText = "النوع ";
                //                dataGridView1.Columns[3].DataPropertyName = "producttype";


                //                dataGridView1.Columns[4].Name = "groupname";
                //                dataGridView1.Columns[4].HeaderText = "التصنيفات";
                //                dataGridView1.Columns[4].DataPropertyName = "groupname";


                //                dataGridView1.Columns[5].Name = "isactive";
                //                dataGridView1.Columns[5].HeaderText = "isactive";
                //                dataGridView1.Columns[5].DataPropertyName = "isactive";

                //            }
                //            dataGridView1.DataSource = dt;
                           
                //        }
                //    }
                //}
                con.Close();
            }
               catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

           // MessageBox.Show (dataGridView1.Rows[dataGridView1.
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView2.Rows.Clear();
                selrowatdg1 = e.RowIndex;
                lblproid.Text = "0";
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    int proid = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    filldatagriddata(proid);
                    lblproid.Text = proid.ToString();
                    selproduct(proid);
                }
            }
        }
        private void filldatagriddata(int productid)
        {
            //for (int i = 1; i <= dataGridView2.Rows.Count - 1;i++)
            //{ dataGridView2.Rows.Remove(i); }
            dataGridView2.Rows.Clear();
            string selstr = "SELECT * FROM Tproductstore where productid= " + productid;
            int rownumb = 1;
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


                        dataGridView2.Rows.Add(rownumb.ToString(), reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
                        rownumb++;
                    }



                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                switch (dataGridView3.Columns[e.ColumnIndex].Name)
                {
                    case "col5":

                        _Rectangle = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                        dtp.Visible = true;

                        break;
                    case "col6":

                        _Rectangle = dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                        dtp.Visible = true;

                        break;
                }
            }
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView3.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dataGridView3_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;

        }

        private void dataGridView3_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;

        }

        private void dtp_TextChange2(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = dtp2.Text.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selrowatdg2 = e.RowIndex;
            if (selrowatdg2>=0)
            {
                if (e.ColumnIndex >= 0)
                {
                    switch (dataGridView2.Columns[e.ColumnIndex].Name)
                    {
                        case "colmagdate":

                            _Rectangle2 = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                            dtp2.Size = new Size(_Rectangle2.Width, _Rectangle2.Height); //  
                            dtp2.Location = new Point(_Rectangle2.X, _Rectangle2.Y); //  
                            dtp2.Visible = true;

                            break;
                        case "colexpdate":

                            _Rectangle2 = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                            dtp2.Size = new Size(_Rectangle2.Width, _Rectangle2.Height); //  
                            dtp2.Location = new Point(_Rectangle2.X, _Rectangle2.Y); //  
                            dtp2.Visible = true;

                            break;

                    }
                }
            }
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            dataGridView2.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.Yellow;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
        }

        private void btnadd2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();
            dataGridView2.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.Yellow;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int rowd;
            int proid=0;
            decimal number = 0;
            try
            {
                for (int rowi = 0; rowi < dataGridView2.Rows.Count ; rowi++)
                {
                    if (dataGridView2.Rows[0].Cells[2].Value != null)
                    {
                        proid = Convert.ToInt16(dataGridView2.Rows[0].Cells[2].Value.ToString());
                    }
                    rowd = rowi + 1;
                    if (dataGridView2.Rows[rowi].Cells[1].Value != null)
                    {
                        if (dataGridView2.Rows[rowi].Cells[4].Value == null)
                        { 
                            MessageBox.Show("يجب ادخال سعر شراء المنتج في الصف رقم " + rowd);
                            break;
                        }
                        else
                        {

                            if (decimal.TryParse(dataGridView2.Rows[rowi].Cells[4].Value.ToString(), out number) == false)
                            {
                                MessageBox.Show("يجب ادخال سعر شراء المنتج بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }                      

                        if (dataGridView2.Rows[rowi].Cells[5].Value == null)
                        {
                            MessageBox.Show("يجب ادخال سعر  بيع المنتج في الصف رقم " + rowd);
                            break;
                        }
                        else
                        {

                            if (decimal.TryParse(dataGridView2.Rows[rowi].Cells[5].Value.ToString(), out number) == false)
                            {
                                MessageBox.Show("يجب ادخال سعر بيع المنتج بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }

                        if (Convert.ToDecimal(dataGridView2.Rows[rowi].Cells[5].Value.ToString()) < Convert.ToDecimal(dataGridView2.Rows[rowi].Cells[4].Value.ToString()))
                        {

                            MessageBox.Show("يجب ادخال سعر  بيع المنتج اكبر من سعر الشراء في الصف رقم " + rowd);
                            break;
                        }
                        int num2 = 0;
                        if (dataGridView2.Rows[rowi].Cells[2].Value != null)
                        {


                            if (int.TryParse(dataGridView2.Rows[rowi].Cells[3].Value.ToString(), out num2) == false)
                            {
                                MessageBox.Show("يجب ادخال عدد الوحدات بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        updateproductstore(rowi);
                    }
                    else
                    {
                        insertnewproduct();
                    }
                    
                }
                filldatagriddata(proid);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
        }
        private void updateproductstore(int rownum)
        {
            int rownumd = rownum + 1;
            try
            {
                int id = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[1].Value.ToString());
                int typid = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[2].Value.ToString());

                int avilableunits = 0;

                if (dataGridView2.Rows[rownum].Cells[3].Value.ToString().Length != 0)
                { avilableunits = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[3].Value.ToString()); }

                decimal baseprice = Convert.ToDecimal(dataGridView2.Rows[rownum].Cells[4].Value.ToString());
                decimal selprice = Convert.ToDecimal(dataGridView2.Rows[rownum].Cells[5].Value.ToString());

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                upstr = "UPDATE Tproductstore SET  avilable=" + avilableunits + " ,baseprice=" + baseprice + ", selprice = " + selprice;
                if (dataGridView2.Rows[rownum].Cells[6].Value.ToString().Length != 0)
                { upstr = upstr + " , magdate=#" + dataGridView2.Rows[rownum].Cells[6].Value.ToString() + "#"; }

                if (dataGridView2.Rows[rownum].Cells[7].Value.ToString().Length != 0)
                { upstr = upstr + " , expdate=#" + dataGridView2.Rows[rownum].Cells[7].Value.ToString() + "#"; }

                upstr = upstr + " WHERE id=" + id;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                //con.Close();
                if (sonuc > 0)
                {
                    updatetotalatstor(typid,con);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rownumd);
                }
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
             //   con.Open();
                cmd.CommandText = sel;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {//www.csharp-console-example.com
                   avilableunits=Convert.ToInt16( reader[0]) ;
                }
                cmd = new OleDbCommand();
                cmd.Connection = con;
                upstr = "UPDATE Tproducts SET  total=" + avilableunits + " WHERE productid=" + proid;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
               // con.Close();
                if (sonuc > 0  )
                {
                    if (dataGridView1.Rows.Count > 1 && addnewitem ==false )
                    {
                        dataGridView1.Rows[selrowatdg1].Cells[3].Value = avilableunits;
                    }
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + selrowatdg1);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void updatetotalatstor(int proid)
        {

            try
            {

                int avilableunits = 0;

                string sel = "select  sum (avilable) as sumall FROM Tproductstore WHERE productid=" + proid;
                string upstr;
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
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
                 con.Close();
                if (sonuc > 0)
                {
                    dataGridView1.Rows[selrowatdg1].Cells[3].Value = avilableunits;
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + selrowatdg1);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void insertnewproduct()
        {
            int rownum=dataGridView2.Rows.Count-1;
            string proid = dataGridView1.Rows[selrowatdg1].Cells[1].Value.ToString();
            try
            {
               // int id = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[0].Value.ToString());
                //int typid = Convert.ToInt16(dataGridView1.Rows[rownum].Cells[0].Value.ToString());

                int avilableunits = 0;
                
                if (dataGridView2.Rows[rownum].Cells[3].Value.ToString().Length != 0)
                { avilableunits = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[3].Value.ToString()); }

                decimal baseprice = Convert.ToDecimal(dataGridView2.Rows[rownum].Cells[4].Value.ToString());
                decimal selprice = Convert.ToDecimal(dataGridView2.Rows[rownum].Cells[5].Value.ToString());

                OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                string valuesstr = ") VALUES (" + proid + "," + avilableunits + "," + baseprice + "," + selprice;
                upstr = "INSERT INTO Tproductstore (productid,avilable,baseprice,selprice ";
                if (dataGridView2.Rows[rownum].Cells[6].Value != null)
                { upstr = upstr + ", magdate";
                  valuesstr=valuesstr + ",#" + dataGridView2.Rows[rownum].Cells[6].Value.ToString() + "#"; }

                if (dataGridView2.Rows[rownum].Cells[7].Value != null)
                { upstr = upstr + " , expdate";
                valuesstr = valuesstr + ", #" + dataGridView2.Rows[rownum].Cells[7].Value.ToString() + "#";
                }

                upstr = upstr + valuesstr+ ")";
                 cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                
                if (sonuc > 0)
                {
                    updatetotalatstor(Convert.ToInt16( proid),con);
                    
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rownum);
                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
        private void deletesupproduct(string id, string proid)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();

 
    
                cmd.CommandText = "DELETE FROM Tproductstore WHERE id=" + id + "";
                //www.csharp-console-example.com
               
                int sonuc = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndel2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string id;
            string proid;
            if (dataGridView2.Rows.Count > 0)
            {
                if (dataGridView2.Rows.Count == 1 &&  dataGridView2.Rows[0].Cells[1].Value != null)
                {
                    result = MessageBox.Show("لا يمكن حذف المنتجات الفرعية تماما ولكن يمكنك جعل عددها صفر  " + "\n" + " هل تريد جعل العدد =0 ؟", "حذف منتجات فرعية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            dataGridView2.Rows[0].Cells[3].Value = "0";
                            dataGridView2.Rows[0].Cells[4].Value = "0";
                            dataGridView2.Rows[0].Cells[5].Value = "0";
                            dataGridView2.Rows[0].Cells[6].Value = "";
                            dataGridView2.Rows[0].Cells[7].Value = "";
                            updateproductstore(0);
                        }

                    }
                else if (dataGridView2.Rows[selrowatdg2].Cells[1].Value != null)
                {
                    id = dataGridView2.Rows[selrowatdg2].Cells[1].Value.ToString();
                    proid = dataGridView2.Rows[selrowatdg2].Cells[2].Value.ToString();

                    deletesupproduct(id, proid);
                    updatetotalatstor(Convert.ToInt16(proid));
                    filldatagriddata(Convert.ToInt16( proid));
                }
            }
        }
        private void selproduct(int id)
        {
            string selstr = "SELECT * FROM Tproducts where productid= " + id;
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

                        txtproname.Text = reader["productname"].ToString();
                        //MessageBox.Show(reader["isactive"].ToString());
                        if (reader["isactive"].ToString() == "True")
                        {
                            checkBox1.Checked = true;
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }

                        setselcombo(cmbgroups2, reader["productgroupid"].ToString());
                        setselcombo(cmbtyps2, reader["typeid"].ToString());
                    }



                }
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setselcombo(ComboBox cmb, string fval)
        {
            int Selected=0;
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

        private void btnupdatepro_Click(object sender, EventArgs e)
        {
            int proid;
            
            if (lblproid.Text != "0")
            {
                proid = Convert.ToInt16(lblproid.Text);
                if (txtproname.TextLength > 0)
                {
                    updateproductdata(proid);
                }
                else
                {
                    MessageBox.Show("يجب ادخال اسم المنتج","اسم المنتج",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }


        }
        private void updateproductdata(int proid)
        {
            string productgroupid;
            string typeid;
            string productname;
            bool isactive=true;
            productgroupid= cmbgroups2.SelectedValue.ToString();
            typeid = cmbtyps2.SelectedValue.ToString();
            productname = txtproname.Text;
            if (checkBox1.CheckState==System.Windows.Forms.CheckState.Checked )
            {
                isactive = true;
            }
            else
            { isactive = false; }
            try
            {
               OleDbConnection con = new OleDbConnection();
                string upstr;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                upstr = "UPDATE Tproducts SET  isactive=" + isactive + " ,productname='" + productname + "', productgroupid = " + productgroupid +",typeid=" + typeid;
                  upstr = upstr + " WHERE productid=" + proid;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                con.Close();
                if (sonuc > 0)
                {
                    searchproducts();
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
        private void btnnotactive_Click(object sender, EventArgs e)
        {

        }
        private bool notcloseddemo()
        {


            string upstr;
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                string sel = "select  count (productid) as numpro  from Tproducts";
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = sel;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {//www.csharp-console-example.com
                    if (reader.IsDBNull(0))
                    {
                        return true;
                    }
                    else
                    {
                        if (Convert.ToInt16(reader["numpro"]) < 10)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        private void btnnewpro_Click(object sender, EventArgs e)
        {
            if (notcloseddemo() == true)
            {
                dataGridView3.Visible = true;
                lblhint.Visible = true;
                btnsavepro.Visible = true;
                btnundo.Visible = true;

                cmbgroups2.Text = "";
                cmbtyps2.Text = "";
                txtproname.Text = "";
                lblproid.Text = "0";
                selrowatdg1 = dataGridView1.Rows.Count - 1;
                addnewitem = true;
            }
            else
            {
                MessageBox.Show("عفوا لا يمكن اضافة منتجات اخرى .... النسخة محدودة");
            }
        }

        private void btnsavepro_Click(object sender, EventArgs e)
        {
            if (cheacknewproduct() == true)
            {
                savenewproduct();
            }

            addnewitem = false;
        }

        private bool cheacknewproduct()
        {
            if (txtproname.TextLength < 2)
            {
                MessageBox.Show("يجب ادخال اسم المنتج", "اسم المنتج", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbgroups2.Text == "")
            {
                MessageBox.Show("يجب اختيار تصنيف  المنتج", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbtyps2.Text == "")
            {
                MessageBox.Show("يجب اختيار نوع وحدات المنتج", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            decimal number = 0;

            if (dataGridView3.Rows[0].Cells[3].Value == null)
            {
                MessageBox.Show("يجب ادخال سعر شراء المنتج  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                if (decimal.TryParse(dataGridView3.Rows[0].Cells[3].Value.ToString(), out number) == false)
                {
                    MessageBox.Show("يجب ادخال سعر شراء المنتج بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            if (dataGridView3.Rows[0].Cells[4].Value == null)
            {
                MessageBox.Show("يجب ادخال سعر  بيع المنتج  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {

                if (decimal.TryParse(dataGridView3.Rows[0].Cells[4].Value.ToString(), out number) == false)
                {
                    MessageBox.Show("يجب ادخال سعر شراء بيع المنتج بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (Convert.ToDecimal(dataGridView3.Rows[0].Cells[4].Value.ToString()) < Convert.ToDecimal(dataGridView3.Rows[0].Cells[3].Value.ToString()))
            {
                MessageBox.Show("يجب ادخال سعر  بيع المنتج اكبر من سعر الشراء في الصف رقم ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int num2 = 0;
            if (dataGridView3.Rows[0].Cells[2].Value != null)
            {
                
            
                if (int.TryParse(dataGridView3.Rows[0].Cells[2].Value.ToString(), out num2) == false)
                {
                    MessageBox.Show("يجب ادخال عدد الوحدات بصورة صحيحة  ", "منتج جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }


        private void savenewproduct()
        {
            try
            {

                int newid = 0;

                
                string upstr;
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                string sel = "select  max (productid) as maxid  from Tproducts";
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = sel;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {//www.csharp-console-example.com
                    if (reader.IsDBNull(0))
                    {
                        newid = 0;
                    }
                    else
                    { newid = Convert.ToInt16(reader["maxid"]); }
                }
                newid++;

                string productgroupid;
                string typeid;
                string productname;
                bool isactive = true;

                productgroupid = cmbgroups2.SelectedValue.ToString();
                typeid = cmbtyps2.SelectedValue.ToString();
                productname = txtproname.Text;
                if (checkBox1.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    isactive = true;
                }
                else
                { isactive = false; }
    
                cmd = new OleDbCommand();
                cmd.Connection = con;

                string valuesstr = " VALUES (" + newid + ",'" + productname + "'," + productgroupid + "," + typeid + ",0," + isactive + ")";
                upstr = "INSERT INTO Tproducts (productid,productname,productgroupid,typeid,total,isactive)  ";
                upstr = upstr + valuesstr;
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                
                if (sonuc > 0)
                {
                    insertnewproductall(newid.ToString(),con);
                    if (cheacktoaddatgrid() == true)
                    {
                        sel = "select  *  from Qtotalproducts where productid =" + newid;
                        cmd = new OleDbCommand();
                        cmd.Connection = con;

                        using (cmd = new OleDbCommand(sel, con))
                        {
                            cmd.CommandType = CommandType.Text;

                            int newadd=0;
                            OleDbDataReader reader3 = cmd.ExecuteReader();
                            while (reader3.Read())
                            {
                                // dataGridView2.Rows.Add();

                               // dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                                newadd =dataGridView1.Rows.Count ;
                                dataGridView1.Rows.Add(newadd.ToString(), reader3["productid"].ToString(), reader3["productname"].ToString(), reader3["total"].ToString(), reader3["producttype"].ToString(), reader3["groupname"].ToString(), reader3["isactive"].ToString());

                            }



                        }
                    }
                    else
                    {
                        MessageBox.Show("تم اضافة المنتج بنجاح سيظهر معك عند اعادة البحث ");
                    }
                }
                
                con.Close();
                dataGridView3.Rows.Clear();
                dataGridView3.Visible = false;
                lblhint.Visible = false;
                cmbgroups2.Text = "";
                cmbtyps2.Text = "";
                txtproname.Text = "";
                lblproid.Text = "0";
                btnsavepro.Visible = false;
                btnundo.Visible = false;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
    
        }
        private bool cheacktoaddatgrid()
        {
            if (cmbtyps.SelectedValue.ToString() == "0" && cmbgroups.SelectedValue.ToString() == "0" && txtproductname.TextLength == 0 && (cmbisactive.SelectedText == "الكل" || cmbisactive.SelectedText.Length == 0))
            {
                return true;
            }
            if (cmbtyps2.SelectedValue == cmbtyps.SelectedValue && cmbgroups2.SelectedValue == cmbgroups.SelectedValue)
            {
                if (cmbisactive.SelectedText == "" || cmbisactive.SelectedText == "الكل")
                {
                    return true;
                }
                else if (cmbisactive.SelectedText == "النشط فقط" && checkBox1.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    return true;
                }
                else if (cmbisactive.SelectedText == "الغير نشط فقط" && checkBox1.CheckState == System.Windows.Forms.CheckState.Unchecked)
                {
                    return true;
                }
                
            }
            return false;
        }
        private void insertnewproductall(string proid, OleDbConnection con)
        {
            
            try
            {
                // int id = Convert.ToInt16(dataGridView2.Rows[rownum].Cells[0].Value.ToString());
                //int typid = Convert.ToInt16(dataGridView1.Rows[rownum].Cells[0].Value.ToString());

                int avilableunits = 0;
                int rownum = 0;
                if (dataGridView3.Rows[rownum].Cells[2].Value.ToString().Length != 0)
                { avilableunits = Convert.ToInt16(dataGridView3.Rows[rownum].Cells[2].Value.ToString()); }

                decimal baseprice = Convert.ToDecimal(dataGridView3.Rows[rownum].Cells[3].Value.ToString());
                decimal selprice = Convert.ToDecimal(dataGridView3.Rows[rownum].Cells[4].Value.ToString());

                //OleDbConnection con = new OleDbConnection();
                string upstr;
               // con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                //con.Open();
                string valuesstr = ") VALUES (" + proid + "," + avilableunits + "," + baseprice + "," + selprice;
                upstr = "INSERT INTO Tproductstore (productid,avilable,baseprice,selprice ";
                if (dataGridView3.Rows[rownum].Cells[5].Value != null)
                {
                    upstr = upstr + ", magdate";
                    valuesstr = valuesstr + ",#" + dataGridView3.Rows[rownum].Cells[5].Value.ToString() + "#";
                }

                if (dataGridView3.Rows[rownum].Cells[6].Value != null)
                {
                    upstr = upstr + " , expdate";
                    valuesstr = valuesstr + ", #" + dataGridView3.Rows[rownum].Cells[6].Value.ToString() + "#";
                }

                upstr = upstr + valuesstr + ")";
                cmd.CommandText = upstr;

                int sonuc = cmd.ExecuteNonQuery();
                
                if (sonuc > 0)
                {
                    updatetotalatstor(Convert.ToInt16(proid),con);
                }
                else
                {
                    MessageBox.Show("  حدث خطأ اثناء تحديث الصف " + rownum);
                }
                //con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btndelpro_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt16(lblproid.Text)>0)
            {
                if( MessageBox.Show("هل تريد حذف المنتج ؟   " + "\n" + txtproname.Text , "حذف منتجات ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        deleteproduct(lblproid.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("لا يمكن حذف هذا المنتج لاستخدامه سابقا"+"\n" + ex.ToString(), "خطأ حذف"); 
                    }
                }

            }

        }

        private void deleteproduct(string proid)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();

                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();



                cmd.CommandText = "DELETE FROM Tproducts WHERE productid=" + proid + "";
                //www.csharp-console-example.com

                int sonuc = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("لا يمكن حذف هذا المنتج لاستخدامه سابقا" + "\n" + ex.ToString(), "خطأ حذف"); 
            }
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp2.Visible = false;
        }

        private void dataGridView3_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
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

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            renumbergrid(dataGridView2, 0);
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
            lblhint.Visible = false;
            btnsavepro.Visible = false;
            btnundo.Visible = false;

            cmbgroups2.Text = "";
            cmbtyps2.Text = "";
            txtproname.Text = "";
            lblproid.Text = "0";
            addnewitem = false;
        }
    }
}
