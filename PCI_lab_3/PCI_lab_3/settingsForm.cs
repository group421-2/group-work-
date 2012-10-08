using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PCI_lab_3
{
    public partial class settingsForm : Form
    {
        public static Color graphicColor; //цвет графика
        public static Color backColor; //цвет фона
        public static Color netColor; //цвет сетки
        public static Single thickness; //толщина графика
        public static bool net; //сетка
        private static string settings = "C:\\Sites\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini";


        public settingsForm()
        {
            InitializeComponent();

            parseSettings();

            comboBox1.SelectedIndex = (int)thickness - 1;
            textBox1.BackColor = graphicColor;
            textBox2.BackColor = backColor;
            textBox3.BackColor = netColor;
            if (net)
            {
                checkBox1.Checked = true;
            }

            colorDialog1.Color = graphicColor;
            colorDialog2.Color = backColor;
            colorDialog3.Color = netColor;
        }

        private void parseSettings()
        {
            string s = "";
            if (!File.Exists(settings))
            {
                MessageBox.Show("Идите нахуй");
            }
            else
            {
                StreamReader sr = File.OpenText(settings);
                
                s = sr.ReadLine();
                int RGB = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                graphicColor = Color.FromArgb(RGB);

                s = sr.ReadLine();
                RGB = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                backColor = Color.FromArgb(RGB);

                s = sr.ReadLine();
                RGB = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                netColor = Color.FromArgb(RGB);

                s = sr.ReadLine();
                thickness = Single.Parse(s);
                
                s = sr.ReadLine();
                net = bool.Parse(s);
                sr.Close();
            }
        }

        public static string ColorToHexString(Color color)
        {
            return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}",
                      color.A,
                      color.R,
                      color.G,
                      color.B);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamWriter sw = new StreamWriter(File.OpenWrite(settings));

            sw.WriteLine(ColorToHexString(colorDialog1.Color));
            sw.WriteLine(ColorToHexString(colorDialog2.Color));
            sw.WriteLine(ColorToHexString(colorDialog3.Color));
            sw.WriteLine(comboBox1.Text);
            sw.WriteLine((checkBox1.Checked) ? "true" : "false");
            sw.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics line = lineExample.CreateGraphics();
            line.Clear(lineExample.BackColor);
            Pen lineColor = new Pen(new SolidBrush(graphicColor), comboBox1.SelectedIndex);
            line.DrawLine(lineColor, 0, lineExample.Height / 2, lineExample.Width, lineExample.Height / 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox2.BackColor = colorDialog2.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                textBox3.BackColor = colorDialog3.Color;
            }
        }

        private void lineExample_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = lineExample.CreateGraphics();
            Pen lineColor = new Pen(new SolidBrush(graphicColor), thickness);
            line.DrawLine(lineColor, 0, lineExample.Height / 2, lineExample.Width, lineExample.Height / 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            confirmForm cf = new confirmForm();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.Pink;
                colorDialog1.Color = Color.Red;
                colorDialog2.Color = Color.White;
                colorDialog3.Color = Color.Pink;
                checkBox1.Checked = true;
            }

        }

    }
}
