using System;

namespace Programming;

public class Minesweeper
{
    private int[] _rowDir = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
    private int[] _colDir = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };
    private int _rowsCount;
    private int _colsCount;

    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        int row = click[0];
        int col = click[1];
        char cell = board[row][col];

        if (cell == 'M')
        {
            board[row][col] = 'X';
        }
        else if (cell == 'E')
        {
            _rowsCount = board.Length;
            _colsCount = board[0].Length;
            board[row][col] = 'B';
            RevealBlanks(board, row, col);
        }

        return board;
    }

    private void RevealBlanks(char[][] board, int row, int col)
    {
        int adjMines = CountAdjacentMines(board, row, col);
        if (adjMines > 0)
        {
            board[row][col] = (char)('0' + adjMines);
        }
        else
        {
            board[row][col] = 'B';
            for (int i = 0; i < _rowDir.Length; i++)
            {
                int newRow = row + _rowDir[i];
                int newCol = col + _colDir[i];
                if (newRow >= 0 && newRow < _rowsCount && newCol >= 0 && newCol < _colsCount && board[newRow][newCol] == 'E')
                {
                    board[newRow][newCol] = 'B';
                    RevealBlanks(board, newRow, newCol);
                }
            }
        }
    }

    private int CountAdjacentMines(char[][] board, int row, int col)
    {
        int count = 0;

        for (int i = 0; i < _rowDir.Length; i++)
        {
            int newRow = row + _rowDir[i];
            int newCol = col + _colDir[i];
            if (newRow >= 0 && newRow < _rowsCount && newCol >= 0 && newCol < _colsCount && board[newRow][newCol] == 'M')
            {
                count++;
            }
        }

        return count;
    }
}
