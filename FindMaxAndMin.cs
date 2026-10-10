using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers? ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1)
        {
            Console.WriteLine("Need at least 1 number.");
            return;
        }

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            list.Add(int.Parse(Console.ReadLine()));
        }

        int max = list[0];
        int min = list[0];

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] > max)
            {
                max = list[i];
            }
            if (list[i] < min)
            {
                min = list[i];
            }
        }

        Console.WriteLine("Max: " + max);
        Console.WriteLine("Min: " + min);
    }
}