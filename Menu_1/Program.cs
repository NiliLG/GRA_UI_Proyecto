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
                Console.Clear();
                DibujarGrafica();
                break;
            case 2:
                Console.Clear();
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
        int pancho = Console.WindowWidth;
        int palto = Console.WindowHeight;

        //Gráfica
        while (y > 0)
        {
            //<-
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                if (y - i >= 0 && y - i < pancho && x >= 0)
                {
                    Console.SetCursorPosition(y - i - 1, x);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
            y -= ancho; //Retroceder en el eje horizontal

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
                if (y - i >= 0 && y - i < pancho && x - altura >= 0)
                {
                    Console.SetCursorPosition(y - i - 1, x - altura);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
            y -= ancho; //Retroceder en el eje horizontal

            //Abajo
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++)
            {
                if (y >= 0 && x - altura + i < palto)
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
        int x = Console.WindowWidth / 2, y = Console.WindowHeight / 2, pasos = 1, masHor = 0, masVer = 0, direccion = 0;
        int maxPasos = Math.Min(Console.WindowWidth, Console.WindowHeight) / 2;
        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Cyan };

        while (pasos <= maxPasos)
        {
            for (int d = 0; d < 2; d++)
            {
                int pasosActuales = pasos + (direccion % 2 == 0 ? masHor : masVer);
                for (int i = 0; i < pasosActuales; i++)
                {
                    Console.ForegroundColor = colores[(x + y) % colores.Length];
                    Console.SetCursorPosition(x, y);
                    Console.Write("*");
                    Thread.Sleep(20);
                    switch (direccion)
                    {
                        case 0: x--; break; // Izquierda
                        case 1: y--; break; // Arriba
                        case 2: x++; break; // Derecha
                        case 3: y++; break; // Abajo
                    }
                }
                if (direccion % 2 == 0) masHor += 4; else masVer += 1;
                direccion = (direccion + 1) % 4;
            }
            pasos++;
        }
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ResetColor();
        Console.WriteLine("¡Espiral completa! Presiona cualquier tecla para salir.");

    }
}
