public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> numDict = new();
        
        for(int i=0; i<nums.Length; i++)
        {
            int diff = target - nums[i];
            if(numDict.ContainsKey(diff))
            {
                return new int[]{numDict[diff], i};
            }
            else if(!numDict.ContainsKey(nums[i]))
            {
                numDict.Add(nums[i],i);
            }
        }
        return new int[]{0,0};
    }
}