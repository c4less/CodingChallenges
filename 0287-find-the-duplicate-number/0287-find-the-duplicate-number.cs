public class Solution {
    public int FindDuplicate(int[] nums) {
     HashSet<int> numSet = new();
        
        for(int i=0; i< nums.Length; i++)
        {
            if(numSet.Contains(nums[i]))
            {
                return nums[i];
            }
            else
            {
                numSet.Add(nums[i]);
            }
        }
        return -1;
    }
}