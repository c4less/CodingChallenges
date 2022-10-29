public class Solution {
    // Time: O(n) | Space: O(1)
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        Array.Fill(result, 1);
        
        int currentProd =1;
        for(int i =0; i< nums.Length; i++)
        {
            result[i]*= currentProd;
            currentProd *= nums[i];
        }
        currentProd =1;
        for(int i= nums.Length-1; i>=0; i--)
        {
            result[i] *= currentProd;
            currentProd *= nums[i];
        }
        return result;
    }
}