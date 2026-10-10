# Check Perfect Number

## Quick Answer

> Loop from 1 to half of the number, add up every value that divides the number exactly, and if the total equals the number (and the number is positive), it is a perfect number.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. Set `sum` to 0.
3. Loop `i` from 1 to `n / 2`. No number bigger than half of `n` can divide `n` (other than `n` itself, which we leave out).
4. If `n % i == 0`, then `i` divides `n` exactly, so add it to `sum`.
5. If `sum == n` and `n > 0`, print that it is a perfect number. Otherwise print that it is not.

Example: `6` has divisors 1, 2 and 3. 1 + 2 + 3 = 6, so it is perfect.

## 2. Problem Title
Check Whether a Number Is a Perfect Number

## 3. Problem Summary
A perfect number equals the sum of its proper divisors (all divisors except the number itself). Examples: 6, 28, 496.

## 4. Intuition
Think of splitting a chocolate bar into equal pieces. A divisor tells you a way to split it evenly. A perfect number is special: if you take every smaller way of splitting it (1 piece, 2 pieces, and so on) and add the sizes together, you get exactly the whole bar again. The loop tries each possible divisor, and the `%` operator checks whether it splits the number evenly.

## 5. Approaches
One approach: test every number from 1 to `n / 2` and add the ones that divide `n`.

## 6. Complexity Analysis
Time is O(n), because the loop runs about n/2 times. Space is O(1).

## 7. Edge Cases
- `1`: the loop does not run, sum is 0, so it is not perfect.
- `0` and negative numbers: the `n > 0` check makes them not perfect.
- `6` and `28` are perfect, and `12` is not (1 + 2 + 3 + 4 + 6 = 16).
- Prime numbers such as `7`: the sum is 1, so they are not perfect.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                sum = sum + i;
            }
        }

        if (sum == n && n > 0)
        {
            Console.WriteLine(n + " is a perfect number");
        }
        else
        {
            Console.WriteLine(n + " is not a perfect number");
        }
    }
}
```

## 9. Improvements
- Looping up to the square root of `n` and adding both divisors in each pair is faster, but harder to explain. Keep `n / 2` for the lab.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Looping up to `n` instead of `n / 2`. Then `n` itself is counted as a divisor, and the sum is always too big.
- Forgetting the `n > 0` check, so `0` is reported as perfect (its sum is 0).
- Writing `n / i == 0` instead of `n % i == 0`. `%` gives the remainder and `/` gives the quotient.
- Using `=` instead of `==` in the conditions.

## 11. Learnings
- `n % i == 0` means `i` divides `n` exactly.
- A `for` loop can end at an expression like `n / 2`.
- `&&` means both conditions must be true.
- A running total (`sum = sum + i`) is a basic loop pattern.

## FAQ

<details>
<summary>Why loop only up to <code>n / 2</code>?</summary>

The biggest proper divisor of `n` is at most half of `n`. Anything bigger than that cannot divide `n` evenly, except `n` itself, which we must not count.
</details>

<details>
<summary>What does <code>n % i == 0</code> mean?</summary>

It means the remainder of `n` divided by `i` is 0, so `i` is a divisor of `n`.
</details>

<details>
<summary>Why check <code>n &gt; 0</code>?</summary>

For `0` and negative numbers the loop adds nothing, and `0` would wrongly match a sum of 0. The check makes sure only positive numbers can be perfect.
</details>

<details>
<summary>Why is 1 not a perfect number?</summary>

It has no proper divisors, so the sum is 0, which is not equal to 1.
</details>

<details>
<summary>What does <code>&amp;&amp;</code> do?</summary>

It means "and". The message is printed as perfect only when both conditions are true.
</details>