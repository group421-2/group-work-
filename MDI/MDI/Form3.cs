using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            cl = Color.Black;
        }

        private Bitmap drawing;
        public Color cl = new Color();
        private bool leftDown = false;
        private int prevX;
        private int prevY;
        private int currentX;
        private int currentY;
        private Boolean k = true;

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cl = panel1.BackColor;
            if (leftDown)
            {
                Graphics g = Graphics.FromImage(drawing);

                currentX = e.X;
                currentY = e.Y;

                if (k == true)
                {
                    g.DrawLine(new Pen(cl, 5), new Point(currentX, currentY), new Point(prevX, prevY));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(pictureBox1.BackColor), currentX, currentY, 5 * 5, 5 * 5);
                }

                pictureBox1.Invalidate();

                prevX = currentX;
                prevY = currentY;
                g.Dispose();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            leftDown = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftDown = true;

                prevX = e.X;
                prevY = e.Y;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            leftDown = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawing, 0, 0);
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

    }
}
