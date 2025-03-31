using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsFractales
{
    public partial class FrmFractal02 : Form
    {
        public FrmFractal02()
        {
            InitializeComponent();
        }

        private void FrmFractal02_Load(object sender, EventArgs e)
        {
            JuliaSet();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
        private void JuliaSet()
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            Bitmap bmp = new Bitmap(width, height);

            double c_re = -0.7, c_im = 0.27015; 

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    double x = (col - width / 2) * 4.0 / width;
                    double y = (row - height / 2) * 4.0 / width;
                    int iteraciones = 0;

                    while (iteraciones < 1000 && ((x * x) + (y * y)) <= 4)
                    {
                        double x_temp = (x * x) - (y * y) + c_re;
                        y = 2 * x * y + c_im;
                        x = x_temp;
                        iteraciones++;
                    }

                    if (iteraciones < 1000)
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteraciones % 150, iteraciones % 50, iteraciones % 50));
                    }
                    else
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteraciones % 10, iteraciones % 60, iteraciones % 20));
                    }
                }
            }
            pictureBox.Image = bmp;
        }
    }
}
