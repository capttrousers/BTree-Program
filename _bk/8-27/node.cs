
class Node 
{
	public string myValue;
	
	/// these are indexes in the binary tree, must be checked as < depth and not null
	public int leftChild, rightChild, Parent, index;
	public bool hasChildren = false;
	
	public Node(int newIndex)
	{
		index = newIndex;
		myValue = null;
	}
	
	public Node(int newIndex, string newValue)
	{
		index = newIndex;
		myValue = newValue;
	}
	
	public int getleftChild()
	{
		return leftChild;
	}

	public int getrightChild()
	{
		return rightChild;
	}

	public int getParent()
	{
		return Parent;
	}
	
	
	public int getIndex()
	{
		return index;
	}
	
}