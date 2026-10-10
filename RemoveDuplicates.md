# Remove Duplicates

## Quick Answer

> Read the numbers into an array, then go through them one by one and add each number to a new `List<int>` only if the list does not already contain it.

## 1. Solution Walkthrough
1. Read `n` and create an array of size `n`.
2. Fill the array with a `for` loop.
3. Create an empty list called `unique`.
4. Use `foreach` to look at each number `x` in the array.
5. If `unique.Contains(x)` is false, add `x` to `unique`.
6. Print the `unique` list with another `foreach`.

Example: input `4 7 4 2 7` gives `4 7 2`.

## 2. Problem Title
Remove Duplicate Numbers

## 3. Problem Summary
Read N integers and print them with all duplicates removed. Each number appears once, in the order it first appeared.

## 4. Intuition
Think of a guest list at the door. Before letting someone in, you check the list: "Is this person already inside?" If yes, you skip them. If no, you let them in and write their name down. The `unique` list is the guest list, and `Contains` is the check.

## 5. Approaches
One simple approach: keep a list of seen numbers and check it with `Contains` before adding. (`Distinct()` or a `HashSet` also work, but this version is easier to explain.)

## 6. Complexity Analysis
Time is O(n²) in the worst case, because `Contains` may check the whole list for each number. This is fine for lab-sized input. Space is O(n) for the new list.

## 7. Edge Cases
- All numbers equal (`5 5 5`): the result is just `5`.
- No duplicates: the output is the same as the input.
- `n = 1`: the output is the single number.
- `n = 0`: the output is an empty line.
- Negative `n` crashes at `new int[n]`.

## 8. Implementations
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("How many numbers? ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        List<int> unique = new List<int>();

        foreach (int x in arr)
        {
            if (unique.Contains(x) == false)
            {
                unique.Add(x);
            }
        }

        Console.WriteLine("Without duplicates:");
        foreach (int x in unique)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}
```

## 9. Improvements
- `if (!unique.Contains(x))` is a shorter way to write `== false`. Both are correct.
- Add an `if (n < 0)` check to avoid the crash on negative input.

## 10. Mistakes
- Adding every number to the list without checking `Contains`, so duplicates stay.
- Trying to remove items from the array while looping over it. Arrays have a fixed size, so build a new list instead.
- Using `=` instead of `==` in the condition.
- Forgetting `using System.Collections.Generic;`, which gives an error on `List`.

## 11. Learnings
- `list.Contains(x)` returns `true` or `false`.
- `foreach` reads every item without needing an index.
- Building a new list is simpler than changing the original array.
- The order of first appearance is kept because we add items as we meet them.

## FAQ

<details>
<summary>What does <code>unique.Contains(x) == false</code> mean?</summary>

It means "the list does not contain `x` yet", so it is safe to add it.
</details>

<details>
<summary>Why not remove duplicates from the array directly?</summary>

An array has a fixed size, so you cannot delete items from it. A new list can grow, so it is easier.
</details>

<details>
<summary>Why do we use <code>foreach</code> here?</summary>

We only need each value and not its index, so `foreach` is shorter and clearer than a `for` loop.
</details>

<details>
<summary>Is the output order the same as the input order?</summary>

Yes. Each number is added when it first appears, so the order of first appearance is kept.
</details>

<details>
<summary>Is there a shorter way to do this?</summary>

Yes, `arr.Distinct()` from `System.Linq`. The loop version shows the logic, which is better for a lab.
</details>