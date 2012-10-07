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

        public settingsForm()
        {
            InitializeComponent();
            parseSettings("C:\\Sites\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini");
            comboBox1.SelectedIndex = (int)thickness - 1;
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void parseSettings(string settings)
        {
            byte i = 1;
            string s = "";
            if (!File.Exists(settings))
            {
                MessageBox.Show("Идите нахуй");
            }
            StreamReader sr = File.OpenText(settings);
            while ((s = sr.ReadLine()) != null)
            {
                switch (i)
                {
                    case 1:
                        int RGB = int.Parse(s, System.Globalization.NumberStyles.AllowHexSpecifier);
                        graphicColor = Color.FromArgb(RGB); i++;
                        break;
                    case 2: thickness = Single.Parse(s); i++;
                        break;
                    case 3: net = bool.Parse(s); i = 1;
                        break;
                }
            }
            sr.Close();
        }

        private void graphiColor_Paint(object sender, PaintEventArgs e)
        {
            graphiColor.BackColor = graphicColor;
        }
    }
}
