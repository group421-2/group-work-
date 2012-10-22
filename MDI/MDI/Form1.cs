﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDI
{
    public partial class MDIParentForm : Form
    {
        public MDIParentForm()
        {
            InitializeComponent();
            fontSize = (float)Convert.ToDouble(toolStripComboBox1.Text);
        }

        private static float fontSize;

        private void createTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDITextForm newMDIChild = new MDITextForm();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
            toolStrip1.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton1.Checked)
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Bold);
                toolStripButton1.Checked = true;
            }
            else
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Regular);
                toolStripButton1.Checked = false;
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton2.Checked)
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Italic);
                toolStripButton2.Checked = true;
            }
            else
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Regular);
                toolStripButton2.Checked = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton3.Checked)
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Underline);
                toolStripButton3.Checked = true;
            }
            else
            {
                theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Regular);
                toolStripButton3.Checked = false;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontSize = (float)Convert.ToDouble(toolStripComboBox1.Text);
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Regular);
            theBox.Focus();
            //theBox.SelectionAlignment=HorizontalAlignment.
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton4.Checked)
            {
                theBox.SelectionAlignment = HorizontalAlignment.Left;
                toolStripButton4.Checked = true;
                toolStripButton5.Checked = false;
                toolStripButton6.Checked = false;
            }
            else
            {
                theBox.SelectionAlignment = HorizontalAlignment.Left;
                toolStripButton4.Checked = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton5.Checked)
            {
                theBox.SelectionAlignment = HorizontalAlignment.Center;
                toolStripButton5.Checked = true;
                toolStripButton4.Checked = false;
                toolStripButton6.Checked = false;
            }
            else
            {
                theBox.SelectionAlignment = HorizontalAlignment.Left;
                toolStripButton5.Checked = false;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
            {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (!toolStripButton6.Checked)
            {
                theBox.SelectionAlignment = HorizontalAlignment.Right;
                toolStripButton6.Checked = true;
                toolStripButton4.Checked = false;
                toolStripButton5.Checked = false;
            }
            else
            {
                theBox.SelectionAlignment = HorizontalAlignment.Left;
                toolStripButton6.Checked = false;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                theBox.ForeColor = colorDialog1.Color;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                Form activeChild = this.ActiveMdiChild;
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                theBox.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                activeChild.Text = saveFileDialog1.FileName;
            }
           
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                theBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                activeChild.Text = openFileDialog1.FileName;
            }
        }

        private void открытьБраззерсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.createTextToolStripMenuItem_Click(this, e);
            this.toolStripButton10_Click(this, e);
        }


    }
}
