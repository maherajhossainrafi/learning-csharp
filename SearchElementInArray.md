# Search Element in Array

## Quick Answer

> Read the array and the number to search for (the key), then loop through the array. If any item equals the key, set a `found` flag to true and stop with `break`. Print the result using the flag.

## 1. Solution Walkthrough
1. Read `n` and fill an array with `n` numbers.
2. Read the number to search for into `key`.
3. Set `found` to `false`.
4. Loop through the array. If `arr[i] == key`, set `found` to `true` and `break`.
5. After the loop, print "Element is found" if `found` is true, otherwise print "Element is not found".

Example: array `4 9 2 7`, key `2`
- 4 is not 2, 9 is not 2
- 2 equals 2, so `found` becomes true and the loop stops

Output: `Element is found`

## 2. Problem Title
Search an Element in an Array

## 3. Problem Summary
Read N numbers into an array, then read a value to look for. Print whether that value exists in the array. This method is called linear search.

## 4. Intuition
Think of looking for a book on a shelf with no order. You check the books one at a time from the left. The moment you see the book you want, you stop looking. If you reach the end of the shelf without finding it, the book is not there. The `found` flag is your memory of whether you spotted it.

## 5. Approaches
Linear search: check every element one by one from the start. It works on any array, sorted or not.

## 6. Complexity Analysis
Time is O(n) in the worst case, when the key is last or missing. Space is O(1) extra.

## 7. Edge Cases
- Key at the first position: found immediately, and the loop stops after one check.
- Key at the last position: every element is checked.
- Key not in the array: prints "Element is not found".
- Duplicates of the key: the first match stops the loop, which is fine.
- `n = 0`: the loop does not run, so it prints "Element is not found".
- Negative `n` crashes at `new int[n]`.

## 8. Implementations
```csharp
using System;

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

        Console.Write("Enter the element to search: ");
        int key = int.Parse(Console.ReadLine());
        bool found = false;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == key)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            Console.WriteLine("Element is found");
        }
        else
        {
            Console.WriteLine("Element is not found");
        }
    }
}
```

## 9. Improvements
- Print the position too: add `int position = -1;` and set `position = i;` when the key matches, then print `position + 1` if it is not -1.
- `Array.IndexOf(arr, key)` gives the position in one line (or -1). The loop version shows the logic, so keep it for the lab.

## 10. Mistakes
- Printing "not found" inside the loop for every item that does not match. Decide only after the loop ends.
- Setting `found = false` inside the loop, which erases a match.
- Using `=` instead of `==` in the comparison.
- Forgetting `break`. The answer stays correct, but the loop does extra work.

## 11. Learnings
- Linear search checks every item one by one.
- A `bool` flag remembers whether something happened in a loop.
- `break` leaves the loop as soon as the answer is known.
- Decide the final message after the loop, not inside it.

## FAQ

<details>
<summary>What is the <code>found</code> flag for?</summary>

It remembers whether the key was seen. It starts as `false` and becomes `true` at the first match.
</details>

<details>
<summary>Why print the result after the loop?</summary>

We can only say "not found" after checking every item. Printing inside the loop would print the message for each non-matching item.
</details>

<details>
<summary>What does <code>break</code> do?</summary>

It ends the loop immediately, because once the key is found there is no need to check the rest.
</details>

<details>
<summary>What is linear search?</summary>

It checks each element in order until it finds the key or reaches the end.
</details>

<details>
<summary>Is there a faster way?</summary>

Binary search is faster, but it needs a sorted array. For a basic lab, linear search is the standard answer.
</details>