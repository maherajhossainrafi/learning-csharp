using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int digits = 0;
        int temp = n;
        while (temp > 0)
        {
            digits++;
            temp = temp / 10;
        }

        int sum = 0;
        temp = n;
        while (temp > 0)
        {
            int digit = temp % 10;
            sum = sum + (int)Math.Pow(digit, digits);
            temp = temp / 10;
        }

        if (sum == n)
        {
            Console.WriteLine(n + " is an Armstrong number");
        }
        else
        {
            Console.WriteLine(n + " is not an Armstrong number");
        }
    }
}