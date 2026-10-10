# Count Each Duplicate Element

## Quick Answer

> Count how many times every number appears using a `Dictionary<int, int>`, then print only the numbers whose count is greater than 1.

## 1. Solution Walkthrough
1. Read `n` and fill an array with `n` numbers.
2. Create an empty dictionary `freq`. The key is the number and the value is how many times it appeared.
3. For each number `x`: if `freq` already has `x`, add 1 to its count, otherwise set its count to 1.
4. Set a flag `found` to `false`.
5. Loop through the dictionary. If a count is greater than 1, print the number and its count, and set `found` to `true`.
6. If `found` is still `false`, print that there are no duplicates.

Example: `4 7 4 2 7 4 9`
- counts: 4 is 3, 7 is 2, 2 is 1, 9 is 1
- only 4 and 7 have a count above 1

Output:
```
4 appears 3 times
7 appears 2 times
```

## 2. Problem Title
Count Each Duplicate Element in an Array

## 3. Problem Summary
Read N numbers and print every number that appears more than once, along with how many times it appears. If nothing repeats, print a message.

## 4. Intuition
Think of a tally sheet at an election. Every vote adds a mark next to a candidate's name. When the counting is done, you only announce the candidates who got more than one vote. The dictionary is the tally sheet, and the `pair.Value > 1` check is the announcement filter.

## 5. Approaches
Count with a dictionary, then filter the counts. (Another way is to sort the array and count runs of equal numbers, but the dictionary is simpler to remember.)

## 6. Complexity Analysis
Time is O(n), because each number needs one dictionary lookup on average. Space is O(k), where k is the number of distinct numbers.

## 7. Edge Cases
- No duplicates (`1 2 3`): prints "No Duplicates found!".
- All equal (`4 4 4`): prints `4 appears 3 times`.
- `n = 0` or `n = 1`: prints "No Duplicates found!".
- Negative numbers work fine as keys.
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

        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int x in arr)
        {
            if (freq.ContainsKey(x))
            {
                freq[x] = freq[x] + 1;
            }
            else
            {
                freq[x] = 1;
            }
        }

        bool found = false;

        foreach (KeyValuePair<int, int> pair in freq)
        {
            if (pair.Value > 1)
            {
                Console.WriteLine(pair.Key + " appears " + pair.Value + " times");
                found = true;
            }
        }

        if (found == false)
        {
            Console.WriteLine("No Duplicates found!");
        }
    }
}
```

## 9. Improvements
- Add `Array.Sort(arr);` before counting if you want the numbers printed in order. Dictionaries usually list entries in the order they were added, but C# does not guarantee it.
- Use `freq[x]++` as a shorter form of `freq[x] = freq[x] + 1`.

## 10. Mistakes
- Printing every entry, not only those with `pair.Value > 1`, which also shows numbers that appear once.
- Forgetting the `found` flag, so nothing is printed when there are no duplicates.
- Reading `freq[x]` before checking `ContainsKey`, which throws a `KeyNotFoundException`.
- Setting `found = false` inside the loop, which erases an earlier result.

## 11. Learnings
- A `Dictionary<TKey, TValue>` stores pairs, and `pair.Key` and `pair.Value` give the two parts.
- Counting first and filtering second keeps the logic simple.
- A `bool` flag remembers whether something happened inside a loop.
- `ContainsKey(x)` must be checked before adding to an existing count.

## FAQ

<details>
<summary>Why check <code>pair.Value &gt; 1</code>?</summary>

A count of 1 means the number appeared only once, so it is not a duplicate.
</details>

<details>
<summary>What is the <code>found</code> flag for?</summary>

It tells us after the loop whether at least one duplicate was printed. If not, we print the "No Duplicates found!" message.
</details>

<details>
<summary>Why check <code>ContainsKey</code> first?</summary>

Reading `freq[x]` for a key that does not exist throws an error, so we check before adding to the count.
</details>

<details>
<summary>How is this different from the Count Duplicate Elements problem?</summary>

That one prints a single total of extra copies. This one prints each duplicated number with its own count.
</details>

<details>
<summary>Will the numbers print in input order?</summary>

Usually yes, but C# does not guarantee it for a dictionary. Sort the array first if the order matters.
</details>