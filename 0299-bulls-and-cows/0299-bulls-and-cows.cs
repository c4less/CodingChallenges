public class Solution {
    public string GetHint(string secret, string guess) {
        int[] bucket = new int[10];
        Array.Fill(bucket,0);
        int bulls =0;
        
       for(int i=0; i< secret.Length; i++)
        {
            if(secret[i] == guess[i])
            {
                bulls+=1;
            }
            else
            {
              bucket[(int)secret[i]-'0'] +=1;
                bucket[(int)guess[i]-'0']-=1;
                
            }
        }
        return $"{bulls}A{secret.Length-bulls -bucket.Where(x=>x > 0).Sum()}B";
    }
}