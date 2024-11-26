using System;

namespace Programming;

public class ToeplitzMatrix
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        for (int row = 1; row < matrix.Length; row++)
        {
            for (int col = row; col < matrix[0].Length; col++)
            {
                if (matrix[row - 1][col - 1] != matrix[row][col])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool IsToeplitzMatrixLongIteration(int[][] matrix)
    {
        int cols = matrix[0].Length;
        int rows = matrix.Length;
        for (int col = 0; col < cols; col++)
        {
            bool isValid = IsValidDiagonal(matrix, 0, col);
            if (!isValid)
            {
                return false;
            }
        }

        for (int row = 1; row < rows; row++)
        {
            bool isValid = IsValidDiagonal(matrix, row, 0);
            if (!isValid)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsValidDiagonal(int[][] matrix, int row, int col)
    {
        int num = matrix[row][col];
        int cols = matrix[0].Length;
        int rows = matrix.Length;

        while (row < rows && col < cols)
        {
            if (matrix[row][col] != num)
            {
                return false;
            }

            row++;
            col++;
        }

        return true;
    }
}
