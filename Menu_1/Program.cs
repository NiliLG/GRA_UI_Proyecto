using System;
using System.Threading;

class Program
{
    static void Main()
    {
        MP();
    }
    static void MP()
    {
        Console.Clear();
        int opcion;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 2);
        Console.WriteLine("Menú principal");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Menú 1. Programas de introducción.");
        Console.WriteLine("2. Menú 2. Programas de localización.");
        Console.WriteLine("3. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nSelecciona una opción: ");
        opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                Console.Clear();
                M1();
                break;
            case 2:
                Console.Clear();
                M2();
                break;
            case 3:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                break;
        }
    }

    static void M1()
    {
        Console.Clear();
        int opcion;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 2);
        Console.WriteLine("Menú 1");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Gráfica de barras con asteriscos");
        Console.WriteLine("2. Espiral de asteriscos");
        Console.WriteLine("3. Cuadrado con asteriscos");
        Console.WriteLine("4. Menú anterior");
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
                DibujarCuadrados();
                break;
            case 4:
                Console.Clear();
                MP();
                break;
            case 0:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                break;
        }
    }

    static void M2()
    {
        Console.Clear();
        int opcion;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 2);
        Console.WriteLine("Menú 2");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Tabla de senos del 0 al 90");
        Console.WriteLine("2. Tabla de cosenos del 0 al 90");
        Console.WriteLine("3. Calcular hipotenusa y ángulos de un triángulo rectángulo");
        Console.WriteLine("4. Calcular pendiente, ángulo de inclinación y punto medio");
        Console.WriteLine("5. Trayectoria de un proyectil en intervalos de tiempo");
        Console.WriteLine("6. Menú anterior");
        Console.WriteLine("0. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nSelecciona una opción: ");
        opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                Console.Clear();
                MostrarTablaSeno();
                break;
            case 2:
                Console.Clear();
                MostrarTablaCoseno();
                break;
            case 3:
                Console.Clear();
                Triangulo();
                break;
            case 4:
                Console.Clear();
                CalcularDatosRecta();
                break;
            case 5:
                Console.Clear();
                CalcularTrayectoriaProyectil();
                break;
            case 6:
                Console.Clear();
                MP();
                break;
            case 0:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta de nuevo.");
                break;
        }
    }
    // MENÚ 1 ----------------------------------------------------------------------------------------------------------------------------------------------------
    static void DibujarGrafica()
    {

        int altura = 13;
        int ancho = 6;
        int x = 22;
        int y = 119;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(50, 5);
        Console.WriteLine("Dibujar gráfica");

        int pancho = Console.WindowWidth;  // Ancho de la consola
        int palto = Console.WindowHeight;  // Alto de la consola

        while (y > 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                int newY = y - i - 1;
                if (newY >= 0 && newY < pancho && x >= 0 && x < palto)
                {
                    Console.SetCursorPosition(newY, x);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
            y -= ancho;

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++)
            {
                int newX = x - i;
                if (y >= 0 && y < pancho && newX >= 0 && newX < palto)
                {
                    Console.SetCursorPosition(y, newX);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < ancho; i++)
            {
                int newY = y - i - 1;
                int newX = x - altura;
                if (newY >= 0 && newY < pancho && newX >= 0 && newX < palto)
                {
                    Console.SetCursorPosition(newY, newX);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
            y -= ancho;

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 14; i++)
            {
                int newX = x - altura + i;
                if (y >= 0 && y < pancho && newX >= 0 && newX < palto)
                {
                    Console.SetCursorPosition(y, newX);
                    Console.WriteLine("*");
                    Thread.Sleep(50);
                }
            }
        }

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M1();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
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
        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M1();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

    }
    static void DibujarCuadrados()
    {
        int anchoConsola = 80;
        int altoConsola = 25;
        int espacio = 3;

        Console.Clear();
        DibujarPrimerGrupo(anchoConsola, altoConsola);

        for (int capa = 1; capa <= 3; capa++)
        {
            DibujarRectangulo(capa, anchoConsola, altoConsola, espacio);
        }

        
        int anchoConsol = Console.WindowWidth;
        int altoConsol = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsol - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsol - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M1();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void DibujarPrimerGrupo(int anchoConsola, int altoConsola)
    {
        int centroX = (anchoConsola / 2) + 16;
        int centroY = altoConsola / 2;

        Console.ForegroundColor = ConsoleColor.Green;
        DibujarEn(centroX, centroY);
        DibujarEn(centroX - 1, centroY);
        DibujarEn(centroX + 1, centroY);
    }

    static void DibujarRectangulo(int capa, int anchoConsola, int altoConsola, int espacio)
    {
        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue };
        Console.ForegroundColor = colores[capa % colores.Length];

        int centroX = anchoConsola / 2 + 15;
        int centroY = altoConsola / 2;

        int ancho = (capa * espacio * 4);
        int alto = (capa * espacio * 2);

        int inicioX = centroX - (ancho / 2) + 1;
        int inicioY = centroY - (alto / 2);
        int finX = inicioX + ancho;
        int finY = inicioY + alto;

        for (int x = inicioX; x <= finX; x++) DibujarEn(x, inicioY);
        for (int y = inicioY + 1; y <= finY; y++) DibujarEn(finX, y);
        for (int x = finX - 1; x >= inicioX; x--) DibujarEn(x, finY);
        for (int y = finY - 1; y > inicioY; y--) DibujarEn(inicioX, y);
    }

    static void DibujarEn(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < Console.WindowWidth && y < Console.WindowHeight)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            Thread.Sleep(10);
        }
    }


    // MENÚ 2 ----------------------------------------------------------------------------------------------------------------------------------------------------
    static double Factorial(int n)
    {
        double fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }

    static double Seno(double grados)
    {
        double radianes = grados * (Math.PI / 180);
        double seno = 0;
        for (int i = 0; i < 10; i++)
        {
            seno += (Math.Pow(-1, i) * Math.Pow(radianes, 2 * i + 1)) / Factorial(2 * i + 1);
            System.Threading.Thread.Sleep(5);
        }
        return seno;
    }

    static double Coseno(double grados)
    {
        double radianes = grados * (Math.PI / 180);
        double coseno = 0;
        for (int i = 0; i < 10; i++)
        {
            coseno += (Math.Pow(-1, i) * Math.Pow(radianes, 2 * i)) / Factorial(2 * i);
        }
        return coseno;
    }

    static void MostrarTablaSeno()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nTabla de Senos:");
        Console.ResetColor();

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;

        for (int i = 0; i <= 90; i++)
        {
            int fila = i % 16;
            int col = (i / 16);

            if (fila == 0 && i != 0)
            {
                Console.WriteLine();
            }

            Console.SetCursorPosition(col * 20, fila + 5);
            Console.Write($"Seno({i}) = {Seno(i):F4}");
        }
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M2();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }


    static void MostrarTablaCoseno()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nTabla de Cosenos:");
        Console.ResetColor();

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;

        for (int i = 0; i <= 90; i++)
        {
            int fila = i % 16;
            int col = (i / 16);

            if (fila == 0 && i != 0)
            {
                Console.WriteLine();
            }

            Console.SetCursorPosition(col * 20, fila + 5);
            Console.WriteLine($"Cos({i}) = {Coseno(i):F4}");
        }
        Console.SetCursorPosition( 35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M2();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

    }
    static void Triangulo()
    {
        Console.Write("Cateto A: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Cateto B: ");
        double b = Convert.ToDouble(Console.ReadLine());
        double h = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        double anguloA = Math.Atan(a / b) * (180 / Math.PI);
        double anguloB = Math.Atan(b / a) * (180 / Math.PI);
        Console.WriteLine("\nResultados:");
        Console.WriteLine($"Hipotenusa: {h:F2}");
        Console.WriteLine($"Ángulo opuesto a cateto A: {anguloA:F2}°");
        Console.WriteLine($"Ángulo opuesto a cateto B: {anguloB:F2}°");
        //Dibujar
        Console.WriteLine("\nRepresentación del triángulo:\n");
        for (int i = 0; i <= a; i++)
        {
            for (int j = 0; j <= b; j++)
            {
                if (i == a || j == 0 || j == (int)Math.Round((double)i * b / a))
                    Console.Write("* ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
        }
        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M2();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    static void CalcularDatosRecta()
    {
        Console.Clear();
        Console.Write("Ingrese x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double pendiente = (y2 - y1) / (x2 - x1);
        double angulo = Math.Atan(pendiente) * 180 / Math.PI;
        double xm = (x1 + x2) / 2;
        double ym = (y1 + y2) / 2;

        Console.WriteLine($"Pendiente: {pendiente:F4}");
        Console.WriteLine($"Ángulo de inclinación: {angulo:F4}°");
        Console.WriteLine($"Punto medio: ({xm}, {ym})");
        Console.WriteLine("\nRepresentación de la recta:\n");

        int alto = (int)Math.Max(y1, y2); // Mayor valor de Y para iniciar desde arriba
        int bajo = (int)Math.Min(y1, y2); // Menor valor de Y
        int izquierda = (int)Math.Min(x1, x2); // Menor valor de X
        int derecha = (int)Math.Max(x1, x2); // Mayor valor de X

        for (int y = alto; y >= bajo; y--) // Iterar de arriba hacia abajo
        {
            for (int x = izquierda; x <= derecha; x++)
            {
                if (Math.Abs((y - y1) - pendiente * (x - x1)) < 0.5)
                    Console.Write("* ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
        }

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M2();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void CalcularTrayectoriaProyectil()
    {
        Console.Clear();
        Console.Write("Ingrese la velocidad inicial (m/s): ");
        double v0 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el ángulo de lanzamiento (°): ");
        double angulo = double.Parse(Console.ReadLine());

        double g = 9.81;
        double radianes = angulo * Math.PI / 180;
        double vx = v0 * Math.Cos(radianes);
        double vy = v0 * Math.Sin(radianes);

        double tiempoVuelo = (2 * vy) / g;
        double alturaMaxima = (vy * vy) / (2 * g);
        double distanciaMaxima = vx * tiempoVuelo;

        Console.WriteLine("\nTrayectoria del proyectil:");
        for (double t = 0; t <= tiempoVuelo; t += 0.1)
        {
            double x = vx * t;
            double y = vy * t - 0.5 * g * t * t;
            if (y < 0) break;
            Console.WriteLine($"Tiempo: {t:F2}s - Posición: ({x:F2}, {y:F2})");
        }

        Console.WriteLine($"Altura máxima: {alturaMaxima:F4} m");
        Console.WriteLine($"Distancia máxima: {distanciaMaxima:F4} m");
        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;
        Console.SetCursorPosition(35, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    M2();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
