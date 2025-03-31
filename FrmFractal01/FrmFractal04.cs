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
    public partial class FrmFractal04 : Form
    {
        public FrmFractal04()
        {
            InitializeComponent();
        }

        private void FrmFractal04_Load(object sender, EventArgs e)
        {
            NewtonFractal();
        }
        private void NewtonFractal()
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;
            Bitmap bmp = new Bitmap(width, height);

            double tol = 1e-6;
            Complex[] roots = { new Complex(1, 0), new Complex(-0.5, Math.Sqrt(3) / 2), new Complex(-0.5, -Math.Sqrt(3) / 2) };
            Color[] colors = { Color.Red, Color.Green, Color.Blue };

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Complex z = new Complex((col - width / 2.0) * 4.0 / width, (row - height / 2.0) * 4.0 / height);
                    int iteraciones = 0;

                    while (iteraciones < 50)
                    {
                        Complex fz = z * z * z - 1;
                        Complex dfz = 3 * z * z;
                        if (dfz.Magnitude < tol) break;
                        Complex z_new = z - fz / dfz;

                        if ((z_new - z).Magnitude < tol)
                            break;

                        z = z_new;
                        iteraciones++;
                    }

                    int closestRoot = 0;
                    double minDist = (z - roots[0]).Magnitude;
                    for (int i = 1; i < roots.Length; i++)
                    {
                        double dist = (z - roots[i]).Magnitude;
                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestRoot = i;
                        }
                    }

                    Color baseColor = colors[closestRoot];
                    int intensity = 255 - (iteraciones * 5 % 255);
                    bmp.SetPixel(col, row, Color.FromArgb(intensity * baseColor.R / 255, intensity * baseColor.G / 255, intensity * baseColor.B / 255));
                }
            }
            pictureBox.Image = bmp;
        }
    }
}
