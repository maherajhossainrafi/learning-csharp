using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int z = int.Parse(Console.ReadLine());

        if (x >= y && x >= z)
        {
            Console.WriteLine(x + " is the largest");
        }
        else if (y >= x && y >= z)
        {
            Console.WriteLine(y + " is the largest");
        }
        else
        {
            Console.WriteLine(z + " is the largest");
        }
    }
}