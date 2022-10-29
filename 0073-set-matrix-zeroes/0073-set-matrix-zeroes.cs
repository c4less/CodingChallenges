public class Solution {
    public void SetZeroes(int[][] matrix) {
        
        for(int i=0; i<matrix.Length; i++){
            for(int j=0; j< matrix[0].Length; j++)
            {
                if(matrix[i][j] ==0){
                    setMatrixZero(matrix, i-1, j, "U");
                    setMatrixZero(matrix, i+1, j, "D");
                    setMatrixZero(matrix, i, j-1, "L");
                    setMatrixZero(matrix, i, j+1, "R");
                }
            }
        }
        
        for(int i=0; i<matrix.Length; i++){
            for(int j=0; j< matrix[0].Length; j++)
            {
                if(matrix[i][j] == Int32.MaxValue-1){
                    matrix[i][j] = 0;
                }
            }
        }
    }
    
    //DFS
    private void setMatrixZero(int[][] matrix, int i, int j, string direction)
    {
        
        if( (i >=0 && i < matrix.Length) &&
            (j >=0 && j < matrix[0].Length) &&
            matrix[i][j]!=0)
        {
            matrix[i][j] =Int32.MaxValue-1;
            
                if(direction =="U")
                   setMatrixZero(matrix, i-1, j, "U");
                else if(direction =="D")
                    setMatrixZero(matrix, i+1, j, "D");
                else if(direction =="L")
                   setMatrixZero(matrix, i, j-1, "L");
                else
                   setMatrixZero(matrix, i, j+1, "R");
        }
    }
    
}