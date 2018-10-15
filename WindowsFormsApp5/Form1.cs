using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp5
{

    public partial class Form1 : Form
    {
        double[] arr = new double[20];
        Random rnd = new Random();
        double step_x;
        double max_y;

        public double find_max(double[] arr)
        {
            double r = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                r = Math.Max(r, arr[i]);
            }
            return r;
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000);
            }
            step_x = pictureBox1.Width / arr.Length;
            max_y = find_max(arr);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.LightGray);
            label1.Text = "";
            for (int i = 0; i < arr.Length; i++) {
                g.FillRectangle(brush, (float)step_x*i, (float)((1-arr[i]/max_y)*pictureBox1.Height), (float)step_x, (float)find_max(arr)-1);
                g.DrawRectangle(pen, (float)step_x*i, (float)((1-arr[i]/ max_y) * pictureBox1.Height), (float)step_x, (float)find_max(arr)-1);
                label1.Text += arr[i].ToString() + " ";
            }

        }
    }
}
