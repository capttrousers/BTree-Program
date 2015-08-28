using System;

class Hello
{
	static int Main(string[] args) 
	{
		int n1,n2;
		if(args.Length != 2)
		{
			Console.WriteLine("Proper use of program is [FindParent.exe node1 node2]");
			return 1;
		} 
		else
		{
			bool result = Int32.TryParse(args[0], out n1);
			bool result2 = Int32.TryParse(args[1], out n2);
			if((!result) || (!result2)) 
			{
				Console.WriteLine("Proper use of program is [FindParent.exe node1 node2]");
				Console.WriteLine("Where node1 and node2 are strings of 1 or 2 characters");
				Console.WriteLine("Characters can be UPPPERCASE or lowercase letters or numbers");
				return 1;
			}
		}
		Console.Clear();
		int maxNode = (int)Math.Pow(2, 5) - 1;
		string nodeA = "aa";
		string nodeB = "bb";

        BTree tree = new BTree(maxNode);
		
        // tree = makeTree((int)Math.Log((double)(maxNode + 1), (double)2));
        string input = "";
		int z = 0;
		while (z < 31)
		{
			tree.CurrentInput = z;
			writeTree(tree);
			Console.WriteLine("Please enter a valid string of 2 characters for the node value:");
			while(!(isValidString(input)))
			{
				input = Console.ReadLine();
			}
			tree.updateNode(z, input);
			
			Console.Clear();
			input = "";
			z++;			
		}
		
		
		int indexA = tree.getIndexByValue(nodeA);
		int indexB = tree.getIndexByValue(nodeB);
		if(indexA < 0 || indexB < 0)
		{
			Console.Clear();
			Console.WriteLine("One or both of the provided nodes A and B were not found in the tree");
			return 1;
		}
		tree.NodeA_index = indexA;
		tree.NodeB_index = indexB;
		writeTree(tree);
		Console.WriteLine("Please press enter to find the lowest common parent of the 2 highlighted nodes");
		Console.ReadLine();
		
		tree.lowestCommonParent = tree.findCommonParent();
		Console.Clear();
		writeTree(tree);
		Console.ReadLine();
		
		return 1;
	}

	
	private static void writeTree(BTree newTree)
	{
		BTree tree = newTree;
		int treeCount = 0;
        for(int i = 0; i < 10; i++)
        {
            if(i % 2 != 0)
            {
                Console.WriteLine();
				Console.WriteLine();
            }
            else
            {
                string str = "", text = "", pad = "";
                int nodeCount = (int)(Math.Pow((double)2, (double)(i / 2)));
                int strLength = 64 / nodeCount;
                
				int j = (strLength - 4) / 2;
				

				/// j = padLength
                /// on row 1 (index = 0), nodeCount = 1, strLength = 48, j = 22
                /// on row 2 (index = 2), nodeCount = 2,  strLength = 24, 48/2 = 8, j = 10
                /// on row 5 (index = 8), nodeCount = 16, strLength = 3, 48/16 = 3, j = -1
                while (j > 0) 
                {
                    pad += ' ';
                    j--;
                }
				
                while (nodeCount > 0)
                {
					if(tree.getNode(treeCount).myValue.Length < 2)
					{
						str =  " " + tree.getNode(treeCount).myValue;
					}
					else
					{
						str = tree.getNode(treeCount).myValue;
					}
					
					if(tree.CurrentInput == treeCount)
					{
						str = " __ ";
					} 
					else if (tree.NodeA_index == treeCount || tree.NodeB_index == treeCount)
					{
						str = "[" + str + "]";
					} 
					else if (tree.lowestCommonParent == treeCount)
					{
						str = "*" + str + "*";
					}
					else
					{
						str = " " + str + " ";
					}
					
					
					/// check if node[treeCount] needs marker symbol
					/// by comparing treeCount to list of:
					/// input, lowestParent, nodeA, nodeB
		

		
					
					
					/// switch statement for symbol to wrap node value
					/// 1 = ' ## ' : default for normal nodes with values
					/// 2 = '~##~' : nodes A and B will be marked as children
					/// 3 = '*##*' : least common parent will be marked as Parent
					/// 4 = ' __ ' : selection, for inputing new node values

					
					
					
					text += pad + str + pad;
					treeCount++;
                    nodeCount--;
                }
                Console.WriteLine(text);
            }

        }
				
	}
	
	
	/// add all the BTree helper functions including
	/// depth, leader, indexbyvalue, findparent ()
	
	private static bool isValidString(string str)
	{
		char[] chars = str.ToCharArray();
		if (chars.Length > 2) return false;
		if (chars.Length == 1) return isValidChar(chars[0]);
		return 
		(
			(chars.Length == 2) && 
			(isValidChar(chars[0])) && 
			(isValidChar(chars[1])) 
		);
	}
	
	private static bool isValidChar(char c)
	{
		return 
		(
			   ((int)c >= 48) && ((int)c <= 57) 
			|| ((int)c >= 65) && ((int)c <= 90)
			|| ((int)c >= 97) && ((int)c <= 122) 
		);
	}
	
		
}



class Node 
{
	public string myValue;
	public int index;
	
	/// these are indexes in the binary tree, must be checked as < depth and not null
	/// index is 0 based, depth is 1 based    => depth starts at 1, index starts at 0 for root
	
