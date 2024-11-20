using System;

namespace Programming;

public class DiagonalTraverseImpl2
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat.Length == 0 || mat[0].Length == 0)
        {
            return new int[0];
        }

        int rowLen = mat.Length;
        int colLen = mat[0].Length;

        int row = 0;
        int col = 0;
        bool goingUp = true;
        int index = 0;
        int[] res = new int[mat.Length * mat[0].Length];

        while (index < res.Length)
        {
            if (row < 0 || row >= rowLen || col < 0 || col >= colLen) // Change direction
            {
                if (goingUp)
                {
                    if (col >= colLen)
                    {
                        row += 2;
                        col = colLen - 1;
                    }
                    else
                    {
                        row = 0;
                    }
                }
                else
                {
                    if (row >= rowLen)
                    {
                        row = rowLen - 1;
                        col += 2;
                    }
                    else
                    {
                        col = 0;
                    }
                }

                goingUp = !goingUp;
            }

            res[index] = mat[row][col];
            index++;

            if (goingUp)
            {
                row--;
                col++;
            }
            else
            {
                row++;
                col--;
            }
        }

        return res;
    }
}
