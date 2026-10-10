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

        Array.Reverse(arr);

        Console.WriteLine("Reversed array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        List<int> list = new List<int>();
        int count = Math.Min(5, n);
        for (int i = 0; i < count; i++)
        {
            list.Add(arr[i]);
        }

        Console.WriteLine("First 5 of the reversed array (List):");
        foreach (int x in list)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}