public class Solution {
    Dictionary<char, List<char>> wordGraph = new();
    Dictionary<char, int> indegree = new();
    
    public string AlienOrder(string[] words) {
        
        foreach(string word in words)
        {
            foreach(char ch in word)
            {
                if(!wordGraph.ContainsKey(ch))
                    wordGraph.Add(ch, new());
                
                if(!indegree.ContainsKey(ch))
                    indegree.Add(ch, 0);
            }
        }
        
        
         for(int i=0; i< words.Length-1; i++)
        {
            string w1 = words[i], w2= words[i+1];
            int minLength = Math.Min(w1.Length, w2.Length);
            
            if(w1.Length > w2.Length && w1[..minLength] == w2[..minLength])
            {
                return string.Empty;
            }
            for(int j=0; j< minLength; j++)
            {
                if (w1[j] != w2[j])
                {
                    wordGraph[w1[j]].Add(w2[j]);
                    break;
                }
            } 
        }
        
               
        Queue<char> queue = new();
        StringBuilder sb = new();
        
         foreach(var letters in wordGraph.Values)
        {
            foreach(char ch in letters)
            {
                indegree[ch] +=1;
            }
        }
        
        foreach(var key in indegree.Keys)
        {
            if(indegree[key]==0)
                queue.Enqueue(key);
        }
        
        
        while(queue.Any())
        {
            char current = queue.Dequeue();
            sb.Append(current);
            
            foreach(char ch in wordGraph[current])
            {
                indegree[ch]-=1;
                if(indegree[ch]==0)
                {
                    queue.Enqueue(ch);
                }
            }
        }
        
        return indegree.Count== sb.Length ? sb.ToString(): string.Empty;
    }
}