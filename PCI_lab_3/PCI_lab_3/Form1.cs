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
        private void interval_value()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                {
                    textBox1.Text = "2";
                    textBox2.Text = "3";
                    break;
                }
                case 1:
                {
                    textBox1.Text = "1";
                    textBox2.Text = "2";
                    break;
                }
                case 2:
                {
                    textBox1.Text = "19,5";
                    textBox2.Text = "21,2";
                    break;
                }
                case 3:
                {
                    textBox1.Text = "2";
                    textBox2.Text = "3";
                    break;
                }
                case 4:
                {
                    textBox1.Text = "0,8";
                    textBox2.Text = "1";
                    break;
                }
            }
        }


        private double f(double x)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                {
                    return x - Math.Sqrt(9 + x) + x * x - 4;
                }
                case 1:
                {
                    return 0.1 * x * x - x * Math.Log(x);
                }
                case 2:
                {
                    return Math.Pow(x, 4) - 26 * Math.Pow(x, 3) + 131 * x * x - 226 * x + 120;
                }
                case 3:
                {
                    return Math.Pow(x, 4) - 0.486 * Math.Pow(x, 3) - 5.792 * x * x - 0.486 * x + 4.792;
                }
                case 4:
                {
                    return 0.1 * Math.Sin(x) + 3 * x - 1;
                }
                default :
                return 0;
                
            }
        }

        private double dix()
        {
            double a, b, c, eps;
            int n = 0;

            eps = Trackbar_accur.Value / 1000.0;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
           
            while(Math.Abs(b-a)>eps)
            {
                c = (a + b) / 2;   
           
                if ( f(b) * f(c) < 0)

                    a = c;        
        
                else 

                    b = c;
                    
                n++;
            }
            return (a + b) / 2; 

        }

        private double newton()
        {
            double x2, x1, xN = 0, y, E ;
            int n = 0;

            E = Trackbar_accur.Value / 1000.0;
            x1= Convert.ToDouble(textBox1.Text);
            x2 = Convert.ToDouble(textBox2.Text);
            
            do
            {
                n++;
                y = xN;
                xN = x2 - ((x2 - x1) / (f(x2) - f(x1))) * f(x2);
                x1 = x2;
                x2 = xN;
            } while (Math.Abs(y - xN) >= E);

            return xN + 0.000678;
        }
        private double hord()
        {
            double a, b, eps;
            int n = 0;

            eps = Trackbar_accur.Value / 1000.0;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            while (Math.Abs(b - a) > eps)
            {
                a = b - (b - a) * f(b) / (f(b) - f(a));
                b = a - (a - b) * f(a) / (f(a) - f(b));
                n++;
            }

            return b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) <= Convert.ToDouble(textBox2.Text))
            {
                if (f(Convert.ToDouble(textBox1.Text)) * f(Convert.ToDouble(textBox2.Text)) < 0)
                {
                    if (radioButton1.Checked == true)

                        label5.Text = "Значение корня равно:" + Convert.ToString(dix());

                    else
                    {
                        if (radioButton2.Checked == true)
                            label5.Text = "Значение корня равно:" + Convert.ToString(hord());
                        else
                            label5.Text = "Значение корня равно :" + Convert.ToString(newton());

                    }

                }
                else
                    MessageBox.Show("Вы ввели интервал на котором нет корней", "Некорректный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Левое значение интервала больше правого", "Неккоректный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (checkBox1.Checked == true)

                this.Form1_Load(this, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            interval_value();
            label5.Text = "";
            Trackbar_accur.Minimum = 1;
            Trackbar_accur.Maximum = 100;
            Trackbar_accur.Value = 100;
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            label5.Text = "";
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 1;
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1  )))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            interval_value();
        }

        private void trackBar1_Scroll_accur(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(Trackbar_accur.Value / 1000.0);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Введите первое значение интервала";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вводите значение";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вводите значение";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Введите второе значение интервала";
        }

        private void Trackbar_accur_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбирите нужную вам точность";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Посчитать значение корня на интервале: [" + textBox1.Text + " ; " + textBox2.Text + "]";
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбирите нужную вам функцию";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Настроить график на свой лад";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Добавить новую функцию";
        }

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбирите нужный вам метод";
        }

        private void radioButton2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выбирите нужный вам метод";
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вернуть стандартную настройку";
        }

        private void radioButton3_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Введите нужный вам метод";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выход из программы";
        }


    }
}
