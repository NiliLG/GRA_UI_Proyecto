using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsGraficos
{
    public partial class FrmLineasEscalar : Form
    {
        public FrmLineasEscalar()
        {
            InitializeComponent();
        }
        Graphics graphics;
        int ex=1, ey=1;
        private void ptbDibujo_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            Pen pen = new Pen(Color.Blue, 3);
            Rectangle rectangle = new Rectangle(ex, 50, 50+ey, 50+ex);//punto inicial, medidas (50 de largo y 50 de ancho)
            graphics.DrawRectangle(pen, rectangle);
        }

        private void FrmLineasEscalar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    //Incremento
                    ex++;
                    ey++;
                    ptbDibujo.Refresh();
                    break;
                case Keys.Down:
                    //Decremento
                    if (ex > 1)
                    {
                        ex--;
                        ey--;
                        ptbDibujo.Refresh();
                    }
                    break;
            }
        }
    }
}
