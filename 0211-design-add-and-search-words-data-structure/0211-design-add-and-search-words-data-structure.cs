//TrieNode class
public class TrieNode
{
    public Dictionary<char,TrieNode> characters;
    public bool isWordEnd;
    
    public TrieNode()
    {
        characters = new();
        isWordEnd = false;
    }
}


public class WordDictionary {

    private TrieNode _root;
    public WordDictionary() {
        _root = new();
    }
    
    public void AddWord(string word) {
        var current = _root;
        foreach(char ch in word)
        {
            if(!current.characters.ContainsKey(ch))
            {
                current.characters.Add(ch, new());
            }
            current = current.characters[ch];
        }
        current.isWordEnd = true;
    }
    
    public bool Search(string word) {
        
        return SearchDFS(0, _root);
        
         bool SearchDFS(int index, TrieNode node)
        {
            var current = node;
            for(int i=index; i < word.Length; i++)
            {
                if(word[i]=='.')
                {
                    foreach(var child in current.characters.Values)
                    {
                        if(SearchDFS(i+1, child))
                        {
                            return true;
                        }  
                    }
                     return false;
                }
                else
                {
                    if(!current.characters.ContainsKey(word[i]))
                    {
                        return false;
                    }
                    current = current.characters[word[i]];
                } 
            }
            return current.isWordEnd;
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */