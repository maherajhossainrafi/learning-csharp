using System;

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

        Console.Write("Enter the element to search: ");
        int key = int.Parse(Console.ReadLine());
        bool found = false;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == key)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            Console.WriteLine("Element is found");
        }
        else
        {
            Console.WriteLine("Element is not found");
        }
    }
}