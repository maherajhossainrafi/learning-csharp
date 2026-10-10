# Find Second Largest

## Quick Answer

> Sort the array so the largest number is last, then walk backwards from the second-last item until you find a number that is different from the largest. That number is the second largest.

## 1. Solution Walkthrough
1. Read `n`. If it is less than 2, print a message and stop.
2. Fill an array with `n` numbers.
3. Sort the array with `Array.Sort`, smallest to largest.
4. The last item, `arr[n - 1]`, is the largest.
5. Start from `n - 2` and move left. The first item that is not equal to `largest` is the second largest.
6. Use `found` to remember whether such a number exists, and `break` to stop the loop once it is found.
7. Print the largest, and print the second largest only if `found` is true.

Example: input `5 9 9 3` sorts to `3 5 9 9`. Largest is 9. Walking back, 9 is skipped and 5 is the answer.

## 2. Problem Title
Find the Largest and Second Largest Number

## 3. Problem Summary
Read N numbers and print the largest and the second largest distinct number. If all numbers are equal, there is no second largest.

## 4. Intuition
Think of a race where the finishers are lined up by time. The winner is at the front. To find the runner-up, you look at the next person, but if that person tied with the winner, they are not second, they are also first. So you keep going until you reach someone who finished at a different time. Sorting lines up the finishers, and the backward loop finds the first different one.

## 5. Approaches
Sort, then scan backwards for the first value different from the largest.

## 6. Complexity Analysis
Time is O(n log n), because sorting is the slowest step. Space is O(n) for the array.

## 7. Edge Cases
- Duplicates of the largest (`5 9 9`): the answer is 5, not 9.
- All numbers equal (`4 4 4`): no second largest exists.
- `n = 2` with different numbers: the smaller one is the second largest.
- Negative numbers work, since we use the sorted values and not 0.
- `n < 2`: the program stops with a message.

## 8. Implementations
```csharp
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
```

## 9. Improvements
- A single loop that tracks `largest` and `second` without sorting is faster, O(n). Sorting is simpler to explain, so keep it for the lab.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Using `arr[n - 2]` as the answer. With duplicates like `9 9`, this gives the wrong result.
- Forgetting the `found` flag, so a stale `second = 0` is printed when all numbers are equal.
- Forgetting `break`, so the loop keeps going and `second` is overwritten by smaller numbers.
- Starting the loop at `n - 1` instead of `n - 2`, which compares the largest with itself.

## 11. Learnings
- `Array.Sort(arr)` sorts the array in place from smallest to largest.
- After sorting, the largest item is at index `n - 1`.
- A loop can run backwards with `i--`.
- A `bool` flag records whether something was found.
- `break` exits a loop early.

## FAQ

<details>
<summary>Why not just use <code>arr[n - 2]</code>?</summary>

If the largest number appears twice, `arr[n - 2]` is the same as the largest, so it is not a real second largest.
</details>

<details>
<summary>What is the <code>found</code> variable for?</summary>

It tells us whether a different number was found. Without it, we could not tell the difference between "second largest is 0" and "there is no second largest".
</details>

<details>
<summary>Why <code>int second = 0;</code>?</summary>

C# needs a variable to have a value before it is used. The value 0 is never printed unless `found` is true.
</details>

<details>
<summary>What does <code>break</code> do?</summary>

It exits the loop at once, because we have already found the answer.
</details>

<details>
<summary>Why check <code>n &lt; 2</code> at the start?</summary>

A second largest needs at least two numbers.
</details>