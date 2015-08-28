using System;

class Test2
{
	
	static void Main()
	{
		
		string text = "";
		int x = 64;
		while(x > 0)
		{
			text += "#";
			x--;
		}
		
		Console.WriteLine(text);
		
	}
}