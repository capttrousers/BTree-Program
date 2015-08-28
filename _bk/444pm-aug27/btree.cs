

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
	
	
	
	
	public int getParentIndex(int index)
	{
		/// calculate parent index of a node
		
		
	}
	
	public int getLeftChildIndex(int index)
	{
		/// calculate index of left child
	}
	
	public int getRightChildIndex(int index)
	{
		/// just calculate the left child's index and add 1
		return getLeftChildIndex(index) + 1;
	}
	
	
	public int findCommonParent(int indexA, int indexB)
	{
		/// using the indexes of the 2 nodes, start at the root and go down
		/// finding the path to each node. compare the paths of node,
		/// and find the last common node they share
		/// use 2 arrays of ints, one for each node's path from root
		/// loop through comparing the values. if they are not equal, 
		/// return the index at array[i - 1] for the last common parent node
		/// print out new tree, but on each str add, check to see if that node 
		/// needs a highlight mark
	}
	
	public int getIndexByValue(string value)
	{
		///
	}
	
	
	
	
}