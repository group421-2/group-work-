using System;
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

        /**
         * Начало меню
         */
        private void createTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDITextForm newMDIChild = new MDITextForm();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
            toolStrip1.Visible = true;
        }

        /**
         * Выбор стиля текста - жирный
         */
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

        /**
         * Выбор стиля текста - курсив
         */
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


        /**
         * Выбор стиля текста - подчеркнутый
         */
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

        /**
         * Размер текста
         */
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontSize = (float)Convert.ToDouble(toolStripComboBox1.Text);
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            theBox.SelectionFont = new Font("Tahoma", fontSize, FontStyle.Regular);
            theBox.Focus();
            //theBox.SelectionAlignment=HorizontalAlignment.
        }

        /**
         * Выравнивание по левому краю
         */
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


        /**
         * Выравнивание по центру
         */
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

        /**
         * Выравнивание по правому краю
         */
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

        /**
         * Цвет текста
         */
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                theBox.ForeColor = colorDialog1.Color;
            }
        }

        /**
         * Сохранить файл
         */
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

        /**
         * Открыть файл
         */
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                theBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                activeChild.Text = openFileDialog1.FileName;
            }
            else
            {
                activeChild.Close();
            }
        }

        private void openTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.createTextToolStripMenuItem_Click(this, e);
            this.toolStripButton10_Click(this, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form3 newMDIChild = new Form3();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
            toolStrip2.Visible = true;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {

            Form active = this.ActiveMdiChild;
            Panel pb = (Panel)active.Controls["panel1"];
            pb.BackColor = Color.Red;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            Panel pb = (Panel)active.Controls["panel1"];
            pb.BackColor = Color.Blue;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            Panel pb = (Panel)active.Controls["panel1"];
            pb.BackColor = Color.Green;
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            Panel pb = (Panel)active.Controls["panel1"];
            pb.BackColor = Color.Yellow;
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            Form active = this.ActiveMdiChild;
            Panel pb = (Panel)active.Controls["panel1"];
            pb.BackColor = Color.Black;
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Form active = this.ActiveMdiChild;
                Panel pb = (Panel)active.Controls["panel1"];
                pb.BackColor = colorDialog1.Color;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(this, e);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            PictureBox theBox = (PictureBox)activeChild.Controls["pictureBox1"];
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                theBox.Image = new Bitmap(@openFileDialog2.FileName);
                activeChild.Text = openFileDialog2.FileName;
            }
            else
            {
                activeChild.Close();
            }
        }

        private void открытьКартинкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripMenuItem4_Click(this, e);
            this.toolStripButton12_Click(this, e);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                PictureBox theBox = (PictureBox)activeChild.Controls["pictureBox1"];
                Bitmap drawing = new Bitmap(theBox.Width, theBox.Height);
                theBox.DrawToBitmap(drawing, theBox.ClientRectangle);
                drawing.Save(openFileDialog2.FileName);
                //theBox.
            }
        }



    }
}
