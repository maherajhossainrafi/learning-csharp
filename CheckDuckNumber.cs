using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        bool hasZero = false;
        int temp = n;

        while (temp > 0)
        {
            int digit = temp % 10;
            if (digit == 0)
            {
                hasZero = true;
            }
            temp = temp / 10;
        }

        if (hasZero)
        {
            Console.WriteLine(n + " is a duck number");
        }
        else
        {
            Console.WriteLine(n + " is not a duck number");
        }
    }
}