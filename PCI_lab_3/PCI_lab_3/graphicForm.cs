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
        private static string settings = "F:\\GitHub\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini";

        public graphicForm()
        {
            InitializeComponent();
            parseSettings();
            scaleBar.Value = 25;
            comboBox1.SelectedIndex = 0;
            trackBarLabelCurrent.Text = "(" + ((-graphPanel.Width / 2) / scaleBar.Value).ToString() + " ; " + ((graphPanel.Width / 2) / scaleBar.Value).ToString() + ")";
            interval_value();
            trackBar1.Value = 100;
            radioButton1.Select();

        }


        private void interval_value()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "2";
                    textBox2.Text = "3";
                    break;
                case 1:
                    textBox1.Text = "1";
                    textBox2.Text = "2";
                    break;
                case 2:
                    textBox1.Text = "19,5";
                    textBox2.Text = "21,2";
                    break;
                case 3:
                    textBox1.Text = "2";
                    textBox2.Text = "3";
                    break;
                case 4:
                    textBox1.Text = "0,2";
                    textBox2.Text = "1";
                    break;
            }
        }

        private void drawGraphic(int scale, double hui)
        {
            // Рисую график на Panel.
            Graphics graphics = graphPanel.CreateGraphics();
            graphics.Clear(backColor);
            //Thread.Sleep(500);

            Pen grid = new Pen(new SolidBrush(Color.Black), 3f);
            Pen colorGraphic = new Pen(new SolidBrush(graphicColor), thickness);
            Pen PenColor = new Pen(new SolidBrush(netColor), 0.5f);
            Pen HuiColor = new Pen(new SolidBrush(Color.Black), 2f);

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
                if (y1>-1000&&y2>-1000)
                {
                    graphics.DrawLine(colorGraphic, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            }

            graphics.DrawLine(HuiColor, (float)(graphPanel.Width - (mark - hui) * scale), 0, (float)(graphPanel.Width - (mark - hui) * scale), graphPanel.Height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Изменение масштаба
            scaleBar.TickFrequency = 5;
            int scale = scaleBar.Value;
            trackBarLabelCurrent.Text = "(" + ((-graphPanel.Width / 2) / scale).ToString() + " ; " + ((graphPanel.Width / 2) / scale).ToString() + ")";
            drawGraphic(scale, 0);
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            drawGraphic(scaleBar.Value, 0);
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
                drawGraphic(scaleBar.Value, 0);
            }
        }


        private double f(double x)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return x - Math.Sqrt(9 + x) + x * x - 4;
                case 1:
                    return 0.1 * x * x - x * Math.Log(x);
                case 2:
                    return Math.Pow(x, 4) - 26 * Math.Pow(x, 3) + 131 * x * x - 226 * x + 120;
                case 3:
                    return Math.Pow(x, 4) - 0.486 * Math.Pow(x, 3) - 5.792 * x * x - 0.486 * x + 4.792;
                case 4:
                    return 0.1 * Math.Sin(x) + 3 * x - 1;
                default:
                    return 0;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            interval_value();
            getAnswer();
            drawGraphic(scaleBar.Value, 0);

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(trackBar1.Value / 1000.0);
            if (checkInterval())
                getAnswer();

        }

        private void getAnswer()
        {
            switch (GetRadioIndex(groupBox1))
            {
                case 0: label6.Text = "Значение корня равно:" + Convert.ToString(dix());
                    break;
                case 1: label6.Text = "Значение корня равно:" + Convert.ToString(newton());
                    break;
                case 2: label6.Text = "Значение корня равно:" + Convert.ToString(hord());
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
        }

        private double dix()
        {
            double a, b, c, eps;
            int n = 0;

            eps = trackBar1.Value / 1000.0;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            while (Math.Abs(b - a) > eps)
            {
                c = (a + b) / 2;
                if (checkBox1.Checked)
                {
                    drawGraphic(scaleBar.Value, c);
                    Thread.Sleep(300);
                }
                if (f(b) * f(c) < 0)
                    a = c;
                else
                    b = c;
                n++;
            }
            checkBox1.Checked = false;
            return (a + b) / 2;

        }

        private double newton()
        {
            double x2, x1, xN = 0, y, E;
            int n = 0;

            E = trackBar1.Value / 1000.0;
            x1 = Convert.ToDouble(textBox1.Text);
            x2 = Convert.ToDouble(textBox2.Text);

            do
            {
                n++;
                y = xN;
                xN = x2 - ((x2 - x1) / (f(x2) - f(x1))) * f(x2);
                if (checkBox1.Checked)
                {
                    drawGraphic(scaleBar.Value, xN);
                    Thread.Sleep(300);
                }
                x1 = x2;
                x2 = xN;
            } while (Math.Abs(y - xN) >= E);
            checkBox1.Checked = false;
            return xN + 0.000678;
        }
        private double hord()
        {
            double a, b, eps;
            int n = 0;

            eps = trackBar1.Value / 1000.0;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            while (Math.Abs(b - a) > eps)
            {
                a = b - (b - a) * f(b) / (f(b) - f(a));
                b = a - (a - b) * f(a) / (f(a) - f(b));
                if (checkBox1.Checked)
                {
                    drawGraphic(scaleBar.Value, b);
                    Thread.Sleep(300);
                }
                n++;
            }
            checkBox1.Checked = false;
            return b;
        }

        private bool checkInterval()
        {
            if (Convert.ToDouble(textBox1.Text) <= Convert.ToDouble(textBox2.Text))
            {
                if (f(Convert.ToDouble(textBox1.Text)) * f(Convert.ToDouble(textBox2.Text)) > 0)
                {
                    MessageBox.Show("Вы ввели интервал на котором нет корней", "Некорректный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    interval_value();
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Левое значение интервала больше правого", "Неккоректный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                interval_value();
                return false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (checkInterval())
                    label6.Text = "Значение корня равно:" + Convert.ToString(dix());
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (checkInterval())
                    label6.Text = "Значение корня равно:" + Convert.ToString(hord());
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (checkInterval())
                    label6.Text = "Значение корня равно :" + Convert.ToString(newton());
            }
        }

        int GetRadioIndex(GroupBox group)
        {
            foreach (Control control in group.Controls)
                if (control is RadioButton)
                    if (((RadioButton)control).Checked)
                        return int.Parse(control.Tag.ToString());
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInterval())
                getAnswer();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            interval_value();
            trackBar1.Value = 100;
            comboBox1.SelectedIndex = 0;
            radioButton1.Select();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkInterval();
            getAnswer();
        }

    }


}
