using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        //Nili Estefanía López Gutierrez 
        MP();
    }

    //MENÚ PRINCIPAL
    static void MP()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 2);
            Console.Write("=====  Localización de vectores y matrices  =====");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 4);
            Console.Write("1. Juego del ahorcado para cualquier palabra.");
            Console.SetCursorPosition(25, 5);
            Console.Write("2. Matriz: contar positivos, negativos y ceros.");
            Console.SetCursorPosition(25, 6);
            Console.Write("3. Matriz: transposición.");
            Console.SetCursorPosition(25, 7);
            Console.Write("4. Matriz: mayor y menor con posición.");
            Console.SetCursorPosition(25, 8);
            Console.Write("5. Matriz: pares, impares, promedios.");
            Console.SetCursorPosition(25, 9);
            Console.Write("6. Matriz 3x3: suma por filas y columnas.");
            Console.SetCursorPosition(25, 10);
            Console.Write("7. Multiplicación de 2 matrices.");
            Console.SetCursorPosition(25, 11);
            Console.Write("8. Desviación estándar.");
            Console.SetCursorPosition(25, 12);
            Console.Write("9. Salir.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 14);
            Console.Write("Selecciona una opción (1-9): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 9)
            {
                Console.SetCursorPosition(25, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                switch (opcion)
                {
                    case 1: Console.Clear(); M1(); break;
                    case 2: Console.Clear(); M2(); break;
                    case 3: Console.Clear(); M3(); break;
                    case 4: Console.Clear(); M4(); break;
                    case 5: Console.Clear(); M5(); break;
                    case 6: Console.Clear(); M6(); break;
                    case 7: Console.Clear(); M7(); break;
                    case 8: Console.Clear(); M8(); break;
                        Console.Clear();
                        Console.SetCursorPosition(25, 16);
                        Console.Write("Programa aún no implementado. Presiona una tecla...");
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        Console.SetCursorPosition(25, 16);
                        Console.Write("Saliendo...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }

        } while (true);
    }
    
    //P1
    static void M1()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 2);
            Console.Write("=== JUEGO DEL AHORCADO ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con el juego");

            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");

            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
            }
            else
            {
                switch (opcion)
                {
                    case 1:
                        JugarAhorcado();
                        break;
                    case 2:
                        return;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(25, 12);
                        Console.Write("Saliendo del programa...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }

        } while (true);
    }
    static void JugarAhorcado()
    {
        string palabra;
        bool entradaValida;

        do
        {
            Console.Clear();
            opcionesSalir("");

            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Introduce la palabra a adivinar (se ocultará): ");
            palabra = Console.ReadLine();

            if (opcionesSalir(palabra)) return;

            entradaValida = !string.IsNullOrWhiteSpace(palabra) &&
                        palabra.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

            if (!entradaValida)
            {
                Console.SetCursorPosition(25, 4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Solo se permiten letras. Preciona cualquier tecla e intenta de nuevo.");
                Console.ReadKey();
            }
        } while (!entradaValida);

        palabra = palabra.ToUpper();
        Console.Clear();

        char[] letras = new string('_', palabra.Length).ToCharArray();
        List<char> intentos = new List<char>();
        int vidas = 6;
        bool terminado = false;

        while (vidas > 0 && !terminado)
        {
            Console.Clear();
            opcionesSalir("");

            Console.SetCursorPosition(25, 2);
            Console.Write("Palabra: " + string.Join(" ", letras));

            Console.SetCursorPosition(25, 4);
            Console.Write("Intentos: " + string.Join(", ", intentos));

            Console.SetCursorPosition(25, 6);
            Console.Write($"Vidas restantes: {vidas}");

            Console.SetCursorPosition(25, 8);
            Console.Write("Introduce una letra: ");
            string input = Console.ReadLine();

            if (opcionesSalir(input)) return;

            if (!char.TryParse(input.ToUpper(), out char letra) || !char.IsLetter(letra))
            {
                Console.SetCursorPosition(25, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada inválida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            if (intentos.Contains(letra))
            {
                Console.SetCursorPosition(25, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ya intentaste esa letra. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            intentos.Add(letra);
            if (palabra.Contains(letra))
            {
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] == letra)
                        letras[i] = letra;
                }
            }
            else
            {
                vidas--;
            }

            if (!letras.Contains('_'))
                terminado = true;
        }

        Console.Clear();
        opcionesSalir("");

        Console.SetCursorPosition(25, 12);
        if (vidas > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¡Felicidades! Adivinaste la palabra: " + palabra);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Perdiste. La palabra era: " + palabra);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, 14);
        Console.Write("Presiona una tecla para volver al menú...");
        Console.ReadKey();
    }
    
    //P2
    static void M2()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MATRIZ: CONTAR POSITIVOS, NEGATIVOS Y CEROS ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con operación de matrices");

            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");

            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    OperarMatrices(); // Llamamos a la función que maneja las matrices
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().CloseMainWindow();
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 1);
    }
    static void OperarMatrices()
    {
        int m, n;
        const int maxFilas = 10, maxColumnas = 8;

        Console.Clear();
        Console.SetCursorPosition(25, 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("=== OPERACIONES CON MATRICES ===");

        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4);
            Console.Write($"Introduce el número de filas: ");
            string inputM = Console.ReadLine();

            Console.SetCursorPosition(25, 5);
            Console.Write($"Introduce el número de columnas: ");
            string inputN = Console.ReadLine();

            if (int.TryParse(inputM, out m) && int.TryParse(inputN, out n) &&
                m > 0 && n > 0 && m <= maxFilas && n <= maxColumnas)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensiones inválidas. Presiona una tecla para intentar de nuevo...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== OPERACIONES CON MATRICES ===");
        } while (true);

        int[,] matriz = new int[m, n];
        int positivos = 0, negativos = 0, ceros = 0;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(35, 4);
        for (int j = 1; j <= n; j++)
            Console.Write($"Col {j}".PadLeft(8));

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i + 1}:");

            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[     ]");
                    Console.SetCursorPosition(35 + j * 8 + 1, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 6 + m);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 6 + m);
                        Console.Write(new string(' ', 60));
                    }
                } while (!valido);

                matriz[i, j] = valor;

                if (valor > 0) positivos++;
                else if (valor < 0) negativos++;
                else ceros++;

                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write("[");
                if (valor == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(valor.ToString().PadLeft(5));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(valor.ToString().PadLeft(5));
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");
            }
        }

        int resultadoY = 7 + m;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(25, resultadoY);
        Console.Write($"Total de positivos: {positivos}");

        Console.SetCursorPosition(25, resultadoY + 1);
        Console.Write($"Total de negativos: {negativos}");

        Console.SetCursorPosition(25, resultadoY + 2);
        Console.Write($"Total de ceros: {ceros}");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(25, resultadoY + 4);
        Console.Write("1. Volver al menú de matrices    2. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, resultadoY + 6);
        Console.Write("Selecciona una opción: ");

        string op = Console.ReadLine();
        if (op == "1") M2();
        else if (op == "2")
        {
            Console.Clear();
            Console.SetCursorPosition(25, resultadoY + 8);
            Console.Write("Saliendo del programa...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }

    //P3
    static void M3()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 2);
            Console.Write("=== MATRIZ: TRANSPOSICIÓN ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con operación de matrices");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TransponerMatriz();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().CloseMainWindow();
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 1);
    }
    static void TransponerMatriz()
    {
        int m, n;
        const int maxFilas = 6;
        const int maxColumnas = 6;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== TRANSPOSICIÓN DE MATRIZ ===");

        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4);
            Console.Write($"Introduce número de filas: ");
            string inputM = Console.ReadLine();

            Console.SetCursorPosition(25, 5);
            Console.Write($"Introduce número de columnas: ");
            string inputN = Console.ReadLine();

            if (int.TryParse(inputM, out m) && int.TryParse(inputN, out n) &&
                m > 0 && m <= maxFilas && n > 0 && n <= maxColumnas)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensiones inválidas. Presiona una tecla para intentar de nuevo...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 2);
            Console.Write("=== TRANSPOSICIÓN DE MATRIZ ===");
        } while (true);

        int[,] matriz = new int[m, n];
        int[,] transpuesta = new int[n, m];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== INGRESO DE MATRIZ ===");

        for (int j = 0; j < n; j++)
        {
            Console.SetCursorPosition(35 + j * 8, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Col {j}");
        }

        int filaInicioTranspuesta = 6 + m + 2;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, filaInicioTranspuesta - 2);
        Console.Write("=== MATRIZ TRANSPUESTA ===");

        for (int j = 0; j < m; j++)
        {
            Console.SetCursorPosition(35 + j * 8, filaInicioTranspuesta);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Col {j}");
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i}");

            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(36 + j * 8, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 6 + m + 15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 6 + m + 1);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matriz[i, j] = valor;
                transpuesta[j, i] = valor;

                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"[{valor.ToString().PadLeft(5)}]");

                Console.SetCursorPosition(25, filaInicioTranspuesta + 1 + j);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Fila {j}");

                Console.SetCursorPosition(35 + i * 8, filaInicioTranspuesta + 1 + j);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"[{transpuesta[j, i].ToString().PadLeft(5)}]");
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(25, filaInicioTranspuesta + 3 + n);
        Console.Write("1. Volver al menú de matrices    2. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, filaInicioTranspuesta + 4 + n);
        Console.Write("Selecciona una opción: ");

        string op = Console.ReadLine();
        if (op == "1") M3();
        else if (op == "2")
        {
            Console.Clear();
            Console.SetCursorPosition(25, filaInicioTranspuesta + 6 + n);
            Console.Write("Saliendo del programa...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }

    //P4
    static void M4()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MATRIZ: MAYOR Y MENOR CON POSICIÓN ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con operación de matrices");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    EncontrarMayorMenor();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().CloseMainWindow();
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 1);
    }
    static void EncontrarMayorMenor()
    {
        int m, n;
        const int maxFilas = 10, maxColumnas = 9;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== ENCONTRAR MAYOR Y MENOR EN MATRIZ ===");

        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4);
            Console.Write("Introduce el número de filas (m): ");
            string inputM = Console.ReadLine();

            Console.SetCursorPosition(25, 5);
            Console.Write("Introduce el número de columnas (n): ");
            string inputN = Console.ReadLine();

            if (int.TryParse(inputM, out m) && int.TryParse(inputN, out n) && m > 0 && m <= maxFilas && n > 0 && n <= maxColumnas)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensiones inválidas. Presiona una tecla para intentar de nuevo...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== ENCONTRAR MAYOR Y MENOR EN MATRIZ ===");
        } while (true);

        int[,] matriz = new int[m, n];
        int mayor = int.MinValue, menor = int.MaxValue;
        (int filaMayor, int colMayor) = (0, 0);
        (int filaMenor, int colMenor) = (0, 0);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ ===");

        for (int j = 0; j < n; j++)
        {
            Console.SetCursorPosition(35 + j * 8, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Col {j}");
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i}");

            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(36 + j * 8, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 7 + m);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 7 + m);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matriz[i, j] = valor;
                if (valor > mayor) (mayor, filaMayor, colMayor) = (valor, i, j);
                if (valor < menor) (menor, filaMenor, colMenor) = (valor, i, j);

                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write($"[{valor.ToString().PadLeft(5)}]");
            }
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ CON MAYOR Y MENOR DESTACADOS ===");

        for (int j = 0; j < n; j++)
        {
            Console.SetCursorPosition(35 + j * 8, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Col {j}");
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i}");

            for (int j = 0; j < n; j++)
            {
                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write("[");

                if (i == filaMayor && j == colMayor)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (i == filaMenor && j == colMenor)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(matriz[i, j].ToString().PadLeft(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");
            }
        }

        int resultadoY = 6 + m;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.SetCursorPosition(25, resultadoY);
        Console.Write($"Mayor valor: {mayor} en Fila {filaMayor}, Columna {colMayor}");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.SetCursorPosition(25, resultadoY + 1);
        Console.Write($"Menor valor: {menor} en Fila {filaMenor}, Columna {colMenor}");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(25, resultadoY + 3);
        Console.Write("1. Volver al menú de matrices    2. Salir");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, resultadoY + 4);
        Console.Write("Selecciona una opción: ");

        string op = Console.ReadLine();
        if (op == "1") M4();
        else if (op == "2")
        {
            Console.Clear();
            Console.SetCursorPosition(25, resultadoY + 6);
            Console.Write("Saliendo del programa...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }

    //P5
    static void M5()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MATRIZ: PARES, IMPARES Y PROMEDIOS ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con operación de matrices");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AnalizarParesImpares();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 2);
    }
    static void AnalizarParesImpares()
    {
        int m, n;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== ANÁLISIS DE PARES E IMPARES EN MATRIZ ===");

        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4);
            Console.Write("Introduce el número de filas: ");
            string inputM = Console.ReadLine();

            Console.SetCursorPosition(25, 5);
            Console.Write("Introduce el número de columnas: ");
            string inputN = Console.ReadLine();

            if (int.TryParse(inputM, out m) && int.TryParse(inputN, out n) &&
                m > 0 && m <= 9 && n > 0 && n <= 9)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensiones inválidas. Presiona una tecla para intentar de nuevo...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== ANÁLISIS DE PARES E IMPARES EN MATRIZ ===");
        } while (true);

        int[,] matriz = new int[m, n];
        int sumaPares = 0, sumaImpares = 0;
        int cantidadPares = 0, cantidadImpares = 0;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(35, 4);
        for (int j = 0; j < n; j++)
        {
            Console.Write($"Col {j}".PadLeft(8));
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i}:");

            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(35 + j * 8 + 1, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 7 + m);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 7 + m);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matriz[i, j] = valor;

                if (valor % 2 == 0)
                {
                    sumaPares += valor;
                    cantidadPares++;
                }
                else
                {
                    sumaImpares += valor;
                    cantidadImpares++;
                }

                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write("[");

                Console.ForegroundColor = valor % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.Write(valor.ToString().PadLeft(5));

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");
            }
        }

        double promedioPares = cantidadPares > 0 ? (double)sumaPares / cantidadPares : 0;
        double promedioImpares = cantidadImpares > 0 ? (double)sumaImpares / cantidadImpares : 0;

        int resultadoY = 7 + m;

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(25, resultadoY);
        Console.Write($"Suma de pares: {sumaPares}");
        Console.SetCursorPosition(25, resultadoY + 1);
        Console.Write($"Cantidad de pares: {cantidadPares}");
        Console.SetCursorPosition(25, resultadoY + 2);
        Console.Write($"Promedio de pares: {promedioPares:F2}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(25, resultadoY + 4);
        Console.Write($"Suma de impares: {sumaImpares}");
        Console.SetCursorPosition(25, resultadoY + 5);
        Console.Write($"Cantidad de impares: {cantidadImpares}");
        Console.SetCursorPosition(25, resultadoY + 6);
        Console.Write($"Promedio de impares: {promedioImpares:F2}");

        MostrarMenuFinal(resultadoY + 8);
    }

    //P6
    static void M6()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MATRIZ 3x3: SUMA POR FILAS Y COLUMNAS ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Continuar con operación de matrices");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú principal");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    SumarFilasColumnas();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 2);
    }
    static void SumarFilasColumnas()
    {
        int m = 3, n = 3;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== SUMA POR FILAS Y COLUMNAS ===");

        int[,] matriz = new int[m, n];
        int[] sumaFilas = new int[m];
        int[] sumaColumnas = new int[n];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== INGRESO DE DATOS ===");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(35, 4);
        for (int j = 0; j < n; j++)
        {
            Console.Write($"Col {j}".PadLeft(8));
        }
        Console.Write(" Suma".PadLeft(10));

        for (int i = 0; i < m; i++)
        {
            sumaFilas[i] = 0;

            Console.SetCursorPosition(25, 5 + i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Fila {i}:");

            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(35 + j * 8 + 1, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 7 + m);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 7 + m);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matriz[i, j] = valor;
                sumaFilas[i] += valor;
                sumaColumnas[j] += valor;
            }

            Console.SetCursorPosition(35 + n * 8, 5 + i);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{sumaFilas[i]}".PadLeft(10));
        }

        Console.SetCursorPosition(25, 6 + m);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Suma:");

        for (int j = 0; j < n; j++)
        {
            Console.SetCursorPosition(35 + j * 8, 6 + m);
            Console.Write($"{sumaColumnas[j]}".PadLeft(8));
        }

        MostrarMenuFinal(8 + m);
    }

    //P7
    static void M7()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MULTIPLICACIÓN DE MATRICES ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Realizar multiplicación de matrices");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    MultiplicarMatrices();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().CloseMainWindow();
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 1);
    }
    static void MultiplicarMatrices()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MULTIPLICACIÓN DE MATRICES A[m×n] × B[n×p] ===");

        // Dimensiones de la matriz A
        int m, n;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4);
            Console.Write("Introduce filas de A (m): ");
            string inputM = Console.ReadLine();

            Console.SetCursorPosition(25, 5);
            Console.Write("Introduce columnas de A (n): ");
            string inputN = Console.ReadLine();

            if (int.TryParse(inputM, out m) && int.TryParse(inputN, out n) && m > 0 && n > 0 && m <= 9 && n <= 7)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensiones inválidas. Presiona una tecla...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== MULTIPLICACIÓN DE MATRICES A[m×n] × B[n×p] ===");
        } while (true);

        int p;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 7);
            Console.Write($"Introduce columnas de B (p) [debe ser matriz {n}×p]: ");
            string inputP = Console.ReadLine();

            if (int.TryParse(inputP, out p) && p > 0 && p <= 7)
                break;

            Console.SetCursorPosition(25, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Dimensión inválida. Presiona una tecla...");
            Console.ReadKey();
            Console.SetCursorPosition(25, 7);
            Console.Write(new string(' ', 60));
        } while (true);

        int[,] matrizA = new int[m, n];
        int[,] matrizB = new int[n, p];
        int[,] resultado = new int[m, p];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ A ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(35, 4);
        for (int j = 0; j < n; j++)
        {
            Console.Write($"Col {j}".PadLeft(8));
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.Write($"Fila {i}:");
            for (int j = 0; j < n; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(35 + j * 8 + 1, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 7 + m);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 7 + m);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matrizA[i, j] = valor;
                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write($"[{valor.ToString().PadLeft(5)}]");
            }
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== MATRIZ B ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(35, 4);
        for (int j = 0; j < p; j++)
        {
            Console.Write($"Col {j}".PadLeft(8));
        }

        for (int i = 0; i < n; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.Write($"Fila {i}:");
            for (int j = 0; j < p; j++)
            {
                int valor;
                bool valido;
                do
                {
                    Console.SetCursorPosition(35 + j * 8, 5 + i);
                    Console.Write("[     ]");
                    Console.SetCursorPosition(35 + j * 8 + 1, 5 + i);

                    string input = Console.ReadLine();
                    valido = int.TryParse(input, out valor);

                    if (!valido)
                    {
                        Console.SetCursorPosition(25, 7 + n);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Entrada inválida. Presiona una tecla...");
                        Console.ReadKey();
                        Console.SetCursorPosition(25, 7 + n);
                        Console.Write(new string(' ', 60));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!valido);

                matrizB[i, j] = valor;
                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write($"[{valor.ToString().PadLeft(5)}]");
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
            {
                int suma = 0;
                for (int k = 0; k < n; k++)
                {
                    suma += matrizA[i, k] * matrizB[k, j];
                }
                resultado[i, j] = suma;
            }
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== RESULTADO DE A × B ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(35, 4);
        for (int j = 0; j < p; j++)
        {
            Console.Write($"Col {j}".PadLeft(8));
        }

        for (int i = 0; i < m; i++)
        {
            Console.SetCursorPosition(25, 5 + i);
            Console.Write($"Fila {i}:");
            for (int j = 0; j < p; j++)
            {
                Console.SetCursorPosition(35 + j * 8, 5 + i);
                Console.Write($"[{resultado[i, j].ToString().PadLeft(5)}]");
            }
        }

        MostrarMenuFinal(7 + m);
    }

    //P8
    static void M8()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== CÁLCULO DE DESVIACIÓN ESTÁNDAR MUESTRAL ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 5);
            Console.Write("1. Calcular desviación estándar muestral");
            Console.SetCursorPosition(25, 6);
            Console.Write("2. Menú anterior");
            Console.SetCursorPosition(25, 7);
            Console.Write("3. Salir");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("Selecciona una opción (1-3): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion) || opcion < 1 || opcion > 3)
            {
                Console.SetCursorPosition(25, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Opción no válida. Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    CalcularDesviacionEstandar();
                    break;
                case 2:
                    return;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(25, 12);
                    Console.Write("Saliendo del programa...");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().CloseMainWindow();
                    Environment.Exit(0);
                    break;
            }
        } while (opcion != 1);
    }

    static void CalcularDesviacionEstandar()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== DESVIACIÓN ESTÁNDAR ===");
        Console.SetCursorPosition(25, 3);
        Console.Write("Fórmula: √[Σ(xi - x̄)²/(n-1)]");

        int n;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 5);
            Console.Write("Introduce la cantidad de datos (n >= 2): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out n) && n >= 2)
                break;

            Console.SetCursorPosition(25, 7);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Debe ser un número entero mayor o igual a 2. Presiona una tecla...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(25, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== DESVIACIÓN ESTÁNDAR MUESTRAL ===");
            Console.SetCursorPosition(25, 3);
            Console.Write("Fórmula: √[Σ(xi - x̄)²/(n-1)]");
        } while (true);

        double[] datos = new double[n];
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== INGRESO DE DATOS ===");

        for (int i = 0; i < n; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 4 + i);
            Console.Write($"Dato {i + 1} (x_{i + 1}): ");

            bool valido;
            do
            {
                Console.SetCursorPosition(40, 4 + i);
                Console.Write(new string(' ', 15));
                Console.SetCursorPosition(40, 4 + i);

                string input = Console.ReadLine();
                valido = double.TryParse(input, out datos[i]);

                if (!valido)
                {
                    Console.SetCursorPosition(25, 6 + n);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida. Debe ser un número. Presiona una tecla...");
                    Console.ReadKey();
                    Console.SetCursorPosition(25, 6 + n);
                    Console.Write(new string(' ', 60));
                }
            } while (!valido);
        }

        //x̄
        double suma = 0;
        foreach (double dato in datos)
        {
            suma += dato;
        }
        double media = suma / n;

        //Σ(xi - x̄)²
        double sumaCuadrados = 0;
        foreach (double dato in datos)
        {
            sumaCuadrados += Math.Pow(dato - media, 2);
        }
        //resultado
        double desviacion = Math.Sqrt(sumaCuadrados / (n - 1));

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(25, 2);
        Console.Write("=== RESULTADOS ===");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(25, 4);
        Console.Write($"Media (x̄): {media:F4}");

        Console.SetCursorPosition(25, 5);
        Console.Write($"Suma de cuadrados de diferencias: {sumaCuadrados:F4}");

        Console.SetCursorPosition(25, 7);
        Console.Write($"Desviación estándar muestral (s): {desviacion:F4}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, 9);
        Console.Write($"Fórmula aplicada: √({sumaCuadrados:F4} / {n - 1}) = {desviacion:F4}");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(25, 11);
        Console.Write("Datos ingresados:");

        for (int i = 0; i < n; i++)
        {
            Console.SetCursorPosition(25, 13 + i);
            Console.Write($"x_{i + 1} = {datos[i]}");
        }

        MostrarMenuFinal(15 + n);
    }

    //GENERALES PARA TODAS LAS PANTALLAS
    static ConsoleColor GetColorForValue(int value)
    {
        return value switch
        {
            > 0 => ConsoleColor.Green,
            < 0 => ConsoleColor.Red,
            0 => ConsoleColor.Yellow,
        };
    }
    static void MostrarMenuFinal(int yPosition)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(25, yPosition);
        Console.Write("1. Menú anterior    2. Salir");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(25, yPosition + 2);
        Console.Write("Selecciona una opción: ");

        string op = Console.ReadLine();
        if (op == "1") return;
        else if (op == "2")
        {
            Console.Clear();
            Console.SetCursorPosition(25, yPosition + 4);
            Console.Write("Saliendo del programa...");
            Thread.Sleep(1000);
            Process.GetCurrentProcess().CloseMainWindow();
            Environment.Exit(0);
        }
    }
    static bool opcionesSalir(string input)
    {
        Console.SetCursorPosition(25, 28);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("1. Menú anterior    2. Salir");
        Console.ForegroundColor = ConsoleColor.White;

        if (input == "1")
        {
            return true;
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.SetCursorPosition(25, 22);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Saliendo del programa...");
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        return false;
    }
}