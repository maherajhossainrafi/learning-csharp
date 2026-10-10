# Check Palindrome Number

## Quick Answer

> Build the reverse of the number by peeling off the last digit with `% 10` and adding it to the end of `rev` with `rev * 10 + digit`. If the reversed number equals the original, it is a palindrome.

## 1. Solution Walkthrough
1. Read the number into `n`, and copy it into `temp`.
2. Set `rev` to 0.
3. While `temp > 0`:
   - Take the last digit with `temp % 10`.
   - Put it at the end of `rev` with `rev = rev * 10 + digit`.
   - Remove the last digit from `temp` with `temp / 10`.
4. If `rev == n`, print that it is a palindrome. Otherwise print that it is not.

Example: `121`
- digit 1, rev = 0 × 10 + 1 = 1
- digit 2, rev = 1 × 10 + 2 = 12
- digit 1, rev = 12 × 10 + 1 = 121

`rev` is 121, which equals `n`, so it is a palindrome.

## 2. Problem Title
Check Whether a Number Is a Palindrome

## 3. Problem Summary
A palindrome number reads the same forwards and backwards. Examples: 121, 1331, 7. Non-examples: 123, 120.

## 4. Intuition
Think of stacking cards one at a time from the right end of a number. The last digit goes down first, then the next one is placed after it, and so on. When you finish, the stack is the number written backwards. If the backwards number matches the original, the number is a palindrome. Multiplying `rev` by 10 makes room on the right, and adding `digit` fills that spot.

## 5. Approaches
Reverse the number with a `while` loop and compare it with the original.

## 6. Complexity Analysis
Time is O(d), where d is the number of digits. Space is O(1).

## 7. Edge Cases
- Single digits (0 to 9) are palindromes.
- Numbers ending in 0 (like `120`): the reverse is 21, so they are not palindromes.
- Negative numbers: the loop does not run, `rev` stays 0, and they print as not palindromes.
- Very large numbers close to the `int` limit can overflow when reversed. This is not a concern for lab inputs.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n;
        int rev = 0;
        while (temp > 0)
        {
            int digit = temp % 10;
            rev = rev * 10 + digit;
            temp = temp / 10;
        }

        if (rev == n)
        {
            Console.WriteLine(n + " is a palindrome");
        }
        else
        {
            Console.WriteLine(n + " is not a palindrome");
        }
    }
}
```

## 9. Improvements
- Use `long` for `rev` if very large numbers must be supported.
- Another way is `n.ToString()` and comparing it with its reversed characters, but the loop version teaches `%` and `/`, so keep it for the lab.

## 10. Mistakes
- Changing `n` while looping, so the final comparison is made against 0. Always loop on the copy `temp`.
- Writing `rev = rev + digit` and forgetting the `* 10`, which adds the digits instead of reversing them.
- Forgetting `temp = temp / 10`, which makes an infinite loop.
- Initializing `rev` to 1. It must start at 0.

## 11. Learnings
- `% 10` gets the last digit and `/ 10` removes it.
- `rev * 10 + digit` appends a digit to a number.
- Keep a copy of the original number to compare with at the end.
- A palindrome equals its own reverse.

## FAQ

<details>
<summary>What does <code>rev * 10 + digit</code> do?</summary>

Multiplying by 10 shifts all current digits one place left, which opens a spot at the end. Adding `digit` fills that spot.
</details>

<details>
<summary>Why do we need <code>temp</code>?</summary>

The loop reduces the number to 0. We need `n` unchanged so we can compare the reverse with the original.
</details>

<details>
<summary>Why does <code>rev</code> start at 0?</summary>

It is the neutral start for building a number digit by digit. The first digit becomes `0 * 10 + digit`.
</details>

<details>
<summary>Is a single-digit number a palindrome?</summary>

Yes. Its reverse is the same digit.
</details>

<details>
<summary>Why is 120 not a palindrome?</summary>

Its reverse is 021, which is just 21, and 21 is not equal to 120.
</details>