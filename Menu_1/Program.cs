internal class Program
{
    private static void Main(string[] args)
    {
        int x = 25;
        int y = 115;
        int c = 0;
        for (int i = 0; i < 115; i++)
        {
            Console.SetCursorPosition(y, x);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*");
            c++;
            if (c == 7)
            {
                x--;
                c= 0;
                for (int a = 0; a < 5; a++)
                {
                    Console.SetCursorPosition(y, x);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    y--;
                }
            }
          

        }
        Console.ReadKey();
    }
}