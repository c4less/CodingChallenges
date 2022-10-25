public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) =>
         string.Join("",word1).Equals(string.Join("",word2));
  
}