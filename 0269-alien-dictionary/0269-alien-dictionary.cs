public class Solution {
    Dictionary<char, List<char>> adjList = new(); 
    Dictionary<char, int> indegree = new();
    public string AlienOrder(string[] words) {
        List<char> result = new();
        foreach(string word in words)
        {
            foreach(char ch in word)
            {
                if(!adjList.ContainsKey(ch))
                    adjList.Add(ch, new());
                
                if(!indegree.ContainsKey(ch))
                    indegree.Add(ch, 0);
            }
        }
        
        for(int i=0; i< words.Length-1; i++)
        {
            string w1 = words[i], w2= words[i+1];
            int minLength = Math.Min(w1.Length, w2.Length);
            bool isFound = false;
          for(int j=0; j< minLength; j++)
            {
                if (w1[j] != w2[j])
                {
                    isFound = true;
                    adjList[w1[j]].Add(w2[j]);
                    break;
                }
            } 
            if(!isFound && w1.Length > w2.Length)
            {
                return "";
            }
        }
        
        
        foreach(var letters in adjList.Values)
        {
            foreach(char ch in letters)
            {
                indegree[ch] +=1;
            }
        }
        
        Queue<char> queue = new();
        foreach(var key in indegree.Keys)
        {
            if(indegree[key]==0)
                queue.Enqueue(key);
        }
        
        while(queue.Any())
        {
            char current = queue.Dequeue();
            
            result.Add(current);
            foreach(var letter in adjList[current])
            {
                indegree[letter]-=1;
                if(indegree[letter] ==0) 
                {
                    queue.Enqueue(letter);
                }
            }
        }
        
        return result.Count == indegree.Count ? new string(result.ToArray()) : string.Empty;
    }
}