# Calculate Factorial

## Quick Answer

> Start `result` at 1, then use a `for` loop from 2 to `n` and multiply `result` by each number. Reject negative numbers first, because factorial is not defined for them.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. If `n` is negative, print a message and stop with `return`.
3. Set `result` to 1. It is a `long` so it can hold big values.
4. Loop `i` from 2 to `n`, and multiply `result` by `i` each time.
5. Print `n` and the result.

Example: `n = 5`
- result starts at 1
- 1 × 2 = 2
- 2 × 3 = 6
- 6 × 4 = 24
- 24 × 5 = 120

Output: `5! = 120`

## 2. Problem Title
Calculate the Factorial of a Number

## 3. Problem Summary
The factorial of `n`, written `n!`, is the product of all whole numbers from 1 to `n`. For example, 5! = 1 × 2 × 3 × 4 × 5 = 120. By definition, 0! = 1.

## 4. Intuition
Think of arranging books on a shelf. With 3 books you have 3 choices for the first spot, 2 for the next and 1 for the last, so there are 3 × 2 × 1 = 6 ways. Factorial counts exactly that kind of arrangement. The loop builds the answer by multiplying one more number on each step, like a snowball getting bigger as it rolls.

## 5. Approaches
One `for` loop that multiplies a running result. (Recursion also works, but the loop is easier to remember and explain.)

## 6. Complexity Analysis
Time is O(n), because the loop runs about n times. Space is O(1).

## 7. Edge Cases
- `0` and `1` both give 1, since the loop does not run and `result` stays 1.
- Negative numbers print a message and the program stops.
- `20` is the biggest factorial that fits in a `long`. Anything above 20 overflows and gives a wrong answer silently.
- `5` gives 120 and `10` gives 3628800.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
            return;
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result = result * i;
        }

        Console.WriteLine(n + "! = " + result);
    }
}
```

## 9. Improvements
- Add a check like `if (n > 20)` with a message, since a `long` cannot hold 21! or more.
- Use `result *= i;` as a shorter form. Both are correct.

## 10. Mistakes
- Starting `result` at 0. Everything multiplied by 0 stays 0, so the answer is always 0.
- Using `int` for `result`, which overflows from 13! onwards.
- Looping from 1 to `n - 1` and missing the last multiplication.
- Forgetting `return` after the negative message, so the program continues.

## 11. Learnings
- A running product starts at 1, and a running sum starts at 0.
- A `for` loop can start at any number, such as 2.
- `long` holds bigger numbers than `int`.
- `return` in `Main` ends the program early.

## FAQ

<details>
<summary>Why does <code>result</code> start at 1 and not 0?</summary>

Anything times 0 is 0, so the product would never grow. 1 is the neutral starting value for multiplication.
</details>

<details>
<summary>Why does the loop start at 2?</summary>

Multiplying by 1 changes nothing, so starting at 2 saves a step. Starting at 1 gives the same answer.
</details>

<details>
<summary>Why <code>long</code> and not <code>int</code>?</summary>

Factorials grow very fast. An `int` overflows at 13!, while a `long` works up to 20!.
</details>

<details>
<summary>What is 0! and how does the code handle it?</summary>

0! is defined as 1. The loop does not run for 0, so `result` stays 1, which is correct.
</details>

<details>
<summary>Why check for negative numbers?</summary>

Factorial is not defined for negative numbers. Without the check, the program would print 1, which is misleading.
</details>