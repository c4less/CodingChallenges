public class TrieNode
{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;

    public TrieNode()
    {
        children = new();
        isEndOfWord = false;
    }
}

public class Trie
{
    private TrieNode _root;
    public Trie()
    {
        _root = new();
    }
    
    public void Insert(string word)
    {
        TrieNode current = _root;
        foreach (char ch in word)
        {
            if (!current.children.ContainsKey(ch))
            {
                current.children.Add(ch, new());
            }

            current = current.children[ch];
        }
        current.isEndOfWord = true;
    }
    
    public bool Search(string word)
    {
        TrieNode current = _root;
        foreach (char ch in word)
        {
            if (!current.children.ContainsKey(ch))
            {
                return false;
            }

            current = current.children[ch];
        }

        return current.isEndOfWord;
    }
    
    public bool StartsWith(string prefix)
    {
        TrieNode current = _root;
        foreach (char ch in prefix)
        {
            if (!current.children.ContainsKey(ch))
            {
                return false;
            }

            current = current.children[ch];
        }

        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */