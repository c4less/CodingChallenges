/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class BSTIterator {

    private TreeNode _root;
    private List<int> _list;
    private int index =-1;
    
    public BSTIterator(TreeNode root) {
        _list = new();
        _root = root;
        InOrder(root);
    }
    
    private void InOrder(TreeNode node)
    {
        if(node is null) return;
        
        InOrder(node.left);
        _list.Add(node.val);
        InOrder(node.right);
    }
    
    public bool HasNext() {
        return index+1 < _list.Count;
    }
    
    public int Next() {
        return _list[++index];
    }
    
    public bool HasPrev() {
        return index-1 >= 0;
    }
    
    public int Prev() {
        return _list[--index];
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * bool param_1 = obj.HasNext();
 * int param_2 = obj.Next();
 * bool param_3 = obj.HasPrev();
 * int param_4 = obj.Prev();
 */