public class Solution {
    
        Dictionary<int, List<int>> graphDict = new();
        HashSet<int> visited = new();
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        
        for(int i=0; i< numCourses; i++)
        {
            if(!graphDict.ContainsKey(i))
            {
                graphDict.Add(i, new List<int>());
            }
        }
        
        foreach(var prereq in prerequisites)
        {
            graphDict[prereq[1]].Add(prereq[0]);            
        }
         
       
        for(int course=0; course< numCourses; course++)    
        {
            if(DFS(course)==false){
                return false;
            }
        }
        return true;
    }
            
  
   
      public bool DFS(int course)
    {
        if(visited.Contains(course)) return false;
        if(graphDict[course].Count==0) return true;
        
        visited.Add(course);
        foreach(var depCourse in graphDict[course])
        {
            if(DFS(depCourse)==false){
                return false;
            }
           
        }
        visited.Remove(course);
        graphDict[course]= new();
        return true;
    } 
    
    
                
}