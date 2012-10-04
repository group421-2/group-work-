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
            Graphics graphics = panel1.CreateGraphics(); // Рисую график на Panel.

            // Рисую ось:
            graphics.DrawLine(grid, 0, panel1.Width / 2, panel1.Width, panel1.Width / 2);
            graphics.DrawLine(grid, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            int scale = 50;
            int x = panel1.Width;
            /**
             * Рисуем ось Х
             */
            while (x > 0)
            {
                graphics.DrawLine(grid, x, panel1.Width / 2 - 5, x, panel1.Width / 2 + 5);
                x -= scale;
            }
            graphics.DrawLine(grid, 

            /**
             * Рисуем ось Y
             */
            int y = panel1.Height;
            while (y > 0)
            {
                graphics.DrawLine(grid, panel1.Height / 2 - 5, y, panel1.Width / 2 + 5, y);
                y -= scale;
            }

        }
    }

        
}
