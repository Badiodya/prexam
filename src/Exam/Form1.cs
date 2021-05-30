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

namespace Exam
{
    public partial class Form1 : Form
    {
        int page_Count;
        string result;
        Dialog dialog;
        public Form1()
        {
            InitializeComponent();
        }


        private void страница1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\pages\page1.html";
            webBrowser1.Navigate(path);
            this.Width = 1250;
            page_Count = 1;
        }

        private void страница2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\pages\page2.html";
            webBrowser1.Navigate(path);
            this.Width = 1250;
            page_Count = 2;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                if (page_Count == 1)
                {
                    double x1 = 1, y1 = 2, x2 = 3, y2 = 0, x3 = 1, y3 = -2;
                    double s = 1 / 2.0 * Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1));
                    double s1 = 1 / 2.0 * Math.Abs((x2 - x1) * (y - y1) - (x - x1) * (y2 - y1));
                    double s2 = 1 / 2.0 * Math.Abs((x - x1) * (y3 - y1) - (x3 - x1) * (y - y1));
                    double s3 = 1 / 2.0 * Math.Abs((x2 - x) * (y3 - y) - (x3 - x) * (y2 - y));
                    if ((x <= 1 && x >= -1 && y <= 2 && y >= -2 && Math.Pow(x - 1, 2) + y * y == 4) || ((x <= 3 && x >= 1 && y <= 2 && y >= -2) && (s1==0||s2==0||s3==0)))
                        result = "Точка принадлежит границе области";
                    else if ((x < 1 && x > -1 && y < 2 && y > -2) || ((x < 3 && x > 1 && y < 2 && y > -2) && (s == s1 + s2 + s3)))
                        result = "Точка принадлежит области";
                    else
                        result = "Точка не принадлежит области";
                }
                else
                {
                    if ((x == y && x <= 1 && y >= -1 && y <= 0) || (x <= 1 && x >= 0 && y >= -1 && y <= 0 && x * x + y * y == 1))
                        result = "Точка принадлежит границе области";
                    else if (x < 1 && x > -1 && y > -1 && y < 0 && x!=y)
                        result = "Точка принадлежит области";
                    else
                        result = "Точка не принадлежит области";
                }
                dialog = new Dialog();
                dialog.label1.Text = result;
                dialog.ShowDialog();
                toolStripStatusLabel1.Text = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка,введите данные","Ошибка",MessageBoxButtons.OK);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнила студентка группы Пксп Новикова Александра","Информация",MessageBoxButtons.OK);
        }
    }
}
