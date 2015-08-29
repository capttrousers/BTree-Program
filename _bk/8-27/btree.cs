

class BTree 
{
	/// tree is an array of Nodes. index is root/top->bottom L->R
	/// for incomplete tree, tree can be loaded with empty nodes with function
	/// tree needs to be loaded @ depth + 1 to check for null
    /// if last >= lastRowLeader : load to depth + 1
	Node[] tree;
	
	/// depth = 1, rootIndex = 0, last = 0
	/// if adding, last++, last >= nextRowLeader - 1
	int depth = 1, last = 0, rootIndex = 0;

	public int getdepth()
	{
		return depth;
	}

	public int getdepth(int index)
	{
		int d = depth;
		
		
		return d;
	}
	
	public void addNode(Node parent, string value)
	{
		if (last >= Math.Pow((double)2, (double) (depth - 1) - 1) )
		{
			depth++;
			fillRow(depth);
		}
		if (depth )
			
		
	}
	
	public void fillRow(int newDepth)
	{
		int nodes = (int)(Math.Pow((double)2, (double)(newDepth - 1)));
		for(int i = nodes; i > 0; i--)
		{
			int index = ( nodes - 1 ) + ( nodes - i );
			tree[index] = new Node(index);
		}
	}
}