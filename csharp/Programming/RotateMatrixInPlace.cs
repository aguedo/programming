namespace Programming;

public class RotateMatrixInPlace
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        for (int row = 0; row <= n / 2; row++)
        {
            for (int col = row; col < n - row - 1; col++)
            {
                int temp = matrix[row][col];
                matrix[row][col] = matrix[n - col - 1][row];
                matrix[n - col - 1][row] = matrix[n - row - 1][n - col - 1];
                matrix[n - row - 1][n - col - 1] = matrix[col][n - row - 1];
                matrix[col][n - row - 1] = temp;
            }
        }
    }
}
