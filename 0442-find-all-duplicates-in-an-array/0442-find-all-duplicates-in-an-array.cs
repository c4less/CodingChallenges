public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        List<int> dups = new();
        if(nums.Length ==0) return dups;
        
        HashSet<int> numSet = new();
        for(int i=0; i< nums.Length; i++)
        {
            if(!numSet.Contains(nums[i]))
            {
                numSet.Add(nums[i]);
            }
            else
            {
                dups.Add(nums[i]);
            }
        }
        return dups;
    }
}