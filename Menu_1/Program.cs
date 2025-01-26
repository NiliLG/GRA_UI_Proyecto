using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Barras
        int altura = 13;
        int ancho = 6;
        // Posición inicial 
        int x = 22;
        int y = 119;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 5);
        Console.WriteLine("Dibujar gráfica");

        // Tamaño de pantalla
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        // Gráfica
        while (y > 0)
        {
            // Línea horizontal hacia la izquierda
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                if (y - i >= 0 && y - i < consoleWidth && x >= 0)
                {
                    Console.SetCursorPosition(y - i - 1, x);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }



            y -= ancho; // Retroceder en el eje horizontal

            // Línea vertical hacia arriba
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++) // Cambiado a 14 asteriscos azules
            {
                if (y >= 0 && x - i >= 0)
                {
                    Console.SetCursorPosition(y, x - i);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }

            // Línea horizontal hacia la izquierda
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                if (y - i >= 0 && y - i < consoleWidth && x - altura >= 0)
                {
                    Console.SetCursorPosition(y - i-1, x - altura);
                    Console.WriteLine("*");
                    Thread.Sleep(50); // Pausa de 50 ms entre cada asterisco
                }
            }

            

            y -= ancho; // Retroceder en el eje horizontal
            // Línea vertical hacia abajo
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++) // Cambiado a 14 asteriscos azules
            {
                if (y >= 0 && x - altura + i < consoleHeight)
                {
                    Console.SetCursorPosition(y, x - altura + i);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }

            
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(40, 25);
        Console.WriteLine("Listo!!! Presiona una tecla para continuar");

        Console.ReadKey();
    }
}
