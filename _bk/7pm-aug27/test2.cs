using System;

class Test2
{
	
	static void Main()
	{
		int max = 20;
		int[] tree = new int[max];
		int leader;
		max = 0;
		while (max < 20)
		{
			tree[max] = max + 1;
			leader = getRowLeaderIndex(max);
			Console.WriteLine("" + leader);
			max++;
		}
		
		
	}
	
	
	public static int getRowLeaderIndex(int index)
		{

			int root = 0;
			int rowLeaderIndex = root;
			while( (index > (rowLeaderIndex * 2)) && (index <  ((rowLeaderIndex * 4) + 3) ) )
			{
				rowLeaderIndex = (rowLeaderIndex * 2) + 1;
			}
			return rowLeaderIndex;
		}
}