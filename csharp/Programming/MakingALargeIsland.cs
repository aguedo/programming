namespace Programming;

public class MakingALargeIsland
{
    private Counter[,] _memory;
    private int[][] _grid;
    private int _len;
    private int[] _rowDir = new int[] { -1, 0, 1, 0 };
    private int[] _colDir = new int[] { 0, 1, 0, -1 };

    public int LargestIsland(int[][] grid)
    {
        _len = grid.Length;
        _grid = grid;
        _memory = new Counter[_len, _len];

        // Fill memory.
        for (int row = 0; row < _len; row++)
        {
            for (int col = 0; col < _len; col++)
            {
                if (grid[row][col] == 1 && _memory[row, col] == null)
                {
                    DFS(row, col, new Counter());
                }
            }
        }

        // Find largest after union
        int largest = 0;
        for (int row = 0; row < _len; row++)
        {
            for (int col = 0; col < _len; col++)
            {
                int size = 0;
                if (grid[row][col] == 0)
                {
                    HashSet<Counter> counters = new HashSet<Counter>();
                    for (int i = 0; i < _rowDir.Length; i++)
                    {
                        int rDir = _rowDir[i];
                        int cDir = _colDir[i];

                        int newRow = row + rDir;
                        int newCol = col + cDir;
                        if (newRow >= 0 && newRow < _len && newCol >= 0 && newCol < _len && _memory[newRow, newCol] != null)
                        {
                            counters.Add(_memory[newRow, newCol]);
                        }
                    }

                    size++; // Adding the connection.
                    foreach (Counter counter in counters)
                    {
                        size += counter.Count;
                    }
                }
                else
                {
                    size = _memory[row, col].Count;
                }

                if (size > largest)
                {
                    largest = size;
                }
            }
        }

        return largest;
    }

    private void DFS(int row, int col, Counter counter)
    {
        counter.Count++;
        _memory[row, col] = counter;

        for (int i = 0; i < _rowDir.Length; i++)
        {
            int rDir = _rowDir[i];
            int cDir = _colDir[i];

            int newRow = row + rDir;
            int newCol = col + cDir;
            if (newRow >= 0 && newRow < _len && newCol >= 0 && newCol < _len &&
                _grid[newRow][newCol] == 1 && _memory[newRow, newCol] == null)
            {
                DFS(newRow, newCol, counter);
            }
        }
    }

    class Counter
    {
        public int Count { get; set; }
    }
}
