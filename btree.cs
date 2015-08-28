

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
	
		
	
	public int getParentIndex(Node node)
	{
		/// calculate parent index of a node
		int index = node.index;
		if(index - getRowLeaderIndex(node) % 2 == 0)
		{
			/// node is left  -> ( index - 1 ) / 2
		}
		else 
		{
			/// node is right -> ( index - 2 ) / 2
		}
		
	}
	
	public int getLeftChildIndex(Node node)
	{
		/// calculate index of left child
		int index = node.index;
		return (index * 2) + 1;
	}
	
	public int getRightChildIndex(Node node)
	{
		/// just calculate the left child's index and add 1
		return getLeftChildIndex(node) + 1;
	}
	
	
	public int findCommonParent(int indexA, int indexB)
	{
		/// using the indexes of the 2 nodes, start at the index and go up
		/// finding the path to each node by finding the parents. 
		/// compare the paths of node, and find the last common node they share
		/// use 2 arrays of ints, one for each node's path from root
		/// loop through comparing the values. if they are not equal, 
		/// return the index at array[i - 1] for the last common parent node
		/// print out new tree, but on each str add, check to see if that node 
		/// needs a highlight mark
		int[] a = int[10];
		int[] b = int[10];
		
		if (indexA == indexB) return indexA;
		int x = 1;
		if ()
		
		
	}
	
	
	
	
	
	
	/// will return the index of the node with value
	/// will return -1 if the value is not found
	public int getIndexByValue(Node[] t, string value)
	{
		/// find the index of the node with value
		int index = -1;
		int max = 0;
		while(max < 31)
		{
			if(t[max].myValue.Equals(value)) index = max;
			max--;
		}
		
		return index;
		
	}
	
	
	public int calculateDepth(Node node)
	{
		int index = node.index;
		int root = 0;
		int rowLeaderIndex = root;
		int depth = root + 1;
		
		while(! ( (index >= rowLeaderIndex) && (index <  ((rowLeaderIndex * 2) + 1) ) ))
		{
			rowLeaderIndex = (rowLeaderIndex * 2) + 1;
			depth++;
		}
		return depth;
	}
	
	
	
	/// get row leader index by using index
	public int getRowLeaderIndex(Node node)
	{
		int index = node.index
		int root = 0;
		int rowLeaderIndex = root;
		while( ! ( (index >= rowLeaderIndex) && (index <  ((rowLeaderIndex * 2) + 1) ) ) )
		{
			rowLeaderIndex = (rowLeaderIndex * 2) + 1;
		}
		return rowLeaderIndex
		
		/*
		/// this can get the row leader index by depth
		int depth = node.depth;
		return (int) Math.Pow((double) 2, (double) depth) - 1;
		
		*/
	}
	
	
	
}