using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
            return;
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result = result * i;
        }

        Console.WriteLine(n + "! = " + result);
    }
}