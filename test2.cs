using System;

class Test2
{
	
	static int Main(string[] args) 
	{
		string n1,n2;
		if(args.Length != 2)
		{
			Console.WriteLine("Proper use of program is [FindParent.exe node1 node2]");
			return 1;
		} 
		else if (args[0].Length > 2 || args[1].Length > 2)
		{
			
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
		
		
		
		
		
	}
	
	
	private static bool isValidString(string str)
	{
		char[] chars = str.ToCharArray();
		return 
		(
			(chars.Length == 2) && 
			(isValidChar(chars[0])) && 
			(isValidChar(chars[1])) 
		)
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