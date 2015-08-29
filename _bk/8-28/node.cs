
class Node 
{
	public string myValue;
	
	/// these are indexes in the binary tree, must be checked as < depth and not null
	/// index is 0 based, depth is 1 based    => depth starts at 1, index starts at 0 for root
	public int leftChild, rightChild, Parent, index, depth;
	public bool hasChildren = false;
	
	public Node(int newIndex)
	{
		index = newIndex;
		myValue = "##";
	}
	
	public Node(int newIndex, string newValue)
	{
		index = newIndex;
		myValue = newValue;
	}
	
	
	/*
	/// unnecessary methods, just use public variables
	
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
	
	public int getdepth()
	{
		return depth;
	}
	*/
}