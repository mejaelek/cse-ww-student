public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size)
    {
        PermutationsChooseHelper(results, "", letters, size);
    }

    private static void PermutationsChooseHelper(List<string> results, string curr, string letters, int size)
    {
        if (curr.Length == size) { results.Add(curr); return; }
        foreach (char letter in letters)
            if (!curr.Contains(letter))
                PermutationsChooseHelper(results, curr + letter, letters, size);
    }

    public static decimal CountWaysToClimb(int s)
    {
        return CountWaysToClimbMemo(s, new Dictionary<int, decimal>());
    }

    private static decimal CountWaysToClimbMemo(int s, Dictionary<int, decimal> memo)
    {
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;
        if (memo.TryGetValue(s, out decimal cached)) return cached;
        decimal result = CountWaysToClimbMemo(s - 1, memo)
                       + CountWaysToClimbMemo(s - 2, memo)
                       + CountWaysToClimbMemo(s - 3, memo);
        memo[s] = result;
        return result;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx == -1) { results.Add(pattern); return; }
        WildcardBinary(pattern[..idx] + "0" + pattern[(idx + 1)..], results);
        WildcardBinary(pattern[..idx] + "1" + pattern[(idx + 1)..], results);
    }

    public static void SolveMaze(List<string> results, Maze maze)
    {
        SolveMazeHelper(results, maze, 0, 0, new List<ValueTuple<int, int>>());
    }

    private static void SolveMazeHelper(List<string> results, Maze maze, int x, int y, List<ValueTuple<int, int>> currPath)
    {
        currPath.Add((x, y));
        if (maze.IsEnd(x, y))
            results.Add(currPath.AsString());
        else
        {
            int[,] dir = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int d = 0; d < 4; d++)
            {
                int nx = x + dir[d, 0], ny = y + dir[d, 1];
                if (maze.IsValidMove(currPath, nx, ny))
                    SolveMazeHelper(results, maze, nx, ny, currPath);
            }
        }
        currPath.RemoveAt(currPath.Count - 1);
    }
}
