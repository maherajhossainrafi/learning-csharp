using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers? ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        List<int> unique = new List<int>();

        foreach (int x in arr)
        {
            if (unique.Contains(x) == false)
            {
                unique.Add(x);
            }
        }

        Console.WriteLine("Without duplicates:");
        foreach (int x in unique)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}