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
            Graphics graphics = graphPanel.CreateGraphics(); // Рисую график на Panel.
            graphics.Clear(graphPanel.BackColor);


            // Рисую ось:
            graphics.DrawLine(grid, 0, graphPanel.Width / 2, graphPanel.Width, graphPanel.Width / 2);
            graphics.DrawLine(grid, graphPanel.Width / 2, 0, graphPanel.Width / 2, graphPanel.Height);

            /**
             * Рисование стрелки на оси Х
             */
            graphics.DrawLine(arrows, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 15, graphPanel.Height / 2 - 10);
            graphics.DrawLine(arrows, graphPanel.Width, graphPanel.Height / 2, graphPanel.Width - 15, graphPanel.Height / 2 + 10);


            /**
             * Рисование стрелки на оси У
             */
            graphics.DrawLine(arrows, graphPanel.Width / 2, 0, graphPanel.Height / 2 - 15, 15);
            graphics.DrawLine(arrows, graphPanel.Width / 2, 0, graphPanel.Height / 2 + 15, 15);
            double i = graphPanel.Width / 2 / scale;
            double x1, y1,
                 x2, y2;
            
            double mark = (graphPanel.Width / 2) / scale;
            int pointX = graphPanel.Width, pointY = graphPanel.Height;

            /**
             * Размечаем ось Х
            */
            if (scaleBar.Value > 15)
            {
                while (pointX > 0)
                {
                    graphics.DrawLine(grid, pointX, graphPanel.Width / 2 - 5, pointX, graphPanel.Width / 2 + 5);
                    pointX -= Convert.ToInt32(scale);
                }
                /**
                 * Размечаем ось Y
                 */
                while (pointY > 0)
                {
                    graphics.DrawLine(grid, graphPanel.Height / 2 - 5, pointY, graphPanel.Width / 2 + 5, pointY);
                    pointY -= Convert.ToInt32(scale);
                }
            }
            while (i > -graphPanel.Width / 2 / scale)
            {
                x1 = i;
                y1 = Math.Sin(x1);
                x1 = graphPanel.Width - (mark - x1) * scale;
                y1 = (graphPanel.Height / 2) - y1 * scale;
                i--;
                x2 = i;
                y2 = Math.Sin(x2);
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawGraphic(scaleBar.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drawGraphic(scaleBar.Value);
        }
    }

        
}
