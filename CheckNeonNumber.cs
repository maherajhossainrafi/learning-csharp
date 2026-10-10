using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        long square = (long)n * n;
        long temp = square;
        long sum = 0;

        while (temp > 0)
        {
            long digit = temp % 10;
            sum = sum + digit;
            temp = temp / 10;
        }

        if (sum == n)
        {
            Console.WriteLine(n + " is a neon number");
        }
        else
        {
            Console.WriteLine(n + " is not a neon number");
        }
    }
}