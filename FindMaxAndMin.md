# Find Max and Min

## Quick Answer

> Read N numbers into a `List<int>`, start with the first number as both max and min, then loop through the rest and update max or min whenever a bigger or smaller number appears.

## 1. Solution Walkthrough
1. Ask how many numbers there will be and read it into `n`.
2. If `n` is less than 1, print a message and stop with `return`.
3. Create an empty `List<int>` and use a `for` loop to read `n` numbers into it.
4. Set `max` and `min` to the first item, `list[0]`.
5. Loop from index 1 to the end. If an item is bigger than `max`, update `max`. If it is smaller than `min`, update `min`.
6. Print both results.

## 2. Problem Title
Find the Maximum and Minimum of N Numbers

## 3. Problem Summary
The user enters how many numbers they want to give, then types them one by one. The program prints the largest and the smallest of those numbers.

## 4. Intuition
Imagine a line of people and you want to find the tallest and the shortest. You take the first person as both the tallest and the shortest so far. Then you compare each next person: if they are taller than your tallest, they become the new tallest; if shorter than your shortest, they become the new shortest. After checking everyone, you have both answers.

## 5. Approaches
One approach is enough: a single pass through the list, keeping the best max and min seen so far.

## 6. Complexity Analysis
Time is O(n), because each number is checked once. Space is O(n), because the list stores all the numbers.

## 7. Edge Cases
- `n = 1`: the single number is both max and min.
- All numbers equal: max and min are the same.
- Negative numbers: works, because we start from the first item and not from 0.
- `n = 0` or negative: the program stops with a message.

## 8. Implementations
```csharp
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
```

## 9. Improvements
- You could update max and min while reading, which removes the need for a list. Keep the list if your course is teaching collections.
- Use `int.TryParse` to avoid crashes on bad input. This is optional for a first lab.

## 10. Mistakes
- Starting `max` at 0 and `min` at 0. This gives wrong answers for all-negative numbers or all-positive numbers.
- Starting the second loop at `i = 0`. It works, but it is a wasted comparison. Starting at 1 is the cleaner habit.
- Using `else if` for the min check. If the number is a new max, the min check would be skipped. Two separate `if` statements are correct here.
- Forgetting `return` after the invalid message, so the program goes on and crashes at `list[0]`.

## 11. Learnings
- A `List<int>` grows with `Add` and is read with `list[i]`.
- Use `list.Count` for the number of items. Arrays use `.Length`.
- A `for` loop can read input many times.
- Start max and min from the first element, not from 0.
- `return` inside `Main` ends the program early.

## FAQ

<details>
<summary>Why start <code>max</code> and <code>min</code> with <code>list[0]</code>?</summary>

It is a real value from the input, so the comparison is always fair, even for negative numbers.
</details>

<details>
<summary>Why does the second loop start at 1?</summary>

Index 0 is already stored in `max` and `min`, so there is nothing new to compare.
</details>

<details>
<summary>Why <code>List&lt;int&gt;</code> and not an array?</summary>

A list can grow with `Add`, so we do not need to fix the size before reading. An array also works if the size `n` is known first.
</details>

<details>
<summary>Why <code>(i + 1)</code> in the prompt?</summary>

`i` starts at 0, but users expect "number 1", so we add 1 for display.
</details>

<details>
<summary>What does <code>return;</code> do in <code>Main</code>?</summary>

It stops the program immediately, so no code below it runs.
</details>

<details>
<summary>Why <code>using System.Collections.Generic;</code>?</summary>

`List<T>` lives in that namespace, so the program needs it to use a list.
</details>