/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        
        if(node is null) return node;
        
        Dictionary<Node,Node> clonedDict = new();
        clonedDict.Add(node, new Node(node.val, new()));
        
        Queue<Node> queue = new();
        queue.Enqueue(node);
        
        
        while(queue.Any())
        {
            var currentNode = queue.Dequeue();
            foreach(var neighbor in currentNode.neighbors)
            {
                if(!clonedDict.ContainsKey(neighbor))
                {
                    clonedDict.Add(neighbor, new Node(neighbor.val, new()));
                    queue.Enqueue(neighbor);
                }
                clonedDict[currentNode].neighbors.Add(clonedDict[neighbor]);
            }
        }
        return clonedDict[node];
    }
}