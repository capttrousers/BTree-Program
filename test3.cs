using System;

class Test2
{
	
	static int Main(string[] args) 
	{

		if(args.Length != 2)
		{
			Console.WriteLine("Proper use of program is [FindParent.exe node1 node2]");
			return 1;
		} 
		else if (isValidString(args[0]) && isValidString(args[1]))
		{
			Console.WriteLine("It Worked!");
		}
	
		
		return 1;
		
	}
	
	
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