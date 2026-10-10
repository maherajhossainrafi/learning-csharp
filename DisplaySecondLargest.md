# Display Second Largest

## Quick Answer

> Sort the array so the largest number is last, then walk backwards from the second-last item until you find a number different from the largest. Display it if one exists.

## 1. Solution Walkthrough
1. Read `n`. If it is less than 2, print a message and stop.
2. Fill an array with `n` numbers.
3. Sort the array with `Array.Sort`, smallest to largest.
4. The last item, `arr[n - 1]`, is the largest.
5. Start from `n - 2` and move left. The first item that is not equal to `largest` is the second largest.
6. `found` remembers whether such a number exists, and `break` stops the loop once it is found.
7. If `found` is true, print the second largest. Otherwise print that none exists.

Example: input `5 9 9 3`
- sorted: `3 5 9 9`
- largest is 9
- walking back, 9 is skipped and 5 is the answer

Output: `5 is the second largest`

## 2. Problem Title
Display the Second Largest Number in an Array

## 3. Problem Summary
Take an integer array from the user and display the second largest distinct value, if there is one. When all numbers are equal, there is no second largest.

## 4. Intuition
Think of a race where finishers are lined up by time. The winner is at the front. The runner-up is the next person, but if that person tied with the winner, they are not second, they are also first. So you keep going until you reach someone with a different time. Sorting lines up the finishers, and the backward loop finds the first different one.

## 5. Approaches
Sort, then scan backwards for the first value different from the largest.

## 6. Complexity Analysis
Time is O(n log n), because sorting is the slowest step. Space is O(1) extra.

## 7. Edge Cases
- Duplicates of the largest (`5 9 9`): the answer is 5, not 9.
- All numbers equal (`4 4 4`): there is no second largest.
- `n = 2` with different numbers: the smaller one is the answer.
- `n < 2`: the program stops with a message, which avoids a crash at `arr[n - 1]`.
- Negative numbers work, because the answer comes from the sorted array and not from a starting value of 0.

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
        int secondLargest = 0;
        bool found = false;

        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] != largest)
            {
                secondLargest = arr[i];
                found = true;
                break;
            }
        }

        if (found)
        {
            Console.WriteLine(secondLargest + " is the second largest");
        }
        else
        {
            Console.WriteLine("No second largest (all numbers are equal).");
        }
    }
}
```

## 9. Improvements
- A single loop that tracks the largest and second largest without sorting is faster, O(n). Sorting is simpler to explain, so keep it for the lab.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Using `arr[n - 2]` as the answer. With duplicates like `9 9`, this gives the wrong result.
- Forgetting the `n < 2` check, which crashes with an `IndexOutOfRangeException` for an empty array.
- Printing nothing when `found` is false, so the user sees no output at all.
- Forgetting `break`, so the loop continues and `secondLargest` is overwritten by smaller numbers.

## 11. Learnings
- `Array.Sort(arr)` sorts the array in place from smallest to largest.
- After sorting, the largest item is at index `n - 1`.
- A loop can run backwards with `i--`.
- A `bool` flag records whether something was found.
- Always guard against input that is too small before reading `arr[n - 1]`.

## FAQ

<details>
<summary>Why not just use <code>arr[n - 2]</code>?</summary>

If the largest number appears twice, `arr[n - 2]` equals the largest, so it is not a real second largest.
</details>

<details>
<summary>What is the <code>found</code> variable for?</summary>

It tells us whether a different number was found. Without it, we could not tell "second largest is 0" apart from "there is no second largest".
</details>

<details>
<summary>Why check <code>n &lt; 2</code> first?</summary>

A second largest needs at least two numbers, and reading `arr[n - 1]` on an empty array would crash.
</details>

<details>
<summary>What does <code>break</code> do?</summary>

It exits the loop at once, because the answer has been found.
</details>

<details>
<summary>How is this different from the Find Second Largest problem?</summary>

That one prints both the largest and the second largest. This one prints only the second largest.
</details>