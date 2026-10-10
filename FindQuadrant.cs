using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter y: ");
        int y = int.Parse(Console.ReadLine());

        if (x == 0 && y == 0)
        {
            Console.WriteLine("Origin");
        }
        else if (x == 0)
        {
            Console.WriteLine("On the Y axis");
        }
        else if (y == 0)
        {
            Console.WriteLine("On the X axis");
        }
        else if (x > 0 && y > 0)
        {
            Console.WriteLine("First Quadrant");
        }
        else if (x < 0 && y > 0)
        {
            Console.WriteLine("Second Quadrant");
        }
        else if (x < 0 && y < 0)
        {
            Console.WriteLine("Third Quadrant");
        }
        else
        {
            Console.WriteLine("Fourth Quadrant");
        }
    }
}