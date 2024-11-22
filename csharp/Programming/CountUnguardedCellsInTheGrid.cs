namespace Programming;

public class CountUnguardedCellsInTheGrid
{
    private int[,] _grid;
    int[] _upDir = new int[] { -1, 0 };
    int[] _rightDir = new int[] { 0, 1 };
    int[] _downDir = new int[] { 1, 0 };
    int[] _leftDir = new int[] { 0, -1 };

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        // Grid Cells:
        // 0: never visitted.
        // 1: wall.
        // 2: guard.
        // 3: already guarded seen in a row.
        // 4: already guarded seen in a col.
        _grid = new int[m, n];

        foreach (int[] wall in walls)
        {
            _grid[wall[0], wall[1]] = 1;
        }

        int guardedCount = 0;

        foreach (int[] guard in guards)
        {
            int row = guard[0];
            int col = guard[1];

            if (_grid[row, col] == 3 || _grid[row, col] == 4)
            {
                guardedCount--;
            }

            _grid[row, col] = 2;
            guardedCount += CountGuarded(1, row, col);
            guardedCount += CountGuarded(2, row, col);
            guardedCount += CountGuarded(3, row, col);
            guardedCount += CountGuarded(4, row, col);
        }

        return m * n - guards.Length - walls.Length - guardedCount;
    }

    // dir: 1:up 2:right 3:down 4:left
    private int CountGuarded(int direction, int row, int col)
    {
        int[] dir = null;
        if (direction == 1)
        {
            dir = _upDir;
        }
        else if (direction == 2)
        {
            dir = _rightDir;
        }
        else if (direction == 3)
        {
            dir = _downDir;
        }
        else
        {
            dir = _leftDir;
        }

        row += dir[0];
        col += dir[1];
        int count = 0;

        while (row >= 0 && row < _grid.GetLength(0) && col >= 0 && col < _grid.GetLength(1) &&
            (_grid[row, col] == 0 ||
             (_grid[row, col] == 3 && (direction == 1 || direction == 3)) ||
             (_grid[row, col] == 4 && (direction == 2 || direction == 4))))
        {
            if (_grid[row, col] == 0)
            {
                count++;
                _grid[row, col] = direction == 2 || direction == 4 ? 3 : 4;
            }

            row += dir[0];
            col += dir[1];
        }

        return count;
    }
}
