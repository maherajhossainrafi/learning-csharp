# Print Primes Up To N

## Quick Answer

> For every number from 2 to N, assume it is prime, try dividing it by every number from 2 up to just below it, and if any divides it exactly, mark it as not prime. Print the numbers that stay prime.

## 1. Solution Walkthrough
1. Read `n`.
2. The outer loop picks each `num` from 2 to `n`.
3. Set `isPrime` to `true` for the current `num`.
4. The inner loop tries each `i` from 2 to `num - 1`.
5. If `num % i == 0`, then `i` divides `num`, so set `isPrime` to `false` and `break`.
6. After the inner loop, if `isPrime` is still `true`, print `num`.

Example: `N = 10`
- 2, 3, 5 and 7 have no divisors in between, so they are printed.
- 4, 6, 8, 9 and 10 each have a divisor, so they are skipped.

Output: `2 3 5 7`

## 2. Problem Title
Print All Prime Numbers up to N

## 3. Problem Summary
A prime number is greater than 1 and divisible only by 1 and itself. Print every prime from 2 up to N.

## 4. Intuition
Think of testing each number at a sieve with holes of different sizes. For each number you try the holes 2, 3, 4, and so on. If any hole fits it exactly, the number is not prime and you throw it out right away. If it passes every hole, it is prime. The flag `isPrime` is the verdict, and `break` stops testing as soon as one hole fits.

## 5. Approaches
Two nested loops: the outer loop goes through the candidates, and the inner loop tests divisors.

## 6. Complexity Analysis
Time is O(n²) in the worst case, because each number may be tested against many divisors. This is fine for lab-sized input. Space is O(1).

## 7. Edge Cases
- `N = 2`: the output is `2`.
- `N = 1`, `0` or negative: the outer loop does not run, so the output is an empty line.
- `N = 3`: the output is `2 3`.
- The loop starts at 2, because 0 and 1 are not prime.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        for (int num = 2; num <= n; num++)
        {
            bool isPrime = true;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.Write(num + " ");
            }
        }
        Console.WriteLine();
    }
}
```

## 9. Improvements
- Change the inner loop to `i * i <= num` to make it much faster. A number that is not prime always has a divisor up to its square root.
- Another option is `i <= num / 2`. Keep `i < num` for the lab if it is simplest to explain.

## 10. Mistakes
- Setting `isPrime = true` outside the outer loop. It must be reset for every `num`.
- Starting the outer loop at 1, which prints 1 as a prime. 1 is not prime.
- Starting the inner loop at 1, since every number is divisible by 1 and nothing would be prime. Start at 2.
- Forgetting `break`. The answer is still correct, but the loop does extra work.

## 11. Learnings
- A loop inside a loop is called a nested loop.
- A `bool` flag records a yes or no result for each candidate.
- `break` leaves the inner loop only, not the outer loop.
- `num % i == 0` means `i` divides `num` exactly.

## FAQ

<details>
<summary>Why is <code>isPrime</code> declared inside the outer loop?</summary>

Each number needs a fresh start. Declaring it inside gives every `num` its own `isPrime` set to `true`.
</details>

<details>
<summary>What does <code>break</code> do here?</summary>

It stops the inner loop right away once a divisor is found, because the number is already known to be not prime. The outer loop carries on with the next number.
</details>

<details>
<summary>Why does the outer loop start at 2?</summary>

0 and 1 are not prime, and 2 is the smallest prime number.
</details>

<details>
<summary>Why does the inner loop stop before <code>num</code>?</summary>

Every number divides itself, so testing `i == num` would wrongly mark every number as not prime.
</details>

<details>
<summary>How can this be made faster?</summary>

Stop the inner loop at the square root of `num`, written as `i * i <= num`. Any number that is not prime has a divisor at or below its square root.
</details>