	/*
	  TO IMPLEMENT
	public int leftChild, rightChild, Parent, depth;
	public bool hasChildren = false;
	
	*/
	
	
	
	
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
	

}




class BTree 
{
	/// tree is an array of Nodes. index is root/top->bottom L->R
	/// for incomplete tree, tree can be loaded with empty nodes with function
	/// tree needs to be loaded @ depth + 1 to check for null
    /// if last >= lastRowLeader : load to depth + 1
	private Node[] tree;
	
	/// set symbol indices:
	/// inputIndex is current node to be input
	/// parentIndex and nodeA and nodeB on last print
	private int inputIndex, parentIndex, nodeA, nodeB;
	
	/// depth = 1, rootIndex = 0, last = 0
	/// if adding, last++, last >= nextRowLeader - 1
	/// int depth = 1, last = 0, rootIndex = 0;

	/// constructor takes max indexed at 1, and makes tree with default nodes
	public BTree(int max)
	{
		inputIndex = parentIndex = nodeA = nodeB = -1;
		tree = new Node[max];
		tree = makeTree(max);
	}
	
	private Node[] makeTree(int max)
    {
        Node[] tree = new Node[max];
        int i = max;
        while(i > 0)
        {
            tree[i - 1] = new Node(i - 1);
            i--;
        }
        return tree;
    }

	
	public Node getNode(int index)
	{
		return this.tree[index];	
	}
	
	public void updateNode(int index, string newValue)
	{
		this.getNode(index).myValue = newValue;
	}
	
	public int CurrentInput
	{
		get
		{
			return inputIndex;
		}
		set
		{
			nodeA = nodeB + parentIndex;
			inputIndex = value;
		}
	}
	
	public int lowestCommonParent
	{
		get
		{
			return parentIndex;
		}
		set
		{
			parentIndex = value;
		}
	}
	
	public int NodeA_index
	{
		get
		{
			return nodeA;
		}
		set
		{
			nodeA = value;
		}
	}
	
	public int NodeB_index
	{
		get
		{
			return nodeB;
		}
		set
		{
			nodeB = value;
		}
	}
	
	
	/*
	
	unnecessary methods
	
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
	
	*/
	
	public int getParentIndex(int index)
	{
		if (index <= 0) return -1;
		if(index - getRowLeaderIndex(index) % 2 == 0)
		{
			/// node is left
			return ( index - 1 ) / 2;
		}
		else 
		{
			/// node is right
			return ( index - 2 ) / 2;
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
	
	/// will return the index of the node with value
	/// will return -1 if the value is not found
	/// call on instance of BTree in Main()
	public int getIndexByValue(string value)
	{
		/// find the index of the node with value
		int index = -1;
		int max = 0;
		while(max < 31)
		{
			if(this.getNode(max).myValue.Equals(value)) return max;
			max++;
		}
		
		return index;
		
	}
	
	/// get row leader index by using index
	public int getRowLeaderIndex(int index)
	{
		int root = 0;
		int rowLeaderIndex = root;
		while( ! ( (index >= rowLeaderIndex) && (index <  ((rowLeaderIndex * 2) + 1) ) ) )
		{
			rowLeaderIndex = (rowLeaderIndex * 2) + 1;
		}
		return rowLeaderIndex;
	}
	

	/// when called, input the return index of getIndexByValue(nodeA.value,)
	/// first check the return values, to see if the value exists in the tree
	public int findCommonParent()
	{
		/// using the indexes of the 2 nodes, start at the index and go up
		/// finding the path to each node by finding the parents. 
		/// compare the paths of node, and find the last common node they share
		/// use 2 arrays of ints, one for each node's path from root
		/// loop through comparing the values. if they are not equal, 
		/// return the index at array[i - 1] for the last common parent node
		/// print out new tree, but on each str add, check to see if that node 
		/// needs a highlight mark

		int indexA = this.nodeA;
		int indexB = this.nodeB;
		if (indexA == indexB) return indexA;
		int[] a = new int[findPath(indexA).Length];
		int[] b = new int[findPath(indexB).Length];
		Console.WriteLine("before findpaths");
		a = findPath(indexA);
		b = findPath(indexB);
		Console.WriteLine("after findpaths");
		Console.WriteLine("a path zero index is :" + a[0]);
		Console.WriteLine("b path zero index is :" + b[0]);
		int lastCommonParentIndex = 0;
		int k = 0;
		while((k + 1 <= a.Length) && (k + 1 <= b.Length) && (a[k] == b[k]) )
		{
			lastCommonParentIndex = a[k];
			k++;
			
		}
		Console.WriteLine("after calculate last common parent");
		return lastCommonParentIndex;
	}
	
	/// returns an array of ints of node indexes in path starting at root
	private int[] findPath(int index)
	{
		int pathLength = 1;
		int x = 0;
		int[] path = new int[5];
		path[0] = index;
		
		
		while (x < 4)
		{
			path[x + 1] = getParentIndex(path[x]);
			if(path[x + 1] == 0) pathLength = x + 2;
			x++;
		}
		int[] finalPath = new int[pathLength];
		int g = 0;
		while (g < pathLength)
		{
			finalPath[g] = path[pathLength - 1 - g];
			g++;
		}
		return finalPath;		
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
	
}
