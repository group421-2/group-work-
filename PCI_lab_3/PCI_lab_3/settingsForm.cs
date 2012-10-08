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
        public static Single thickness; //толщина графика
        public static bool net; //сетка
        private static string settings = "C:\\Sites\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini";


        public settingsForm()
        {
            InitializeComponent();
            parseSettings();
            comboBox1.SelectedIndex = (int)thickness - 1;
            textBox1.BackColor = graphicColor;
            if (net)
            {
                checkBox1.Checked = true;
            }
        }

        private void parseSettings()
        {
            string s = "";
            if (!File.Exists(settings))
            {
                MessageBox.Show("Идите нахуй");
            }
            StreamReader sr = File.OpenText(settings);
            s = sr.ReadLine();
            int RGB = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
            graphicColor = Color.FromArgb(RGB);
            s = sr.ReadLine();
            thickness = Single.Parse(s);
            s = sr.ReadLine();
            net = bool.Parse(s);
            sr.Close();
        }

        public static string ColorToHexString(Color color)
        {
            return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}",
                      color.A,
                      color.R,
                      color.G,
                      color.B);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamWriter sw = new StreamWriter(File.OpenWrite(settings));

            sw.WriteLine(ColorToHexString(colorDialog1.Color));
            sw.WriteLine(comboBox1.Text);
            sw.WriteLine((checkBox1.Checked) ? "true" : "false");
            sw.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
