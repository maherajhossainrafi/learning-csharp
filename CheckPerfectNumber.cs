using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                sum = sum + i;
            }
        }

        if (sum == n && n > 0)
        {
            Console.WriteLine(n + " is a perfect number");
        }
        else
        {
            Console.WriteLine(n + " is not a perfect number");
        }
    }
}