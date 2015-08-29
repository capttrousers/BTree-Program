using System;

class  Test 
{
	
	static void Main()
	{
		string str = "", pad = "", text = "";
		
		
		int[] tree = new int[32];
		
		int x = 8;
		while (x < 32)
		{
			tree[x - 1] = x;
			x++;
		}
		
		int j;
		x = 8;
		
		for(int i = 1; i < 3; i++)
		{
			text = "";
			if (i == 1) 
			{
				pad = "#";
				j = 8;
			}
			else
			{
				pad = "";
				j = 16;
			}
			while(j > 0)
			{
				if (x < 10) str = "##" + tree[x - 1];
				else str = "#" + tree[x - 1];

				text += pad + str + pad+ pad;
				x++;
				j--;
			}
			Console.WriteLine(text);
			
		}
		Console.ReadLine();
	}
	
	
	
}