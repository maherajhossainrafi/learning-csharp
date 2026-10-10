# Check Neon Number

## Quick Answer

> Square the number, add up the digits of the square with `% 10` and `/ 10`, and if that digit sum equals the original number, it is a neon number.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. Calculate the square as a `long`: `(long)n * n`. This avoids overflow for big numbers.
3. Copy the square into `temp` and set `sum` to 0.
4. While `temp > 0`: take the last digit with `temp % 10`, add it to `sum`, and remove it with `temp / 10`.
5. If `sum == n`, print that it is a neon number. Otherwise print that it is not.

Example: `9`
- Square is 81.
- Digit sum is 8 + 1 = 9.
- 9 equals 9, so it is a neon number.

## 2. Problem Title
Check Whether a Number Is a Neon Number

## 3. Problem Summary
A neon number is a number whose digit sum of its square equals the number. Examples: 0, 1, 9. Non-example: 5 (square 25, digit sum 7).

## 4. Intuition
Think of making a number bigger first (squaring it), then breaking the big number into single digits and adding them up. For a neon number, all that work lands you right back where you started. The digit-peeling loop is the same tool you used for Armstrong, spy and palindrome numbers, just applied to the square instead of the number itself.

## 5. Approaches
Square the number, then use a `while` loop to sum the digits of the square.

## 6. Complexity Analysis
Time is O(d), where d is the number of digits in the square. Space is O(1).

## 7. Edge Cases
- `0` and `1` are neon numbers (0 gives 0, and 1 gives 1).
- `9` is a neon number (81 gives 9).
- Negative numbers: the square is positive but the digit sum is positive too, so it never equals a negative `n`, and they print as not neon.
- Large `n` (like 50000) would overflow `int` when squared, which is why `long` is used.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        long square = (long)n * n;
        long temp = square;
        long sum = 0;

        while (temp > 0)
        {
            long digit = temp % 10;
            sum = sum + digit;
            temp = temp / 10;
        }

        if (sum == n)
        {
            Console.WriteLine(n + " is a neon number");
        }
        else
        {
            Console.WriteLine(n + " is not a neon number");
        }
    }
}
```

## 9. Improvements
- If your course only uses small numbers, `int square = n * n;` and `int` variables work and look simpler. Keep `long` if large inputs may be tested.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Adding the digits of `n` instead of the digits of `n * n`.
- Writing `int square = n * n;` for large `n`, which overflows silently and gives a wrong square.
- Changing `square` inside the loop. Use the copy `temp` so the square is kept.
- Forgetting `temp = temp / 10`, which makes an infinite loop.

## 11. Learnings
- `% 10` gets the last digit and `/ 10` removes it.
- `(long)n * n` converts to `long` before multiplying so the result cannot overflow.
- `long` holds much bigger whole numbers than `int`.
- The same digit loop can be reused for many problems.

## FAQ

<details>
<summary>Why use <code>long</code> for the square?</summary>

An `int` holds values up to about 2.1 billion. A square can be much bigger, so `long` avoids a wrong answer from overflow.
</details>

<details>
<summary>Why <code>(long)n * n</code> and not <code>(long)(n * n)</code>?</summary>

In `(long)(n * n)` the multiplication happens in `int` first and may overflow before the cast. Casting one side to `long` first makes the multiplication happen in `long`.
</details>

<details>
<summary>Is 0 a neon number here?</summary>

Yes. The square is 0, the digit sum is 0, and that equals the number.
</details>

<details>
<summary>What is the difference between this and the Armstrong problem?</summary>

Both peel digits with `% 10` and `/ 10`. Armstrong sums each digit raised to a power. Neon sums the plain digits of the square.
</details>

<details>
<summary>Why compare <code>sum == n</code> when <code>sum</code> is <code>long</code> and <code>n</code> is <code>int</code>?</summary>

C# converts the `int` to `long` automatically for the comparison, so it works without extra code.
</details>