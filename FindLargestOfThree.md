# Find Largest of Three

## Quick Answer

> Check whether the first number is at least as big as both others. If not, check the second the same way. If neither is the largest, the third must be.

## 1. Solution Walkthrough
1. Read three numbers into `x`, `y` and `z`.
2. If `x >= y` and `x >= z`, then `x` is the largest.
3. Otherwise, if `y >= x` and `y >= z`, then `y` is the largest.
4. Otherwise, `z` is the largest, because the first two checks failed.

Example: `5`, `5`, `3`
- `x >= y` is true (5 >= 5) and `x >= z` is true (5 >= 3)
- so it prints `5 is the largest`

Example: `2`, `9`, `4`
- first check fails because `2 >= 9` is false
- second check passes because `9 >= 2` and `9 >= 4`
- it prints `9 is the largest`

## 2. Problem Title
Find the Largest of Three Numbers

## 3. Problem Summary
Read three integers and print the largest one. The program must also work when some of the numbers are equal.

## 4. Intuition
Think of three people comparing heights. Person X steps forward and asks: "Am I at least as tall as both of you?" If yes, X is the tallest. If not, Y asks the same question. If Y is not the tallest either, then Z must be. Using "at least as tall" (`>=`) matters, because two people can have the same height and neither is "taller" than the other.

## 5. Approaches
An `if / else if / else` chain with two comparisons per branch.

## 6. Complexity Analysis
Time is O(1) and space is O(1), because there are at most four comparisons.

## 7. Edge Cases
- Two equal largest numbers (`5 5 3`, `3 5 5`, `5 3 5`): prints 5 in every case.
- All three equal (`4 4 4`): prints 4.
- Negative numbers (`-3 -1 -7`): prints -1.
- Largest in the last position (`1 2 9`): the `else` branch prints it.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int z = int.Parse(Console.ReadLine());

        if (x >= y && x >= z)
        {
            Console.WriteLine(x + " is the largest");
        }
        else if (y >= x && y >= z)
        {
            Console.WriteLine(y + " is the largest");
        }
        else
        {
            Console.WriteLine(z + " is the largest");
        }
    }
}
```

## 9. Improvements
- `Math.Max(x, Math.Max(y, z))` gives the answer in one line. The `if` version shows the logic, so keep it for the lab.
- Another common version sets `int largest = x;` and then updates it with two separate `if` statements.

## 10. Mistakes
- Using `>` instead of `>=`. With `5 5 3`, both the first and second checks fail, so the `else` prints 3, which is wrong.
- Using `||` instead of `&&`. The number must beat both others, not just one.
- Forgetting the `else`, so nothing prints when the first two checks fail.
- Using `=` instead of `==` or `>=`. `=` assigns and the others compare.

## 11. Learnings
- `&&` means both conditions must be true.
- `>=` handles ties, while `>` does not.
- An `if / else if / else` chain runs only the first branch that matches.
- The last `else` catches everything left over.

## FAQ

<details>
<summary>Why use <code>&gt;=</code> and not <code>&gt;</code>?</summary>

With `>`, two equal largest numbers each fail the check against the other, and the program falls into the `else` and prints the wrong number. `>=` allows ties.
</details>

<details>
<summary>Why is there no condition on the <code>else</code>?</summary>

If `x` and `y` both failed to be the largest, `z` has to be, so no extra check is needed.
</details>

<details>
<summary>Why <code>&amp;&amp;</code> and not <code>||</code>?</summary>

A number is the largest only if it beats both others. `||` would accept a number that beats just one.
</details>

<details>
<summary>Does the order of the checks matter?</summary>

The result is always a correct largest value. For ties, the first matching branch wins, so `x` is printed before `y`, and `y` before `z`.
</details>

<details>
<summary>Is there a shorter way?</summary>

Yes, `Math.Max(x, Math.Max(y, z))`. The `if` version shows your logic clearly.
</details>