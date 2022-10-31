public class Solution {
    Dictionary<int, List<int>> courseDict = new();
    HashSet<int> visited = new();
    
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        
        for(int course =0; course < numCourses; course++)
        {
            courseDict.Add(course, new());
        }
        
        foreach(var preReq in prerequisites)
        {
            courseDict[preReq[0]].Add(preReq[1]);
        }
        
        for(int i=0; i< numCourses; i++)
        {
            if(!isNonCyclic(i))
            {
                return false;
            }
        }
        return true;
    }
    
    private bool isNonCyclic(int course)
    {
        if(visited.Contains(course)) return false;
        if(courseDict[course].Count ==0) return true;
        
        visited.Add(course);
        foreach(var depCourse in courseDict[course])
        {
            if(!isNonCyclic(depCourse))
            {
                return false;
            }
        }
        visited.Remove(course);
        courseDict[course] = new();
        return true;
    }
    
    
}