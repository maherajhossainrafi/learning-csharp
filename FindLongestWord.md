# Find Longest Word

## Quick Answer

> Split the sentence into words with `Split`, assume the first word is the longest, then loop through the rest and replace it whenever a longer word appears.

## 1. Solution Walkthrough
1. Read the sentence with `Console.ReadLine()`.
2. Break it into an array of words using `Split` on the space character. `RemoveEmptyEntries` ignores extra spaces.
3. If there are no words, print a message and stop with `return`.
4. Set `longest` to the first word, `words[0]`.
5. Loop from index 1 to the end. If a word's `Length` is bigger than `longest.Length`, update `longest`.
6. Print `longest`.

Example: `I love programming in C#`
- words: `I`, `love`, `programming`, `in`, `C#`
- start with `I` (length 1)
- `love` (4) is longer, so longest is `love`
- `programming` (11) is longer, so longest is `programming`
- `in` and `C#` are shorter, so nothing changes

Output: `Longest word: programming`

## 2. Problem Title
Find the Longest Word in a Sentence

## 3. Problem Summary
The user types a sentence. The program prints the word with the most characters. If two words tie, the first one is printed.

## 4. Intuition
Think of a line of people where you want to find the tallest. You take the first person as the tallest so far. Then you compare each next person, and whenever someone is taller, they become the new tallest. Here the people are the words, and "taller" means a bigger `Length`. It is the same idea as finding the maximum in a list of numbers.

## 5. Approaches
Split the sentence into words, then run one loop that keeps the longest word seen so far.

## 6. Complexity Analysis
Time is O(n), where n is the length of the sentence, because splitting and the loop each pass over it once. Space is O(n) for the array of words.

## 7. Edge Cases
- Empty sentence or only spaces: no words, so the program prints a message.
- One word: that word is the longest.
- Extra spaces between words: `RemoveEmptyEntries` skips them.
- Tie (`cat dog`): the first word, `cat`, is printed because we only replace on a strictly longer word.
- Punctuation counts as part of a word, so `Hello,` has length 6.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length == 0)
        {
            Console.WriteLine("No words found.");
            return;
        }

        string longest = words[0];

        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Length > longest.Length)
            {
                longest = words[i];
            }
        }

        Console.WriteLine("Longest word: " + longest);
    }
}
```

## 9. Improvements
- To ignore punctuation, add characters like `,` `.` `!` `?` to the `Split` character array, or use `Trim` on each word.
- Use `>=` instead of `>` if you want the last longest word on a tie.

## 10. Mistakes
- Using `sentence.Length` instead of `words[i].Length`, which gives the length of the whole sentence.
- Starting `longest` as an empty string and forgetting the case with no words.
- Writing `words.Length()` or `longest.Length()`. `Length` has no brackets for arrays and strings.
- Using `Split()` with no arguments and expecting it to handle spaces. Give it the space character.

## 11. Learnings
- `Split` breaks a string into an array of smaller strings.
- `string.Length` gives the number of characters.
- Arrays use `words.Length`, and lists use `list.Count`.
- The same "keep the best so far" loop works for numbers and words.

## FAQ

<details>
<summary>What does <code>Split</code> do?</summary>

It cuts a string at every separator character and returns the pieces as an array of strings. Here the separator is a space.
</details>

<details>
<summary>What is <code>StringSplitOptions.RemoveEmptyEntries</code> for?</summary>

If the sentence has two spaces in a row, `Split` would create an empty word. This option removes those empty items.
</details>

<details>
<summary>Why start the loop at index 1?</summary>

Index 0 is already stored in `longest`, so there is nothing new to compare.
</details>

<details>
<summary>What happens when two words have the same length?</summary>

The first one stays, because we only replace when a word is strictly longer.
</details>

<details>
<summary>Why check <code>words.Length == 0</code>?</summary>

If the user types nothing, the array is empty, and reading `words[0]` would crash.
</details>