using System;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers? ");
        int n = int.Parse(Console.ReadLine());

        if (n < 2)
        {
            Console.WriteLine("Need at least 2 numbers.");
            return;
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        int largest = arr[n - 1];
        int second = 0;
        bool found = false;

        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] != largest)
            {
                second = arr[i];
                found = true;
                break;
            }
        }

        Console.WriteLine("Largest: " + largest);
        if (found)
        {
            Console.WriteLine("Second largest: " + second);
        }
        else
        {
            Console.WriteLine("No second largest (all numbers are equal).");
        }
    }
}