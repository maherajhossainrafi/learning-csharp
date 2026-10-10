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

        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int x in arr)
        {
            if (freq.ContainsKey(x))
            {
                freq[x] = freq[x] + 1;
            }
            else
            {
                freq[x] = 1;
            }
        }

        foreach (KeyValuePair<int, int> pair in freq)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}