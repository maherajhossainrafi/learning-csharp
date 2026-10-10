using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int n = int.Parse(Console.ReadLine());

        if ((n % 4 == 0 && n % 100 != 0) || n % 400 == 0)
        {
            Console.WriteLine(n + " is a leap year");
        }
        else
        {
            Console.WriteLine(n + " is not a leap year");
        }
    }
}