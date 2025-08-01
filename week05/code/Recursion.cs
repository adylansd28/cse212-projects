using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate permutations of length 'size' using recursion.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if the word length equals the desired size, add to results.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: iterate through letters and build permutations.
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1); // Remove current letter
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Count ways to climb stairs with memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s < 0) return 0;
        if (s == 0) return 1;

        // Check memoization
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive calculation with memoization
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Generate all binary strings from a wildcard pattern using recursion.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcards left, add pattern as is.
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace '*' with '0' and '1' and recurse.
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// Problem 5: Solve maze recursively (DFS) and record all paths to the end.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add current position to path
        currPath.Add((x, y));

        // Check if we've reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // Backtrack
            return;
        }

        // Possible moves: right, left, down, up
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (maze.IsValidMove(currPath, newX, newY))
                SolveMaze(results, maze, newX, newY, currPath);
        }

        // Backtrack: remove last position before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}