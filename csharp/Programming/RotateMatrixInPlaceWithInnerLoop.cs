namespace Programming;

public class RotateMatrixInPlaceWithInnerLoop
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        for (int layer = 0; layer <= n / 2; layer++)
        {
            for (int range = layer; range < n - layer - 1; range++)
            {
                int row = layer;
                int col = range;
                int next = matrix[row][col];
                for (int count = 0; count < 4; count++)
                {
                    int nextRow = col;
                    int nextCol = n - row - 1;
                    int temp = matrix[nextRow][nextCol];
                    matrix[nextRow][nextCol] = next;
                    row = nextRow;
                    col = nextCol;
                    next = temp;
                }
            }
        }
    }
}
