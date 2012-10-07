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
    public partial class graphicForm : Form
    {
        public static Color graphicColor; //цвет графика
        public static Single thickness; //толщина графика
        public static bool net; //сетка

        public graphicForm()
        {
            InitializeComponent();
            parseSettings("C:\\Sites\\group-work-\\PCI_lab_3\\PCI_lab_3\\settings.ini");
        }

        private void drawGraphic(float scale)
        {
            Graphics graphics = graphPanel.CreateGraphics(); // Рисую график на Panel.
            graphics.Clear(graphPanel.BackColor);

            Pen grid = new Pen(new SolidBrush(Color.Black), 1f); // Рисую ось черными линиями.
            Pen colorGraphic = new Pen(new SolidBrush (graphicColor), thickness);
            Pen netColor = new Pen(new SolidBrush(Color.Pink), 0.5f);
            
            if (net)
            {
                float i1 = graphPanel.Width;
                while (i1 > 0)
                {
                    graphics.DrawLine(netColor, 0, i1, graphPanel.Height, i1);
                    graphics.DrawLine(netColor, i1, 0, i1, graphPanel.Width);
                    i1 -= scale;
                }
            }


            // Рисую ось:
            graphics.DrawLine(grid, 0, graphPanel.Width / 2, graphPanel.Width, graphPanel.Width / 2);
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Width / 2, graphPanel.Height);

            /**
             * Рисование стрелки на оси Х
             */
            graphics.DrawLine(grid, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 10, graphPanel.Height / 2 - 5);
            graphics.DrawLine(grid, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 10, graphPanel.Height / 2 + 5);


            /**
             * Рисование стрелки на оси У
             */
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Height / 2 - 5, 10);
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Height / 2 + 5, 10);
            double i = graphPanel.Width / 2 / scale;
            double x1, y1,
                 x2, y2;
            
            double mark = (graphPanel.Width / 2) / scale;
            int pointX = graphPanel.Width/2, pointY = graphPanel.Height/2;

            /**
             * Размечаем ось Х
            */
            if (scaleBar.Value > 15)
            {
                while (pointX > 0)
                {
                    graphics.DrawLine(grid, pointX, graphPanel.Width / 2 - 5, pointX, graphPanel.Width / 2 + 5);
                    graphics.DrawLine(grid, graphPanel.Height / 2 - 5, pointX, graphPanel.Width / 2 + 5, pointX);
                    pointX -= Convert.ToInt32(scale);
                }
                /**
                 * Размечаем ось Y
                 */
                while (pointY <400)
                {
                    graphics.DrawLine(grid, pointY, graphPanel.Width / 2 - 5, pointY, graphPanel.Width / 2 + 5);
                    graphics.DrawLine(grid, graphPanel.Height / 2 - 5, pointY, graphPanel.Width / 2 + 5, pointY);
                    pointY += Convert.ToInt32(scale);
                }
            }
            while (i > -graphPanel.Width / 2 / scale)
            {
                x1 = i;
                y1 = 5*Math.Sin(x1);
                x1 = graphPanel.Width - (mark - x1) * scale;
                y1 = (graphPanel.Height / 2) - y1 * scale;
                i -= 0.25;
                x2 = i;
                y2 = 5*Math.Sin(x2);
                x2 = graphPanel.Width - (mark - x2) * scale;
                y2 = (graphPanel.Height / 2) - y2 * scale;
                graphics.DrawLine(colorGraphic, (float)x1, (float)y1, (float)x2, (float)y2);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBarLabelCurrent.Text = "("+((-graphPanel.Width / 2) / scaleBar.Value).ToString() + " ; " + ((graphPanel.Width / 2) / scaleBar.Value).ToString()+")";
            scaleBar.TickFrequency = 5;
            float scale = scaleBar.Value;
            drawGraphic(scale);

        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {

            drawGraphic(scaleBar.Value);
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm sf = new settingsForm();
            sf.ShowDialog();
        }

    }

        
}
