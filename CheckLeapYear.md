# Check Leap Year

## Quick Answer

> A year is a leap year if it is divisible by 4 and not by 100, or if it is divisible by 400.

## 1. Solution Walkthrough
1. Read the year into `n`.
2. Check the rule: `(n % 4 == 0 && n % 100 != 0) || n % 400 == 0`.
3. If the rule is true, print that it is a leap year.
4. Otherwise print that it is not.

Examples:
- `2024`: divisible by 4 and not by 100, so it is a leap year.
- `1900`: divisible by 4 and by 100, but not by 400, so it is not a leap year.
- `2000`: divisible by 400, so it is a leap year.
- `2023`: not divisible by 4, so it is not a leap year.

## 2. Problem Title
Check Whether a Year Is a Leap Year

## 3. Problem Summary
A leap year has 366 days. Read a year and print whether it is a leap year. The rule: divisible by 4, except century years (like 1900), which must also be divisible by 400.

## 4. Intuition
Think of a rule with an exception and an exception to the exception. Most years divisible by 4 are leap years. But century years are skipped (the exception). Yet every fourth century, like 2000, is a leap year again (the exception to the exception). The condition has two paths to "yes": one for normal years and one for the 400 rule.

## 5. Approaches
One `if / else` with a combined condition using `&&` and `||`.

## 6. Complexity Analysis
Time is O(1) and space is O(1), because it is only a few comparisons.

## 7. Edge Cases
- Century years: `1900` and `2100` are not leap years, and `2000` and `2400` are.
- `4` is a leap year, and `100` is not.
- `0` is divisible by 400, so it prints as a leap year.
- Negative years follow the same rule in this program.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int n = int.Parse(Console.ReadLine());

        if ((n % 4 == 0 && n % 100 != 0) || n % 400 == 0)
        {
            Console.WriteLine(n + " is a leap year");
        }
        else
        {
            Console.WriteLine(n + " is not a leap year");
        }
    }
}
```

## 9. Improvements
- `DateTime.IsLeapYear(n)` does the same check in one call, but it only accepts years from 1 to 9999. Write the rule by hand in the lab, since it shows the logic.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Checking only `n % 4 == 0`, which wrongly marks 1900 as a leap year.
- Using `=` instead of `==` in the conditions.
- Using `&&` in place of `||` between the two parts, which makes 2000 fail.
- Writing `n % 100 == 0` where `!= 0` is needed. The first part of the rule wants years that are not century years.

## 11. Learnings
- `%` gives the remainder, so `n % 4 == 0` means "divisible by 4".
- `&&` means "and", `||` means "or", and `!=` means "not equal".
- `&&` is evaluated before `||`, and brackets make the order clear.
- One `if / else` can hold a combined condition.

## FAQ

<details>
<summary>Why is 1900 not a leap year but 2000 is?</summary>

1900 is divisible by 100 but not by 400. 2000 is divisible by 400, so it qualifies.
</details>

<details>
<summary>Do the brackets change the meaning?</summary>

No. `&&` is already evaluated before `||`, so the answer is the same. The brackets just make it easier to read and explain.
</details>

<details>
<summary>What does <code>n % 4 == 0</code> mean?</summary>

It means dividing `n` by 4 leaves a remainder of 0, so `n` is divisible by 4.
</details>

<details>
<summary>What do <code>&amp;&amp;</code> and <code>||</code> mean?</summary>

`&&` means both conditions must be true. `||` means at least one must be true.
</details>

<details>
<summary>Is there a built-in way to check?</summary>

Yes, `DateTime.IsLeapYear(year)`. Writing the rule yourself shows that you understand it.
</details>