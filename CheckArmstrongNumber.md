# Check Armstrong Number

## Quick Answer

> Count the digits of the number, then add up each digit raised to the power of that count. If the total equals the original number, it is an Armstrong number.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. Count the digits: copy `n` into `temp`, and while `temp > 0`, add 1 to `digits` and divide `temp` by 10.
3. Reset `temp` to `n` and set `sum` to 0.
4. While `temp > 0`, take the last digit with `temp % 10`, raise it to the power of `digits` with `Math.Pow`, and add it to `sum`. Then remove the last digit with `temp / 10`.
5. If `sum` equals `n`, it is an Armstrong number. Otherwise it is not.

Example: `153` has 3 digits. 1³ + 5³ + 3³ = 1 + 125 + 27 = 153, so it is an Armstrong number.

## 2. Problem Title
Check Whether a Number Is an Armstrong Number

## 3. Problem Summary
A number is an Armstrong number if the sum of its digits, each raised to the power of the number of digits, equals the number itself. Examples: 153, 370, 9474.

## 4. Intuition
Think of peeling an onion layer by layer. `% 10` gives you the outer layer (the last digit) and `/ 10` removes it. You keep peeling until nothing is left, doing some work on each layer. First you peel to count the layers, then you peel again to do the power and sum.

## 5. Approaches
Two `while` loops: one to count the digits and one to add the powers. This is the standard approach and is easy to explain.

## 6. Complexity Analysis
Time is O(d), where d is the number of digits, because each loop removes one digit per step. Space is O(1).

## 7. Edge Cases
- Single digits (1 to 9) are Armstrong numbers, because a digit to the power of 1 is itself.
- `0` prints "is an Armstrong number", since the loops do not run and `sum` is 0.
- Negative numbers are reported as not Armstrong, because the loops do not run and `sum` stays 0.
- `10`: 1² + 0² = 1, which is not 10.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int digits = 0;
        int temp = n;
        while (temp > 0)
        {
            digits++;
            temp = temp / 10;
        }

        int sum = 0;
        temp = n;
        while (temp > 0)
        {
            int digit = temp % 10;
            sum = sum + (int)Math.Pow(digit, digits);
            temp = temp / 10;
        }

        if (sum == n)
        {
            Console.WriteLine(n + " is an Armstrong number");
        }
        else
        {
            Console.WriteLine(n + " is not an Armstrong number");
        }
    }
}
```

## 9. Improvements
- Use `n.ToString().Length` to count the digits in one line. The loop version teaches `%` and `/`, so keep it for the lab.
- Use `Math.Round` around `Math.Pow` if you ever worry about decimal rounding. For small digits it is exact.

## 10. Mistakes
- Changing `n` while looping, so the original is lost and the final comparison is wrong. Always work on the copy `temp`.
- Forgetting to reset `temp = n` before the second loop. `temp` is 0 after the first loop.
- Using a fixed power of 3 for every number. The power is the number of digits.
- Forgetting the `(int)` cast, because `Math.Pow` returns a `double`.

## 11. Learnings
- `% 10` gives the last digit and `/ 10` removes it (integer division).
- A `while` loop repeats until its condition is false.
- `Math.Pow(a, b)` returns a `double`, so cast it with `(int)`.
- Use a copy of the input when you need the original later.

## FAQ

<details>
<summary>Why do we need <code>temp</code>?</summary>

The loops keep dividing the number until it is 0. If we used `n` itself, we would lose the original and could not compare at the end.
</details>

<details>
<summary>Why two loops?</summary>

The first loop finds the power (the digit count), which must be known before the second loop can add up the powers.
</details>

<details>
<summary>Why <code>(int)Math.Pow(digit, digits)</code>?</summary>

`Math.Pow` returns a `double`, and `sum` is an `int`, so the result must be converted to `int`.
</details>

<details>
<summary>What do <code>% 10</code> and <code>/ 10</code> do?</summary>

`% 10` gives the remainder, which is the last digit. `/ 10` drops the last digit because integer division throws away the remainder.
</details>

<details>
<summary>Is 0 an Armstrong number here?</summary>

The program prints yes for 0, because the sum is 0 and equals the number. Some definitions also count 0 as Armstrong.
</details>