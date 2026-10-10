using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n;
        int rev = 0;
        while (temp > 0)
        {
            int digit = temp % 10;
            rev = rev * 10 + digit;
            temp = temp / 10;
        }

        if (rev == n)
        {
            Console.WriteLine(n + " is a palindrome");
        }
        else
        {
            Console.WriteLine(n + " is not a palindrome");
        }
    }
}