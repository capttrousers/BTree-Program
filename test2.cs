using System;

class Test2
{
	
	static void Main()
	{
		int max = 20;
		int[] tree = new int[max];
		int depth;
		max = 0;
		while (max < 20)
		{
			tree[max] = max + 1;
			depth = calculateDepth(max);
			Console.WriteLine("" + depth);
			max++;
		}
		
		
	}
	
	
	public static int getRowLeaderIndex(int index)
	{

		int root = 0;
		int rowLeaderIndex = root;
		while( ! ( (index >= rowLeaderIndex) && (index <  ((rowLeaderIndex * 2) + 1) ) ) )
		{
			rowLeaderIndex = (rowLeaderIndex * 2) + 1;
		}
		return rowLeaderIndex;
	}
	
	public static int calculateDepth(int index)
	{
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