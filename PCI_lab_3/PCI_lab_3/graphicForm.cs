using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PCI_lab_3
{
    public partial class graphicForm : Form
    {
        public static Color graphicColor; //цвет графика
        public static Color backColor; //цвет фона
        public static Color netColor; //цвет сетки
        public static Single thickness; //толщина графика
        public static bool net; //сетка
        private static string settings = "Z:\\home\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini";

        public graphicForm()
        {
            InitializeComponent();
            parseSettings();
            scaleBar.Value = 25;
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "0";
            textBox2.Text = "1";
            trackBarLabelCurrent.Text = "(" + ((-graphPanel.Width / 2) / scaleBar.Value).ToString() + " ; " + ((graphPanel.Width / 2) / scaleBar.Value).ToString() + ")";
            
            
            

        }



        private void drawGraphic(int scale)
        {
            // Рисую график на Panel.
            Graphics graphics = graphPanel.CreateGraphics();
            graphics.Clear(backColor);
            //Thread.Sleep(500);

            Pen grid = new Pen(new SolidBrush(Color.Black), 3f);
            Pen colorGraphic = new Pen(new SolidBrush(graphicColor), thickness);
            Pen PenColor = new Pen(new SolidBrush(netColor), 0.5f);
            

            //Рисую сетку
            if (net)
            {
                float i1 = graphPanel.Width;
                while (i1 > 0)
                {
                    graphics.DrawLine(PenColor, 0, i1, graphPanel.Height, i1);
                    graphics.DrawLine(PenColor, i1, 0, i1, graphPanel.Width);
                    i1 -= scale;
                }
            }

            // Рисую ось:
            graphics.DrawLine(grid, 0, graphPanel.Width / 2, graphPanel.Width, graphPanel.Width / 2);
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Width / 2, graphPanel.Height);

            //Рисование стрелки на оси Х
            graphics.DrawLine(grid, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 10, graphPanel.Height / 2 - 5);
            graphics.DrawLine(grid, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 10, graphPanel.Height / 2 + 5);

            //Рисование стрелки на оси У
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Height / 2 - 5, 10);
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Height / 2 + 5, 10);

            int pointX = graphPanel.Width / 2, pointY = graphPanel.Height / 2;

            //Размечаем ось Х,Y
            if (scaleBar.Value > 15)
            {
                while (pointX > 0)
                {
                    graphics.DrawLine(grid, pointX, graphPanel.Width / 2 - 5, pointX, graphPanel.Width / 2 + 5);
                    graphics.DrawLine(grid, graphPanel.Height / 2 - 5, pointX, graphPanel.Width / 2 + 5, pointX);
                    graphics.DrawLine(grid, pointY, graphPanel.Width / 2 - 5, pointY, graphPanel.Width / 2 + 5);
                    graphics.DrawLine(grid, graphPanel.Height / 2 - 5, pointY, graphPanel.Width / 2 + 5, pointY);
                    pointY += Convert.ToInt32(scale);
                    pointX -= Convert.ToInt32(scale);
                }
            }

            //Рисую график
            double i = graphPanel.Width / 2 / scale;
            double x1, y1,
                 x2, y2;
            double mark = (graphPanel.Width / 2) / scale;
            while (i > -graphPanel.Width / 2 / scale)
            {
                x1 = i;
                y1 = f(x1);
                x1 = graphPanel.Width - (mark - x1) * scale;
                y1 = (graphPanel.Height / 2) - y1 * scale;
                i -= 0.1;
                x2 = i;
                y2 = f(x2);
                x2 = graphPanel.Width - (mark - x2) * scale;
                y2 = (graphPanel.Height / 2) - y2 * scale;
                if (y1 > -500 && y2 > -500)
                {
                    graphics.DrawLine(colorGraphic, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            }

            
        }
        private double f(double x)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return 1 - x;
                case 1:
                    return Math.Pow(x,4) - 9 * Math.Pow(x,3) + 33 * Math.Pow(x,2) + 18 * x - 21;
                case 2:
                    return 4 * (Math.Pow(4,x)*Math.Sin(Math.Pow(4,-x)));
                case 3:
                    return Math.Log(x/3) + x;
                default:
                    return 0;
            }
        }

        private void picture_change()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox2.Image = PCI_lab_3.Properties.Resources._1;
                    break;
                case 1:
                    pictureBox2.Image = PCI_lab_3.Properties.Resources._2;
                    break;
                case 2:
                    pictureBox2.Image = PCI_lab_3.Properties.Resources._3;
                    break;
                case 3:
                    pictureBox2.Image = PCI_lab_3.Properties.Resources._4;
                    break;
                default:
                    break;
            }

            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Изменение масштаба
            scaleBar.TickFrequency = 5;
            int scale = scaleBar.Value;
            trackBarLabelCurrent.Text = "(" + ((-graphPanel.Width / 2) / scale).ToString() + " ; " + ((graphPanel.Width / 2) / scale).ToString() + ")";
            drawGraphic(scale);
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            drawGraphic(scaleBar.Value);
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sf = new settingsForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                parseSettings();
                drawGraphic(scaleBar.Value);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawGraphic(scaleBar.Value);
            textBox1.Focus();
            picture_change();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox2.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    if (!((e.KeyChar.ToString() == "-") && (textBox1.Text.IndexOf("-") == -1)))
                    e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") && (textBox2.Text.IndexOf(",") == -1)))
                    if (!((e.KeyChar.ToString() == "-") && (textBox2.Text.IndexOf("-") == -1)))
                        e.Handled = true;
            }


        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(trackBar1.Value / 1000.0);
        }


    }


}
