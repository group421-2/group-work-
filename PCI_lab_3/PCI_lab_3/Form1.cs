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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void drawGraphic(float scale)
        {

            Pen grid = new Pen(new SolidBrush(Color.Black), 1f); // Рисую ось черными линиями.
            Pen arrows = new Pen(new SolidBrush(Color.Black), 2f);
            Pen colorGraphic = new Pen(new SolidBrush(Color.Red), 1f);
            Graphics graphics = panel1.CreateGraphics(); // Рисую график на Panel.
            graphics.Clear(panel1.BackColor);


            // Рисую ось:
            graphics.DrawLine(grid, 0, panel1.Width / 2, panel1.Width, panel1.Width / 2);
            graphics.DrawLine(grid, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);

            /**
             * Рисование стрелки на оси Х
             */
            graphics.DrawLine(arrows, panel1.Width, panel1.Height / 2, panel1.Width - 15, panel1.Height / 2 - 10);
            graphics.DrawLine(arrows, panel1.Width, panel1.Height / 2, panel1.Width - 15, panel1.Height / 2 + 10);


            /**
             * Рисование стрелки на оси У
             */
            graphics.DrawLine(arrows, panel1.Width / 2, 0, panel1.Height / 2 - 15, 15);
            graphics.DrawLine(arrows, panel1.Width / 2, 0, panel1.Height / 2 + 15, 15);
            double i = panel1.Width / 2 / scale;
            double x1, y1,
                 x2, y2;
            
            double mark = (panel1.Width / 2) / scale;
            int pointX = panel1.Width, pointY = panel1.Height;

            /**
             * Размечаем ось Х
            */
            if (trackBar1.Value > 15)
            {
                while (pointX > 0)
                {
                    graphics.DrawLine(grid, pointX, panel1.Width / 2 - 5, pointX, panel1.Width / 2 + 5);
                    pointX -= Convert.ToInt32(scale);
                }
                /**
                 * Размечаем ось Y
                 */
                while (pointY > 0)
                {
                    graphics.DrawLine(grid, panel1.Height / 2 - 5, pointY, panel1.Width / 2 + 5, pointY);
                    pointY -= Convert.ToInt32(scale);
                }
            }
            while (i > -panel1.Width / 2 / scale)
            {
                x1 = i;
                y1 = Math.Sin(x1);
                x1 = panel1.Width - (mark - x1) * scale;
                y1 = (panel1.Height / 2) - y1 * scale;
                i--;
                x2 = i;
                y2 = Math.Sin(x2);
                x2 = panel1.Width - (mark - x2) * scale;
                y2 = (panel1.Height / 2) - y2 * scale;
                graphics.DrawLine(colorGraphic, (float)x1, (float)y1, (float)x2, (float)y2);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBarLabelCurrent.Text = trackBar1.Value.ToString();
            trackBar1.TickFrequency = 5;
            float scale = trackBar1.Value;
            drawGraphic(scale);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawGraphic(trackBar1.Value);
            trackBarLabelMinimum.Text = trackBar1.Minimum.ToString();
            trackBarLabelMaximum.Text = trackBar1.Maximum.ToString();
        }
    }

        
}
