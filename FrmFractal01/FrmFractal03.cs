using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsFractales
{
    public partial class FrmFractal03 : Form
    {
        public FrmFractal03()
        {
            InitializeComponent();
        }

        private void FrmFractal03_Load(object sender, EventArgs e)
        {
            PhoenixSet();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
        private void PhoenixSet()
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;
            Bitmap bmp = new Bitmap(width, height);

            double cr = 0.5667, ci = 0.0;
            double pr = -0.5, pi = 0.0;
            double k = 10.0;
            double xmin = -1.35, xmax = 1.35, ymin = -1.35, ymax = 1.35;
            int maxIter = 500;
            double maxZ = 4.0;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    double x0 = xmin + (xmax - xmin) * col / width;
                    double y0 = ymin + (ymax - ymin) * row / height;
                    Complex z1 = new Complex(x0, y0);
                    Complex z2 = new Complex(0.0, 0.0);
                    Complex c = new Complex(cr, ci);
                    Complex p = new Complex(pr, pi);
                    int iteraciones = 0;

                    while (z1.Magnitude < maxZ && iteraciones < maxIter)
                    {
                        Complex z = z1 * z1 + c + p * z2;
                        z2 = z1;
                        z1 = z;
                        iteraciones++;
                    }

                    int colorVal = (int)(iteraciones * k) % 256;
                    bmp.SetPixel(col, row, Color.FromArgb(colorVal, 0, (colorVal * 2) % 256));
                }
            }
            pictureBox.Image = bmp;
        }
    }
}
