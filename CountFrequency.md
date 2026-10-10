# Count Frequency

## Quick Answer

> Read the numbers into an array, then use a `Dictionary<int, int>` where the key is the number and the value is its count. For each number, add 1 to its count, or set it to 1 if it is new.

## 1. Solution Walkthrough
1. Read `n` and fill an array of size `n`.
2. Create an empty dictionary called `freq`.
3. For each number `x` in the array:
   - If `freq` already has `x` as a key, increase its value by 1.
   - Otherwise, add `x` with a value of 1.
4. Loop through the dictionary and print each key and its count.

Example: input `4 7 4 2 7 4` gives `4 : 3`, `7 : 2`, `2 : 1`.

## 2. Problem Title
Count the Frequency of Each Number

## 3. Problem Summary
Read N integers and print every distinct number along with how many times it appeared.

## 4. Intuition
Think of a tally sheet at an election. Each candidate has a row. When a vote comes in, you find the candidate's row and add one mark. If the candidate has no row yet, you create one with a single mark. The dictionary is the tally sheet: the key is the candidate and the value is the number of marks.

## 5. Approaches
One approach is enough: a dictionary that stores counts. (Nested loops that count each number also work, but they are longer and repeat work.)

## 6. Complexity Analysis
Time is O(n), because each number needs one dictionary lookup on average. Space is O(k), where k is the number of distinct numbers.

## 7. Edge Cases
- All numbers equal (`5 5 5`): the output is `5 : 3`.
- All numbers different: every count is 1.
- `n = 1`: the output is one line with a count of 1.
- `n = 0`: nothing is printed.
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

        foreach (KeyValuePair<int, int> pair in freq)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
```

## 9. Improvements
- `freq[x]++` is a shorter way to write `freq[x] = freq[x] + 1`. Both are correct.
- Add an `if (n < 0)` check to avoid the crash on negative input.

## 10. Mistakes
- Writing `freq[x] = freq[x] + 1` without checking `ContainsKey` first. A missing key throws a `KeyNotFoundException`.
- Using `Add(x, 1)` on a key that already exists, which throws an error. Use `freq[x] = ...` or check first.
- Using the wrong type in the `foreach`. A dictionary gives `KeyValuePair<int, int>`, not `int`.
- Forgetting `using System.Collections.Generic;`.

## 11. Learnings
- A `Dictionary<TKey, TValue>` stores key and value pairs.
- `ContainsKey(x)` checks whether a key exists.
- `freq[x]` reads or sets the value for key `x`.
- `pair.Key` and `pair.Value` give the two parts of each entry.
- A dictionary is the standard tool for counting.

## FAQ

<details>
<summary>Why check <code>ContainsKey</code> first?</summary>

Reading `freq[x]` for a key that does not exist throws an error, so we check before adding to the count.
</details>

<details>
<summary>What is <code>KeyValuePair&lt;int, int&gt;</code>?</summary>

It is one entry of the dictionary. `pair.Key` is the number and `pair.Value` is its count.
</details>

<details>
<summary>Why a dictionary and not an array?</summary>

Numbers can be negative or very large, so they cannot be used as array positions. A dictionary accepts any number as a key.
</details>

<details>
<summary>Will the output follow the input order?</summary>

Usually yes for a plain dictionary, since entries are listed in the order they were added. But C# does not guarantee this, so do not depend on it.
</details>

<details>
<summary>What does <code>freq[x] = 1;</code> do for a new number?</summary>

It creates a new entry with key `x` and value 1.
</details>