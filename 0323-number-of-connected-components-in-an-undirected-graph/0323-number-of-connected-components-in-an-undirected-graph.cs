public class Solution {
    Dictionary<int, List<int>> componentsDict = new();
    HashSet<int> visited = new();
    public int CountComponents(int n, int[][] edges) {
     
        if(n==1) return n;
        
        for(int i=0; i<n; i++)
        {
            componentsDict.Add(i, new());
        }
        
        foreach(var edge in edges)
        {
            componentsDict[edge[0]].Add(edge[1]);
            componentsDict[edge[1]].Add(edge[0]);
        }
        
        int components =0;
        for(int i=0; i< n; i++)
        {
            if(visited.Contains(i))
            {
                continue;
            }
            else
            {
                visited.Add(i);
                components+=1;
                DFS(i);
            }
        }
        return components;
    }
    
    
    private void DFS(int node)
    {
        foreach(var neighbor in componentsDict[node])
        {
            if(!visited.Contains(neighbor))
            {
                visited.Add(neighbor);   
                DFS(neighbor);
            }
        }
    }
}