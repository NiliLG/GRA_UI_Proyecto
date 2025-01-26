using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int opcion;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 2);
        Console.WriteLine("Menú");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Gráfica de barras con asteriscos");
        Console.WriteLine("2. Espiral de asteriscos");
        Console.WriteLine("2. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nSelecciona una opción: ");
        opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                DibujarGrafica();
                break;
            case 2:
                DibujarEspiral();
                break;
            case 3:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                break;
        }
        Console.ReadKey();
    }
    static void DibujarGrafica()
    {
        Console.Clear();
        //Tamaño de barras
        int altura = 13;
        int ancho = 6;
        //Posición inicial 
        int x = 22;
        int y = 119;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 5);
        Console.WriteLine("Dibujar gráfica");

        //Tamaño de pantalla
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        //Gráfica
        while (y > 0)
        {
            //<-
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

            //Arriba
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++)
            {
                if (y >= 0 && x - i >= 0)
                {
                    Console.SetCursorPosition(y, x - i);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }

            //<-
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                if (y - i >= 0 && y - i < consoleWidth && x - altura >= 0)
                {
                    Console.SetCursorPosition(y - i - 1, x - altura);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
            y -= ancho; // Retroceder en el eje horizontal

            //Abajo
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++)
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
    }
    static void DibujarEspiral()
    { 

    }
}
