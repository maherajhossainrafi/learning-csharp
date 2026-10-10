# Check Spy Number

## Quick Answer

> Peel off each digit with `% 10` and `/ 10`, add the digits into `sum`, multiply them into `product` (starting at 1), and if `sum` equals `product`, it is a spy number.

## 1. Solution Walkthrough
1. Read the number into `n`.
2. Set `sum` to 0 and `product` to 1, and copy `n` into `temp`.
3. While `temp > 0`:
   - Take the last digit with `temp % 10`.
   - Add it to `sum`.
   - Multiply `product` by it.
   - Remove the last digit with `temp / 10`.
4. If `sum == product`, print that it is a spy number. Otherwise print that it is not.

Example: `1124` gives sum = 1 + 1 + 2 + 4 = 8 and product = 1 × 1 × 2 × 4 = 8. They match, so it is a spy number.

## 2. Problem Title
Check Whether a Number Is a Spy Number

## 3. Problem Summary
A spy number is a number whose digit sum equals its digit product. Examples: 22, 123, 1124.

## 4. Intuition
Think of two scoreboards that both start counting as you read the digits one by one. One scoreboard adds each digit, and the other multiplies by each digit. At the end, you compare the two scores. If they show the same value, the number is a spy number. The multiplying scoreboard starts at 1, because multiplying by 0 at the start would keep it at 0 forever.

## 5. Approaches
One `while` loop that updates both the sum and the product in the same pass.

## 6. Complexity Analysis
Time is O(d), where d is the number of digits. Space is O(1).

## 7. Edge Cases
- Single digits (1 to 9): sum and product are both the digit itself, so they are spy numbers.
- A number with a 0 digit (like `101`): the product becomes 0 but the sum does not, so it is not a spy number.
- `0` and negative numbers: the loop does not run, so sum is 0 and product is 1, and they print as not spy.
- `22`: 2 + 2 = 4 and 2 × 2 = 4, so it is a spy number.

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
        int product = 1;
        int temp = n;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum = sum + digit;
            product = product * digit;
            temp = temp / 10;
        }

        if (sum == product)
        {
            Console.WriteLine(n + " is a spy number");
        }
        else
        {
            Console.WriteLine(n + " is not a spy number");
        }
    }
}
```

## 9. Improvements
- Use `sum += digit;` and `product *= digit;` as shorter forms. Both styles are correct.
- Use `int.TryParse` to avoid crashes on bad input. This is optional.

## 10. Mistakes
- Starting `product` at 0. Every multiplication then gives 0, so the product is always 0.
- Changing `n` instead of `temp`, so the original number is lost and cannot be printed at the end.
- Forgetting to update `temp = temp / 10`, which makes the loop run forever.
- Mixing up `%` and `/`. `%` gives the last digit and `/` removes it.

## 11. Learnings
- `% 10` gets the last digit, and `/ 10` drops it.
- A running sum starts at 0 and a running product starts at 1.
- One loop can update several variables at once.
- Use a copy of the input when you still need the original.

## FAQ

<details>
<summary>Why does <code>product</code> start at 1 and not 0?</summary>

Anything multiplied by 0 is 0, so a product starting at 0 would never change. 1 is the neutral starting value for multiplication, just as 0 is for addition.
</details>

<details>
<summary>Why do we use <code>temp</code>?</summary>

The loop keeps dividing until the number reaches 0. A copy keeps `n` safe so we can still print it at the end.
</details>

<details>
<summary>What do <code>% 10</code> and <code>/ 10</code> do?</summary>

`% 10` gives the last digit and `/ 10` removes it, because integer division drops the remainder.
</details>

<details>
<summary>Why are single-digit numbers spy numbers?</summary>

The sum and the product both equal the digit itself, so they match.
</details>

<details>
<summary>Why does the loop condition use <code>temp &gt; 0</code>?</summary>

When all digits have been removed, `temp` becomes 0 and the loop stops.
</details>