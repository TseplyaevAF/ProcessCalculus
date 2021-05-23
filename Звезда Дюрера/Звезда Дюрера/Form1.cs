using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Звезда_Дюрера
{
    public partial class Form1 : Form
    {
        Pen p;
        SolidBrush backgroundColor;
        Graphics gr;
        static double pi = 3.14;
        double angle = pi / 2;
        int radius = 85;

        public Form1()
        {
            InitializeComponent();
            label_Angle.Text += "90";
            label_Radius.Text += "85";
        }

        void Draw_Pentagon(double x, double y, double r, double angle)
        {
            p = new Pen(Color.Blue, 2);
            gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int i;
            double[] x1 = new double[5];
            double[] y1 = new double[5];

            for (i = 0; i < 5; i++)
            {
                x1[i] = r * Math.Cos(angle + i * pi * 2 / 5);
                y1[i] = r * Math.Sin(angle + i * pi * 2 / 5);
            }

            for (i = 0; i < 4; i++)
            {
                gr.DrawLine(p, (int)Math.Round(x + x1[i]), (int)Math.Round(y + y1[i]), (int)Math.Round(x + x1[i + 1]), (int)Math.Round(y + y1[i + 1]));
            }
        }

        void Draw_Star(double x, double y, double r, double angle, int d)
        {
            int i;
            double h;

            h = 2 * r * Math.Cos(pi / 5);

            for (i = 0; i < 5; i++)
            {
                Draw_Pentagon(x - h * Math.Cos(angle + i * pi * 2 / 5), y - h * Math.Sin(angle + i * pi * 2 / 5), r, angle + pi + i * pi * 2 / 5);

                if (d > 0)
                    Draw_Star(x - h * Math.Cos(angle + i * pi * 2 / 5), y - h * Math.Sin(angle + i * pi * 2 / 5), r / (2 * Math.Cos(pi / 5) + 1), angle + pi + (2 * i + 1) * pi * 2 / 10, d - 1);
            }
            Draw_Pentagon(x, y, r, angle);

            if (d > 0)
                Draw_Star(x, y, r / (2 * Math.Cos(pi / 5) + 1), angle + pi, d - 1);
        }

        private void button_Draw_Click(object sender, EventArgs e)
        {
            backgroundColor = new SolidBrush(BackColor);
            gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.FillRectangle(backgroundColor, 0, 0, pictureBox1.Width, pictureBox1.Height);
            //button_Draw.Enabled = false;

            Thread Thread_Drawing = new Thread(
                // Делегат - ссылка на метод
                delegate ()
                {
                    Draw_Star(300, 250, radius, angle, 4);
                });
            Thread_Drawing.Start();

            //await Task.Run(() =>
            //{
            //    Draw_Star(300, 250, radius, angle, 4);
            //});

            //button_Draw.Enabled = true;
        }

        double DegreesToRadian(double angle) => angle * pi / 180;

        private void NewAngle()
        {
            label_Angle.Text = "Угол: ";
            angle = Convert.ToInt32(textBox_Angle.Text);
            label_Angle.Text += angle.ToString() + " °";
            angle = DegreesToRadian(angle);
        }

        private void NewRadius()
        {
            label_Radius.Text = "Радиус: ";
            radius = Convert.ToInt32(textBox_Radius.Text);
            label_Radius.Text += radius.ToString();
        }

        private void button_SetAngle_Click(object sender, EventArgs e)
        {
            NewAngle();
        }

        private void button_SetRadius_Click(object sender, EventArgs e)
        {
            NewRadius();
        }
    }
}