using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

using System.IO;

namespace larouge
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        private string Appuserid;
        private string Appusername;

        public MDIParent1()
        {
            InitializeComponent();
        }
        public MDIParent1(string userid,string username)
        {
            Appuserid = userid;
            Appusername = username;
            InitializeComponent();
            tsuserid.Text = Appuserid;
            tsusername.Text = "Welcome : " + Appusername ;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripBtnavilableatstore_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmproductsatstore")
                {
                    childForm.Close();
                }
            }
            frmproductsatstore newMDIChild = new frmproductsatstore();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();  
            //frmproductsatstore fm = new frmproductsatstore();
           // fm.Show(); 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtongroups_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmgroups")
                {
                    childForm.Close();
                }
            }
            frmgroups newMDIChild = new frmgroups();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtontypes_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmtypes")
                {
                    childForm.Close();
                }
            }
            frmtypes newMDIChild = new frmtypes();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
        
            Application.Exit();
        
        }

        private void ToolStripMenuItemgroupsh_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmgroupshelp")
                {
                    childForm.Close();
                }
            }
            frmgroupshelp newMDIChild = new frmgroupshelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            //frmproductsatstore fm = new frmproductsatstore();
            // fm.Show();
        }

        private void ToolStripMenuItemtypesh_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmtypeshelp")
                {
                    childForm.Close();
                }
            }
            frmtypeshelp newMDIChild = new frmtypeshelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItemstoreh_Click(object sender, EventArgs e)
        {
   
        }

        private void ToolStripMenuItempro1_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmproducthelp")
                {
                    childForm.Close();
                }
            }
            frmproducthelp newMDIChild = new frmproducthelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItempro2_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmproductshelp2")
                {
                    childForm.Close();
                }
            }
            frmproductshelp2 newMDIChild = new frmproductshelp2();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtonselbill_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmselbill")
                {
                    childForm.Close();
                }
            }
            frmselbill newMDIChild = new frmselbill(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();

        }

        private void toolStripButtonaddcustomers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmcustomersadd")
                {
                    childForm.Close();
                }
            }
            frmcustomersadd newMDIChild = new frmcustomersadd(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItembill_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmselbillhelp")
                {
                    childForm.Close();
                }
            }
            frmselbillhelp newMDIChild = new frmselbillhelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItemcustomers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmcustomeraddhelp")
                {
                    childForm.Close();
                }
            }
            frmcustomeraddhelp newMDIChild = new frmcustomeraddhelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtoncustomers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmdonners")
                {
                    childForm.Close();
                }
            }
            frmdonners newMDIChild = new frmdonners(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtonusers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmusers")
                {
                    childForm.Close();
                }
            }
            frmusers newMDIChild = new frmusers();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();

        }

        private void ToolStripMenuItemusers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmusershelp")
                {
                    childForm.Close();
                }
            }
            frmusershelp newMDIChild = new frmusershelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItemdonners_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmdonnershelp")
                {
                    childForm.Close();
                }
            }
            frmdonnershelp newMDIChild = new frmdonnershelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtondonnerbill_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmdonnersbill")
                {
                    childForm.Close();
                }
            }
            frmdonnersbill newMDIChild = new frmdonnersbill(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void toolStripButtonreturn_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmreturns")
                {
                    childForm.Close();
                }
            }
            frmreturns newMDIChild = new frmreturns(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItembackup_Click(object sender, EventArgs e)
        {
            Backup();
 
        }


        private void Backup()
        {

            string CurrentDatabasePath = Environment.CurrentDirectory + @"\Dblaroug.accdb";
            string test = DateTime.Now.Year.ToString() + "Year" + "-" + DateTime.Now.Month.ToString() + "Month" + "-" + DateTime.Now.Day.ToString() + "Day";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string PathtobackUp = fbd.SelectedPath.ToString();
                File.Copy(CurrentDatabasePath, PathtobackUp + @"\" + test + "Dblarougbackup1.accdb", true);
                MessageBox.Show("successfully Backup! ");
            }
            
        }

        private void Restore()
        {
            string PathToRestoreDB = Environment.CurrentDirectory + @"\Dblaroug.accdb";

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string Filetorestore = ofd.FileName;



                // Rename Current Database to .Bak

                if (MessageBox.Show("هل تريد الاحتفاظ بنسخة من قاعدة البيانات الحالية قبل استعادة نسخة مخبأة ؟", "استعادة نسخة مخبأة", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    File.Move(PathToRestoreDB, PathToRestoreDB + ".bak");
                }


                //Restore the Databse From Backup Folder

                File.Copy(Filetorestore, PathToRestoreDB, true);



            }

        }

        private void ToolStripMenuItemrestorbackup_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void toolStripButtontypesmony_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmoperationtypes")
                {
                    childForm.Close();
                }
            }
            frmoperationtypes newMDIChild = new frmoperationtypes();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItemotherbill_Click(object sender, EventArgs e)
        {
           foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmotherbilltypes")
                {
                    childForm.Close();
                }
            }
           frmotherbilltypes newMDIChild = new frmotherbilltypes(tsuserid.Text.ToString());
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            
        }

        private void ToolStripMenuItemstartup_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmstartuphelp")
                {
                    childForm.Close();
                }
            }
            frmstartuphelp newMDIChild = new frmstartuphelp();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            //frmproductsatstore fm = new frmproductsatstore();
            // fm.Show();
        }

        private void toolStripButtonoffers_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmoffers")
                {
                    childForm.Close();
                }
            }
 
            frmoffers newMDIChild = new frmoffers();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = global::larouge.Properties.Resources.back2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void ToolStripMenuItemcalc_Click(object sender, EventArgs e)
        {

            try
            {
                Process p = null;
                if (p == null)
                {
                    p = new Process();
                    p.StartInfo.FileName = "Calc.exe";
                    p.Start();
                }
                else
                {
                    p.Close();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepton" + ex.ToString());
            }


        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = null;
                if (p == null)
                {
                    p = new Process();
                  //  Process.Start(@"notepad.exe", pathToFile);
                    p.StartInfo.FileName = "notepad.exe";
                    p.Start();
                }
                else
                {
                    p.Close();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepton" + ex.ToString());
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WINWORD.EXE";
            //startInfo.Arguments = filePath;
            Process.Start(startInfo);
        }

        private void ToolStripMenuItemmoneyselproduct_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmmoneyselproducts")
                {
                    childForm.Close();
                }
            }

            frmmoneyselproducts newMDIChild = new frmmoneyselproducts();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItememppos_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmempspos")
                {
                    childForm.Close();
                }
            }

            frmempspos newMDIChild = new frmempspos();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void ToolStripMenuItem1emps_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == "frmemps")
                {
                    childForm.Close();
                }
            }

            frmemps newMDIChild = new frmemps();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
                        {
                            if (childForm.Name == "AboutBox1")
                {
                    childForm.Close();
                }
            }

                        AboutBox1 newMDIChild = new AboutBox1();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            
        }

    
        
    }
}
