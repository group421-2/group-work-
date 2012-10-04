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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen grid = new Pen(new SolidBrush(Color.Black), 1f); // Рисую ось черными линиями.
            Pen arrows = new Pen(new SolidBrush(Color.Black), 2f);
            Graphics graphics = panel1.CreateGraphics(); // Рисую график на Panel.

            // Рисую ось:
            graphics.DrawLine(grid, 0, panel1.Width / 2, panel1.Width, panel1.Width / 2);
            graphics.DrawLine(grid, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            int scale = 50;
            int x = panel1.Width;
            /**
             * Размечаем ось Х
             */
            while (x > 0)
            {
                graphics.DrawLine(grid, x, panel1.Width / 2 - 5, x, panel1.Width / 2 + 5);
                x -= scale;
            }
            /**
             * Рисование стрелки на оси Х
             */
            graphics.DrawLine(arrows, panel1.Width, panel1.Height / 2, panel1.Width - 15, panel1.Height /2 - 10);
            graphics.DrawLine(arrows, panel1.Width, panel1.Height / 2, panel1.Width - 15, panel1.Height / 2 + 10);


            /**
             * Размечаем ось Y
             */
            int y = panel1.Height;
            while (y > 0)
            {
                graphics.DrawLine(grid, panel1.Height / 2 - 5, y, panel1.Width / 2 + 5, y);
                y -= scale;
            }
            
            /**
             * Рисование стрелки на оси У
             */
            graphics.DrawLine(arrows, panel1.Width / 2, 0, panel1.Height / 2 - 15, 15);
            graphics.DrawLine(arrows, panel1.Width / 2, 0, panel1.Height / 2 + 15, 15);
            drawGraphic(scale);
            
        }

        private void drawGraphic(float scale)
        {
            float i = 5;
            float x1,y1,
                 x2, y2;
            Pen colorGraphic = new Pen(new SolidBrush(Color.Red), 1f);
            Graphics graphics = panel1.CreateGraphics(); // Рисую график на Panel.
            float mark = (panel1.Width / 2) / scale;
            while (i > -5)
            {
                x1 = i;
                y1 = x1 * x1 * x1;
                x1 = panel1.Width - (mark - x1) * scale;
                y1 = (panel1.Height / 2) - y1 * scale;
                i--;
                x2 = i;
                y2 = x2 * x2 * x2;
                x2 = panel1.Width - (mark - x2) * scale;
                y2 = (panel1.Height / 2) - y2 * scale;
                graphics.DrawLine(colorGraphic, x1, y1, x2, y2);
            }
        }
    }

        
}
