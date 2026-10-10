# Find Quadrant

## Quick Answer

> First rule out the special cases (the origin and the two axes), then use the signs of `x` and `y` to pick the quadrant. Whatever is left after the first three quadrants is the fourth.

## 1. Solution Walkthrough
1. Read `x` and `y`.
2. If both are 0, print "Origin".
3. If only `x` is 0, the point is on the Y axis. If only `y` is 0, it is on the X axis.
4. If `x > 0` and `y > 0`, print "First Quadrant".
5. If `x < 0` and `y > 0`, print "Second Quadrant".
6. If `x < 0` and `y < 0`, print "Third Quadrant".
7. Otherwise `x > 0` and `y < 0`, so print "Fourth Quadrant".

Examples:
- `(3, 4)` gives First Quadrant.
- `(-2, 5)` gives Second Quadrant.
- `(-1, -1)` gives Third Quadrant.
- `(6, -2)` gives Fourth Quadrant.
- `(0, 5)` gives On the Y axis.

## 2. Problem Title
Find the Quadrant of a Point

## 3. Problem Summary
Read the coordinates `x` and `y` of a point and print which quadrant it lies in. A point on an axis or at the origin is not in any quadrant, so print that instead.

## 4. Intuition
Think of a map divided into four rooms by two crossing walls. The wall lines themselves belong to no room. To find a point's room, you only need two yes-or-no answers: is `x` positive or negative (right or left), and is `y` positive or negative (up or down)? Check for the walls first, then the signs tell you the room.

## 5. Approaches
An `if / else if / else` chain that tests the special cases first and then the signs.

## 6. Complexity Analysis
Time is O(1) and space is O(1), because there are only a few comparisons.

## 7. Edge Cases
- `(0, 0)`: Origin.
- `(0, 5)` or `(0, -3)`: on the Y axis.
- `(4, 0)` or `(-4, 0)`: on the X axis.
- Negative values in both: Third Quadrant.
- Large values work the same, since only the signs matter.

## 8. Implementations
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter y: ");
        int y = int.Parse(Console.ReadLine());

        if (x == 0 && y == 0)
        {
            Console.WriteLine("Origin");
        }
        else if (x == 0)
        {
            Console.WriteLine("On the Y axis");
        }
        else if (y == 0)
        {
            Console.WriteLine("On the X axis");
        }
        else if (x > 0 && y > 0)
        {
            Console.WriteLine("First Quadrant");
        }
        else if (x < 0 && y > 0)
        {
            Console.WriteLine("Second Quadrant");
        }
        else if (x < 0 && y < 0)
        {
            Console.WriteLine("Third Quadrant");
        }
        else
        {
            Console.WriteLine("Fourth Quadrant");
        }
    }
}
```

## 9. Improvements
- Write the last branch as `else if (x > 0 && y < 0)` if you prefer every case to be spelled out. It gives the same result.
- Use `double.Parse` if coordinates can have decimals.

## 10. Mistakes
- Ending the chain with `else` that prints "Origin", which wrongly labels every axis point as the origin.
- Checking `x >= 0` or `y >= 0`, which pulls axis points into a quadrant.
- Using `||` instead of `&&`. A quadrant needs both signs to match.
- Extra spaces inside the printed text, such as `" Fourth Quadrant"`, which can fail an output check.

## 11. Learnings
- `&&` means both conditions must be true.
- Handle special cases first, then the general cases.
- Use `==` to compare and `=` to assign.
- The last `else` catches only what the earlier checks left over, so make sure the earlier checks cover everything else.

## FAQ

<details>
<summary>Why check the origin and axes first?</summary>

Points on an axis have a zero coordinate, and they are not in any quadrant. Checking them first keeps them out of the quadrant checks.
</details>

<details>
<summary>Why can the last <code>else</code> be Fourth Quadrant?</summary>

By then every other case has been ruled out, so the only combination left is `x > 0` and `y < 0`.
</details>

<details>
<summary>What is the difference between <code>=</code> and <code>==</code>?</summary>

`=` assigns a value. `==` compares two values and gives true or false.
</details>

<details>
<summary>Why <code>&amp;&amp;</code> and not <code>||</code>?</summary>

A quadrant depends on both signs together. `||` would accept a point that matches only one sign.
</details>

<details>
<summary>Which quadrant is which?</summary>

First is top right (+, +), Second is top left (−, +), Third is bottom left (−, −), and Fourth is bottom right (+, −).
</details>