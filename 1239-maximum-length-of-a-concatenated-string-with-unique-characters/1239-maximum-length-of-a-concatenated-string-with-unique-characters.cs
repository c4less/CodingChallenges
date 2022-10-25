public class Solution {
      
    public int MaxLength(IList<string> arr) {
        int result =0;
        CalculateMaxLength(0,"");
        return result;
        
        
        void CalculateMaxLength(int index, string current)
        {
            if(index >= arr.Count && checkStringLength(current) > result)
            {
                result =current.Length;
                return;
            }
            if(index >= arr.Count)
            {
                return;
            }

            CalculateMaxLength(index+1, string.Concat(current, arr[index]));
            CalculateMaxLength(index+1, current);
        }
    }
    
       
    private int checkStringLength(string str)
    {
        HashSet<char> chSet = new();
        foreach(char ch in str)
        {
            if(!chSet.Contains(ch))
            {
                chSet.Add(ch);
            }
            else
            {
                return -1;
            }
        }
        return str.Length;
    }
    
}