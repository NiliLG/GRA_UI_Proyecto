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
        Console.WriteLine("3. Cuadrado con asteriscos");
        Console.WriteLine("0. Salir");
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
                Console.Clear();
                DrawSquares();
                break;
            case 0:
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
    static void DrawSquares()
    {
        int consoleWidth = 80;
        int consoleHeight = 25;
        int spacing = 3;

        Console.Clear();
        DrawFirstGroup(consoleWidth, consoleHeight);

        for (int layer = 1; layer <= 3; layer++)
        {
            DrawRectangle(layer, consoleWidth, consoleHeight, spacing);
        }

        Console.ResetColor();
        Console.SetCursorPosition(0, consoleHeight);
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }

    static void DrawFirstGroup(int consoleWidth, int consoleHeight)
    {
        int centerX = (consoleWidth / 2) + 16;  // 🔹 Corrección del centro
        int centerY = consoleHeight / 2;

        Console.ForegroundColor = ConsoleColor.Green;
        DrawAt(centerX, centerY);
        DrawAt(centerX - 1, centerY);
        DrawAt(centerX + 1, centerY);
    }


    static void DrawRectangle(int layer, int consoleWidth, int consoleHeight, int spacing)
    {
        ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue };
        Console.ForegroundColor = colors[layer % colors.Length];

        int centerX = consoleWidth / 2 + 15;
        int centerY = consoleHeight / 2;

        int width = (layer * spacing * 4);
        int height = (layer * spacing * 2);

        int startX = centerX - (width / 2) + 1;  // 🔹 Ajuste +1 para corregir desplazamiento
        int startY = centerY - (height / 2);
        int endX = startX + width;
        int endY = startY + height;

        for (int x = startX; x <= endX; x++) DrawAt(x, startY);
        for (int y = startY + 1; y <= endY; y++) DrawAt(endX, y);
        for (int x = endX - 1; x >= startX; x--) DrawAt(x, endY);
        for (int y = endY - 1; y > startY; y--) DrawAt(startX, y);
    }

    static void DrawAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < Console.WindowWidth && y < Console.WindowHeight)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            Thread.Sleep(10);
        }
    }
}
