public class TrieNode 
{
    public Dictionary<char, TrieNode> characters;
    public bool isWordEnd;
    
    public TrieNode()
    {
        characters = new();
        isWordEnd = false;
    }
    
    public void AddWordToTrie(TrieNode node, string word)
    {
        var current = node;
        foreach(char ch in word)
        {
            if(!current.characters.ContainsKey(ch))
            {
                current.characters.Add(ch, new());
            }
            current = current.characters[ch];
        }
        current.isWordEnd  = true;
    }
}


public class Solution {
    HashSet<string> result = new();
    HashSet<(int row, int col)> visited = new();
    int maxCol =0, maxRow =0;
    public IList<string> FindWords(char[][] board, string[] words) {
        var root = new TrieNode();
        
        foreach(string word in words)
        {
            root.AddWordToTrie(root, word);
        }
        maxRow = board.Length; 
        maxCol = board[0].Length;
        
        for(int i=0; i< maxRow; i++)
        {
            for(int j=0; j< maxCol; j++)
            {
                DFS(i,j, root, "", board);
            }
        }
        return result.ToList();
    }
    
    private void DFS(int row, int col, TrieNode node, string word, char[][] board)
    {
        //base cases
        if(row < 0 || col < 0 || row == maxRow || col == maxCol ||
           visited.Contains((row, col)) || !node.characters.ContainsKey(board[row][col]))
        {
            return;
        }
        
        visited.Add((row,col));
        
        node = node.characters[board[row][col]];
        word += board[row][col];
        if(node.isWordEnd  && !result.Contains(word))
        {
            result.Add(word);
        }
        DFS(row+1,col, node, word, board);
        DFS(row-1,col, node, word, board);
        DFS(row,col+1, node, word, board);
        DFS(row,col-1, node, word, board);
        
        visited.Remove((row,col));
    }
    
    
}