using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        int product = 1;
        int temp = n;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum = sum + digit;
            product = product * digit;
            temp = temp / 10;
        }

        if (sum == product)
        {
            Console.WriteLine(n + " is a spy number");
        }
        else
        {
            Console.WriteLine(n + " is not a spy number");
        }
    }
}