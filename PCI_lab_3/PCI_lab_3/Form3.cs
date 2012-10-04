using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCI_lab_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                if(!((e.KeyChar.ToString() == "x") && (textBox1.Text.IndexOf("x") == -1)))
                    if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                        if (!((e.KeyChar.ToString() == "/") && (textBox1.Text.IndexOf("/") == -1)))
                            if (!((e.KeyChar.ToString() == "*") && (textBox1.Text.IndexOf("*") == -1)))
                                if (!((e.KeyChar.ToString() == "+") && (textBox1.Text.IndexOf("+") == -1)))
                                    if (!((e.KeyChar.ToString() == "-") && (textBox1.Text.IndexOf("-") == -1)))
                                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
