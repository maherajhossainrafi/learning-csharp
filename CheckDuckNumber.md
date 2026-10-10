# Check Duck Number

## Quick Answer

> Peel off each digit with `% 10` and `/ 10`. If any digit is 0, set a `bool` flag to true. If the flag is true at the end, it is a duck number.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. Create a flag `hasZero` set to `false`, and copy `n` into `temp`.
3. While `temp > 0`:
   - Take the last digit with `temp % 10`.
   - If the digit is 0, set `hasZero` to `true`.
   - Remove the last digit with `temp / 10`.
4. If `hasZero` is true, print that it is a duck number. Otherwise print that it is not.

Example: `3201`
- digits are 1, 0, 2, 3
- a 0 is found, so `hasZero` becomes true
- it is a duck number

## 2. Problem Title
Check Whether a Number Is a Duck Number

## 3. Problem Summary
A duck number contains at least one zero digit, and the zero must not be the first digit. Examples: 3210, 7056, 100. Non-examples: 123, 0123 (a leading zero does not count).

## 4. Intuition
Think of a security guard checking a line of people for someone wearing a red hat. The guard looks at each person one by one and raises a flag as soon as one red hat appears. At the end, if the flag is up, the answer is yes. Here, the digits are the people, the zero is the red hat, and `hasZero` is the flag.

## 5. Approaches
Peel digits in a `while` loop and use a `bool` flag to remember whether a zero was seen.

## 6. Complexity Analysis
Time is O(d), where d is the number of digits. Space is O(1).

## 7. Edge Cases
- `100` and `3201` have zeros, so they are duck numbers.
- `123` has no zero, so it is not a duck number.
- A number that is just `0`: the loop does not run, so it prints as not a duck number. The 0 is also the first digit, which does not count.
- Leading zeros cannot exist in an `int`, since `0123` is stored as `123`.
- Negative numbers: the loop does not run, so they print as not duck.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        bool hasZero = false;
        int temp = n;

        while (temp > 0)
        {
            int digit = temp % 10;
            if (digit == 0)
            {
                hasZero = true;
            }
            temp = temp / 10;
        }

        if (hasZero)
        {
            Console.WriteLine(n + " is a duck number");
        }
        else
        {
            Console.WriteLine(n + " is not a duck number");
        }
    }
}
```

## 9. Improvements
- Add `break;` right after `hasZero = true;` to stop the loop early. This saves work but is not required.
- Use `n.ToString().Contains("0")` for a one-line version. The loop teaches `%` and `/`, so keep it for the lab.

## 10. Mistakes
- Setting `hasZero = false` inside the loop, which erases a zero found earlier. Set it to false once, before the loop.
- Changing `n` instead of `temp`, so the original number cannot be printed.
- Forgetting `temp = temp / 10`, which makes an infinite loop.
- Writing `digit = 0` instead of `digit == 0`. `=` assigns and `==` compares.

## 11. Learnings
- A `bool` flag remembers whether something happened during a loop.
- `% 10` gets the last digit and `/ 10` removes it.
- Set a flag to false before the loop and only change it to true inside.
- `==` compares values, while `=` assigns.

## FAQ

<details>
<summary>What is the <code>hasZero</code> variable for?</summary>

It remembers whether a zero digit was seen. It starts as `false` and becomes `true` when a zero is found.
</details>

<details>
<summary>Why not print the result inside the loop?</summary>

We have to look at every digit before we can say there is no zero. The final answer is only known after the loop ends.
</details>

<details>
<summary>Why do we need <code>temp</code>?</summary>

The loop reduces the number to 0. A copy keeps `n` unchanged so we can print it at the end.
</details>

<details>
<summary>Why does the loop need <code>temp &gt; 0</code>?</summary>

When every digit has been removed, `temp` is 0 and the loop stops.
</details>

<details>
<summary>Is a number like 0123 a duck number?</summary>

No. The leading zero does not count, and an `int` cannot store it anyway.
</details>