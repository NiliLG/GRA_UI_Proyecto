using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace FormsGraficos
{
    public partial class FrmLanzamientoH : Form
    {
        Graphics graphics;
        double posX = 50, posY = 50;
        int ancho = 50, alto = 50;
        const int suelo = 550;
        const double gravedad = 98; // 9.8 * 10
        const double coeficienteRestitucion = 0.7;

        double velocidadX = 20, velocidadY = 0;
        double tiempo = 0;
        int rebotes = 0;

        Timer timer = new Timer { Interval = 16 };
        List<Point> trayectoria = new List<Point>();
        List<string> historialDatos = new List<string>();

        public FrmLanzamientoH()
        {
            InitializeComponent();
            KeyPreview = true;
            timer.Tick += ActualizarMovimiento;
        }

        private void FrmLanzamientoH_Load(object sender, EventArgs e){}
        
        private void pictureBox1_Click(object sender, EventArgs e){ }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;

            Pen ejePen = new Pen(Color.Black, 2);
            Font fuente = new Font("Arial", 10);
            Brush brocha = Brushes.Black;

            // Eje Y (vertical)
            e.Graphics.DrawLine(ejePen, 50, 0, 50, pictureBox1.Height); // desde (50,0) hasta (50,alto)
            e.Graphics.DrawString("Y", fuente, brocha, 30, 10);

            // Eje X (horizontal)
            e.Graphics.DrawLine(ejePen, 0, suelo, pictureBox1.Width, suelo); // desde la izquierda hasta la derecha en la altura del suelo
            e.Graphics.DrawString("X", fuente, brocha, pictureBox1.Width - 20, suelo - 20);

            //Recta
            const double escala = 50.0;
             fuente = new Font("Arial", 8);
             brocha = Brushes.Black;

            //Y
            for (int metros = 0; metros <= 10; metros++)
            {
                int yPixel = suelo - (int)(metros * escala);
                if (yPixel >= 0 && yPixel <= pictureBox1.Height)
                {
                    e.Graphics.DrawLine(Pens.Gray, 45, yPixel, 55, yPixel); // marca corta
                    if (metros % 1 == 0) // mostrar todos los números (puedes cambiar a % 5 si quieres menos)
                        e.Graphics.DrawString($"{metros} m", fuente, brocha, 5, yPixel - 8);
                }
            }
            //X
            for (int metros = 0; metros <= 22; metros++)
            {
                int xPixel = 50 + (int)(metros * escala);
                if (xPixel >= 0 && xPixel <= pictureBox1.Width)
                {
                    e.Graphics.DrawLine(Pens.Gray, xPixel, suelo - 5, xPixel, suelo + 5); // marca corta
                    if (metros % 1 == 0) // mostrar todos los números (o cambia a % 5 si hay saturación)
                        e.Graphics.DrawString($"{metros} m", fuente, brocha, xPixel - 10, suelo + 10);
                }
            }


            Pen pen = new Pen(Color.Blue, 3);
            Rectangle circleBounds = new Rectangle((int)Math.Round(posX), (int)Math.Round(posY), ancho, alto);
            graphics.DrawEllipse(pen, circleBounds);

            foreach (Point punto in trayectoria)
                graphics.FillEllipse(Brushes.Red, punto.X - 2, punto.Y - 2, 4, 4);
        }

        private void FrmLanzamientoH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && !timer.Enabled)
                IniciarLanzamiento();
        }

        private void IniciarLanzamiento()
        {
            tiempo = 0;
            rebotes = 0;
            trayectoria.Clear();

            double angulo = 45 * Math.PI / 180.0; //grados * π / 180     -> grados a radianes
            double velocidadInicial = 50;

            velocidadX = velocidadInicial * Math.Cos(angulo); //vx = v0 * cos(a)    -> magnitud de componente horizontal de la velocidad
            velocidadY = -velocidadInicial * Math.Sin(angulo); //vy = v0 * sen(a)

            timer.Start();
        }


        private void ActualizarMovimiento(object sender, EventArgs e)
        {
            double deltaTime = timer.Interval / 1000.0;
            tiempo += deltaTime;

            double posYAnterior = posY;
            double velocidadYAnterior = velocidadY;

            posX += velocidadX * deltaTime; //x = x0 + v * t     -> formula de movimiento horizontal uniforme
            posY += velocidadY * deltaTime; //y = y0 + v * t  ->  movimiento vertical
            velocidadY += gravedad * deltaTime; //v = v + g * t   -> efecto de gravedad
            if (posY + alto >= suelo)
            {
                //t = (ysuelo - yanterior) / vy   -> tiempo en tocar el suelo
                double tiempoRebote = (suelo - alto - posYAnterior) / velocidadYAnterior;
                tiempoRebote = Math.Clamp(tiempoRebote, 0, deltaTime); //0<t<deltaTime

                posX -= velocidadX * (deltaTime - tiempoRebote);
                posY = suelo - alto;

                velocidadY = -velocidadYAnterior * coeficienteRestitucion; //reducir la velocidad al subir
                rebotes++;

                if (rebotes == 1) { alto = 25; ancho = 80; }
                else { alto = 30; ancho = 70; }

                if (Math.Abs(velocidadY) < 0.5 || rebotes > 5)
                {
                    velocidadY = 0;
                    velocidadX = 0;
                    timer.Stop();
                    ancho = 50;
                    alto = 50;
                }

            }
            else
            {
                if (alto < 50) alto++;
                if (ancho > 50) ancho--;
            }

            if (posX + ancho >= pictureBox1.Width)
            {
                posX = pictureBox1.Width - ancho;
                velocidadX = 0;
            }
            //punto a la trayectoria -> centro de la pelotita
            trayectoria.Add(new Point((int)Math.Round(posX + ancho / 2), (int)Math.Round(posY + alto / 2)));

            pictureBox1.Refresh();
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            const double equiv = 50.0; // 50 píxeles = 1 metro
            double altura = Math.Max(0, (suelo - (posY + alto)) / equiv);
            double distancia = (posX - 50) / equiv;
            this.Text = $"Altura: {altura:F2} m | Distancia: {distancia:F2} m | VelY: {velocidadY:F1}px/s | Rebotes: {rebotes}";

            //agregar a lista
            string datos = $"Alt: {altura:F2} m | Dist: {distancia:F2} m";
            listBox1.Items.Add(datos);
        }

    }
}
