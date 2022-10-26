public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        Dictionary<int, int> numsDict = new Dictionary<int, int>(){ [0]= -1 };
        int total =0;
        
        for(int i=0; i< nums.Length; i++)
        {
            total += nums[i];
            int reminder = total %k;
            if(!numsDict.ContainsKey(reminder))
            {
                numsDict[reminder] = i;
            }
            else if(i- numsDict[reminder] > 1)
            {
                return true;
            }
        }
        return false;
    }
}

/*
1. Initialize a Dictionary<int,int> (remainder, index)
2. Add default value 0 = -1, //this is used to handle edge case if the element modulo is 0, and ensures there are atleast 2 elements by increasing the size of the array.
3. Iterate through the nums in input array
    calculate total +=nums[i];
    calculate reminder = total% k;
        if(!dictionary.ContainsKey(reminder))
            dictionary.Add(reminder, index);
        else if(i-reminder >=2) // length of 2 indices greater than 2
            return true
4. return false;            

*/