using System;

namespace Programming;

public class RotatingTheBox
{
    public char[][] RotateTheBox(char[][] box)
    {
        PushRight(box);
        return Rotate(box);
    }

    private char[][] Rotate(char[][] box)
    {
        int newRowsLen = box[0].Length;
        int newColsLen = box.Length;
        char[][] res = new char[newRowsLen][];

        for (int row = 0; row < newRowsLen; row++)
        {
            res[row] = new char[newColsLen];
        }

        for (int row = 0; row < box.Length; row++)
        {
            for (int col = 0; col < box[0].Length; col++)
            {
                int newRow = col;
                int newCol = newColsLen - row - 1;
                res[newRow][newCol] = box[row][col];
            }
        }

        return res;
    }

    private void PushRight(char[][] box)
    {
        int rowsLen = box.Length;
        int colsLen = box[0].Length;
        for (int row = 0; row < rowsLen; row++)
        {
            int shift = 0;
            for (int col = colsLen - 1; col >= 0; col--)
            {
                char c = box[row][col];
                if (c == '.')
                {
                    shift++;
                }
                else if (c == '*')
                {
                    shift = 0;
                }
                else if (shift > 0)
                {
                    box[row][col + shift] = c;
                    box[row][col] = '.';
                }
            }
        }
    }
}
