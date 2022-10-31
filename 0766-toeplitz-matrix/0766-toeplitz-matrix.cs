public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        
        for(int row=0; row< matrix.Length; row++)
        {
            for(int col =0; col < matrix[0].Length; col++)
            {
                if(row >=1 && col >=1 && matrix[row][col] != matrix[row-1][col-1])
                {
                    return false;
                } 
            }
        }
        return true;
    }
}