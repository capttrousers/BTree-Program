using System;

class  Test 
{
	
	static void Main()
	{
		int[] tree = new int[31];
		int nodeA = 8;
		int nodeB = 30;
		int x = 0;
		while (x < 31) 	
		{
			tree[x] = x;
			x++;
		}

		int text = findCommonParent(nodeA, nodeB);
		
		Console.WriteLine("nodeA index is: " + nodeA);
		Console.WriteLine("nodeB index is: " + nodeB);
		Console.WriteLine(text);
		Console.ReadLine();
	}
	
	
	private static int findCommonParent(int nA, int nB)
	{
		/// using the indexes of the 2 nodes, start at the index and go up
		/// finding the path to each node by finding the parents. 
		/// compare the paths of node, and find the last common node they share
		/// use 2 arrays of ints, one for each node's path from root
		/// loop through comparing the values. if they are not equal, 
		/// return the index at array[i - 1] for the last common parent node
		/// print out new tree, but on each str add, check to see if that node 
		/// needs a highlight mark

		int indexA = nA;
		int indexB = nB;
		
		if (indexA == indexB) return indexA;
		
		int[] a = new int[findPath(indexA).Length];
		int[] b = new int[findPath(indexB).Length];
		
		// Console.WriteLine("before findpaths");
		
		a = findPath(indexA);
		b = findPath(indexB);
		
		// Console.WriteLine("after findpaths");
		// Console.WriteLine("a path zero index is :" + a[0]);
		// Console.WriteLine("b path zero index is :" + b[0]);
		
		int lastCommonParentIndex = 0;
		int k = 0;
		
		while((k + 1 <= a.Length) && (k + 1 <= b.Length) && (a[k] == b[k]) )
		{
			Console.WriteLine("k = " + k);
			Console.WriteLine("nodeA has path at k of node = " + a[k]);
			Console.WriteLine("nodeB has path at k of node = " + b[k]);
			lastCommonParentIndex = a[k];
			k++;
			
		}
		// Console.WriteLine("after calculate last common parent");
		return lastCommonParentIndex;
	}
	
	/***********************
	
	Console.WriteLine("");
	
	************************/
	
	private static int[] findPath(int index)
	{
		int pathLength = 1;
		int x = 0;
		int[] path = new int[5];
		path[0] = index;
		Console.WriteLine("index of node for findpath = " + index);
		
		while (x < 4)
		{
			Console.WriteLine("first loop in findpath, before iteration x = " + x);
			path[x + 1] = getParentIndex(path[x]);
			if(path[x + 1] == 0) pathLength = x + 2;
			x++;
			Console.WriteLine("first loop in findpath, after iteration x = " + x);
			Console.WriteLine("first loop in findpath, node's parent index = " + path[x]);
			Console.WriteLine("first loop in findpath, pathLength = " + pathLength);
		}
		int[] finalPath = new int[pathLength];
		Console.WriteLine("after first loop, pathLength = " + pathLength);
		int g = 0;
		while (g < pathLength)
		{
			Console.WriteLine("second loop in findpath, before iteration g = " + g);
			finalPath[g] = path[pathLength - 1 - g];
			Console.WriteLine("second loop in findpath, finalpath from root at depth g = " + finalPath[g]);
			g++;
			Console.WriteLine("second loop in findpath, after iteration g = " + g);
			
		}
		return finalPath;		
	}

	
	private static int getParentIndex(int index)
	{
		if (index <= 0) return -1;
		if( (index - getRowLeaderIndex(index)) % 2 == 0)
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
	
	private static int getRowLeaderIndex(int index)
	{
		int root = 0;
		int rowLeaderIndex = root;
		while( ! ( (index >= rowLeaderIndex) && (index < ( (rowLeaderIndex * 2) + 1) ) ))
		{
			rowLeaderIndex = (rowLeaderIndex * 2) + 1;
		}
		return rowLeaderIndex;
	}
}