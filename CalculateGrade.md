# Calculate Grade

## Quick Answer

> Read a score, reject it if it is outside 0-100, otherwise use an `if / else if` chain from the highest grade down to the lowest and print the first match.

## 1. Solution Walkthrough
1. Ask for a score and read it with `Console.ReadLine()`.
2. Convert the text to a number with `int.Parse`.
3. If the score is below 0 or above 100, print "Invalid score".
4. Otherwise check `>= 90`, then `>= 80`, `>= 70`, `>= 60`.
5. If none match, the grade is F.

## 2. Problem Title
Calculate Grade from a Score

## 3. Problem Summary
Take a score from 0 to 100 and print a letter grade: A (90+), B (80-89), C (70-79), D (60-69), F (below 60). Print "Invalid score" for anything outside 0-100.

## 4. Intuition
Think of a ladder of height markers. You check the highest bar first: "Is the score at least 90?" If not, you step down to the next bar. The first bar you clear gives the grade, and the rest are skipped. In C#, an `if / else if` chain works exactly like this, because only the first true condition runs.

## 5. Approaches
Only one approach is needed: an `if / else if / else` chain. (A `switch` on `score / 10` also works, but the chain is simpler to remember and explain.)

## 6. Complexity Analysis
Time is O(1), because there are at most five comparisons. Space is O(1), because there is just one variable.

## 7. Edge Cases
- `0` gives F, and `100` gives A.
- `90`, `80`, `70` and `60` are exactly on a boundary and give A, B, C and D.
- `-1` and `101` give Invalid score.
- Typing letters or a decimal like `85.5` crashes `int.Parse`. This is acceptable for a basic lab, but mention it if asked.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter score (0-100): ");
        int score = int.Parse(Console.ReadLine());

        if (score < 0 || score > 100)
        {
            Console.WriteLine("Invalid score");
        }
        else if (score >= 90)
        {
            Console.WriteLine("Grade: A");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Grade: B");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Grade: C");
        }
        else if (score >= 60)
        {
            Console.WriteLine("Grade: D");
        }
        else
        {
            Console.WriteLine("Grade: F");
        }
    }
}
```

## 9. Improvements
- Use `int.TryParse` so text input shows a friendly message instead of crashing. This is optional for a first lab.
- Use `double.Parse` if scores like 85.5 are allowed.

## 10. Mistakes
- Checking `>= 60` first makes every passing score become D, because the chain stops at the first true condition. Always go from highest to lowest.
- Writing `score >= 90 && score <= 100` is not needed, because the invalid check already ran first.
- Using `=` instead of `==` or `>=`. `=` assigns and `>=` compares.
- Forgetting to convert the input. `Console.ReadLine()` returns text, not a number.

## 11. Learnings
- `if / else if / else` runs only the first matching branch.
- Order matters in a decision chain.
- `||` means "or" and is used to catch invalid input.
- `Console.ReadLine()` gives a string, and `int.Parse` converts it.

## FAQ

<details>
<summary>Why check invalid scores first?</summary>

So a score like 150 is not wrongly graded A.
</details>

<details>
<summary>Why no <code>&&</code> in the grade checks?</summary>

The earlier conditions already failed, so `score >= 80` means the score is also below 90.
</details>

<details>
<summary>What does <code>int.Parse</code> do?</summary>

It converts the text typed by the user into an `int`.
</details>

<details>
<summary>Why <code>using System;</code>?</summary>

It gives access to `Console`.
</details>

<details>
<summary>Why <code>static void Main()</code>?</summary>

It is the program's starting point. `static` means it runs without creating an object, and `void` means it returns nothing.
</details>