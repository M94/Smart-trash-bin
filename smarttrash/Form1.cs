using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smarttrash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button1.BackColor=Color.Red ;
            }
            else
            {
                button1.BackColor = Color.GreenYellow;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button3.BackColor = Color.Red;
            }
            else
            {
                button3.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button4.BackColor = Color.Red;
            }
            else
            {
                button4.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.GreenYellow;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button9.BackColor = Color.Red;
            }
            else
            {
                button9.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button7.BackColor = Color.Red;
            }
            else
            {
                button7.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button8.BackColor = Color.Red;
            }
            else
            {
                button8.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button6.BackColor = Color.Red;
            }
            else
            {
                button6.BackColor = Color.GreenYellow;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                button10.BackColor = Color.Red;
            }
            else
            {
                button10.BackColor = Color.GreenYellow;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
