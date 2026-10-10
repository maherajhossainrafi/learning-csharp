# Reverse Array and Take First Five

## Quick Answer

> Read N numbers into an array, reverse it with `Array.Reverse`, print it, then copy the first `Math.Min(5, n)` items into a `List<int>` and print that list with `foreach`.

## 1. Solution Walkthrough
1. Read `n`, then create an array of size `n`.
2. Use a `for` loop to read each number into the array.
3. Call `Array.Reverse(arr)`. This reverses the array in place.
4. Print the array with a `for` loop.
5. Create an empty `List<int>`.
6. Set `count` to the smaller of 5 and `n`, so we never go past the end of the array.
7. Add the first `count` items of the array to the list.
8. Print the list with `foreach`.

## 2. Problem Title
Reverse an Array and Copy the First Five Items into a List

## 3. Problem Summary
Read N integers into an array and print them in reverse order. Then store the first 5 items of the reversed array in a `List<int>` and print the list. If there are fewer than 5 numbers, store all of them.

## 4. Intuition
Think of a stack of plates. Reversing the array is like flipping the whole stack upside down, so the last plate is now on top. Then you pick the top five plates and put them in a new basket (the list). If the stack has fewer than five plates, you just take what is there.

## 5. Approaches
Use the built-in `Array.Reverse`. If your teacher wants it done manually, swap the first and last items, then move inward, until the two positions meet.

## 6. Complexity Analysis
Time is O(n) for reading, reversing and printing. Space is O(n) for the array, and the list holds at most 5 items.

## 7. Edge Cases
- `n = 0`: the array is empty, and both outputs are empty lines.
- `n < 5`: `Math.Min` makes the list hold all `n` items.
- `n = 1`: the reversed array is the same single number.
- Negative `n` crashes at `new int[n]`, because an array cannot have a negative size.

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

        Array.Reverse(arr);

        Console.WriteLine("Reversed array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        List<int> list = new List<int>();
        int count = Math.Min(5, n);
        for (int i = 0; i < count; i++)
        {
            list.Add(arr[i]);
        }

        Console.WriteLine("First 5 of the reversed array (List):");
        foreach (int x in list)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}
```

## 9. Improvements
- Add `if (n < 0)` with a message and `return` to avoid the crash on negative input.
- Be ready to reverse by hand with a loop that swaps `arr[i]` and `arr[n - 1 - i]`, in case your teacher bans `Array.Reverse`.

## 10. Mistakes
- Looping to 5 without checking `n`, which crashes with `IndexOutOfRangeException` when there are fewer than 5 numbers.
- Forgetting that `Array.Reverse(arr)` changes the original array, so the first 5 items are taken after reversing.
- Writing `arr.Reverse()` and expecting it to change the array. Use `Array.Reverse(arr)`.
- Mixing up `arr.Length` for arrays and `list.Count` for lists.

## 11. Learnings
- Arrays have a fixed size: `new int[n]`.
- `Array.Reverse(arr)` reverses in place.
- `Math.Min(a, b)` returns the smaller value and keeps loops safe.
- A `List<int>` is filled with `Add`.
- `foreach` is the easiest way to read every item of a list.

## FAQ

<details>
<summary>Why use <code>Math.Min(5, n)</code>?</summary>

It gives 5 when there are at least 5 numbers and `n` when there are fewer, so the loop never reads past the end of the array.
</details>

<details>
<summary>Does <code>Array.Reverse</code> return a new array?</summary>

No. It reverses the same array in place and returns nothing.
</details>

<details>
<summary>Why use a <code>for</code> loop for the array but <code>foreach</code> for the list?</summary>

We need the index `i` to fill and print the array. For the list we only need each value, so `foreach` is simpler.
</details>

<details>
<summary>What is the difference between an array and a <code>List&lt;int&gt;</code>?</summary>

An array has a fixed size. A list can grow with `Add`.
</details>

<details>
<summary>Why <code>Console.WriteLine();</code> after each loop?</summary>

The loops use `Console.Write`, which stays on the same line. The empty `WriteLine` moves the cursor to the next line.
</details>