public class Solution {
    public bool IsIsomorphic(string s, string t) {
        Dictionary<char,char> sDict = new();
        
        for(int i=0 ;i<s.Length; i++)
        {
            if(sDict.ContainsKey(s[i]))
            {
                if(sDict[s[i]]!= t[i]) return false;
            }
            else
            {
                if(sDict.ContainsValue(t[i])) return false;
                
                sDict.Add(s[i], t[i]);
            }
        }
        return true;
    }
}