using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DarkUI.Forms;

namespace IILab5
{
    public partial class Form1 : DarkForm
    {
        const double d = 1;
        const int MAX_POSIBALITY = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        double Proiz1(double x)
        {
            return Math.Cos(x) + 2 * x * Math.Cos(x * x);
        }
        double Norm(double x, double y)
        {
            return Math.Sqrt((x * x) + (y * y));
        }
        double Proiz2(double x)
        {
            return Math.Cos(x) + x * Math.Sin(x * x * x);
        }

        void Action1()
        {
            double E = Convert.ToDouble("0," + t_e.Text);
            double x0 = Convert.ToDouble(darkTextBox1.Text);
            double x1 = x0 - d * Proiz1(x0) / Norm(x0, Proiz1(x0));
            int i = 1;
            chart1.Series[0].Points.AddXY(i, x1);
            while (Math.Abs(x1 - x0) > E)
            {
                if (i == MAX_POSIBALITY)
                    break;
                x0 = x1;
                x1 = x0 - d * Proiz1(x0) / Norm(x0, Proiz1(x0));
                i++;
                chart1.Series[0].Points.AddXY(i, x1);
            }
            darkLabel1.Text = x1.ToString();
            darkLabel2.Text = i.ToString();
        }
        void Action2()
        {
            double E = Convert.ToDouble("0," + t_e.Text);
            double x0 = Convert.ToDouble(darkTextBox1.Text);
            double x1 = x0 - d * Proiz2(x0) / Norm(x0, Proiz2(x0));
            int i = 1;
            chart1.Series[0].Points.AddXY(i, x1);
            while (Math.Abs(x1 - x0) > E)
            {
                if (i == MAX_POSIBALITY)
                    break;
                x0 = x1;
                x1 = x0 - d * Proiz2(x0) / Norm(x0, Proiz2(x0));
                i++;
                chart1.Series[0].Points.AddXY(i, x1);
            }
            darkLabel1.Text = x1.ToString();
            darkLabel2.Text = i.ToString();
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if (darkRadioButton1.Checked == true)
            {
                Action1();
            }
            else
            {
                Action2();
            }
        }
        private void darkTextBox1_KeyPress(object sender, KeyPressEventArgs e) //запрет на ввод
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 45 && number != 44)
            {
                e.Handled = true;
            }
        }
        private void darkTextBox2_KeyPress(object sender, KeyPressEventArgs e) //запрет на ввод
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }


        void Copyraight()
        {
            MessageBox.Show("Created and Development by AK.);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                Copyraight();
            }
        }
    }
}
