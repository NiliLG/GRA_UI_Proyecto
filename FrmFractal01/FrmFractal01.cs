namespace FrmFractal01
{
    public partial class FrmFractal01 : Form
    {
        public FrmFractal01()
        {
            InitializeComponent();
        }

        private void FrmFractal01_Load(object sender, EventArgs e)
        {
            MandelbrotSet();
        }

        private void MandelbrotSet()
        {
            int width = pictureBoxMandelbrot.Width;
            int height = pictureBoxMandelbrot.Height;

            Bitmap bmp = new Bitmap(width, height);

            for (int row = 0; row < width; row++)
            { //ancho, filas
                for (int col = 0; col < height; col++)
                { //columnas
                    double c_re = (col - width / 2) * 4.0 / width;
                    double c_im = (row - height / 2) * 4.0 / width;
                    int iteraciones = 0;
                    double x = 0, y = 0;

                    while (iteraciones < 1000 && ((x * x) + (y * y)) <= 4) //diametro=4
                    {
                        double x_temporal = (x * x) - (y * y) + c_re;
                        y = 2 * x * y + c_im;
                        x = x_temporal;
                        iteraciones++;
                    }
                    if (iteraciones < 1000)
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteraciones % 128, iteraciones % 50 * 5, iteraciones % 10));
                        //bmp.SetPixel(col, row, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteraciones % 100, iteraciones % 60, iteraciones % 20));
                    }
                }
            }
            pictureBoxMandelbrot.Image = bmp;
        }

        private void pictureBoxMandelbrot_Click(object sender, EventArgs e)
        {

        }
    }
}
