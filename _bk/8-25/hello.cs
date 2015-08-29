using System;

class Hello
{
	static int Main(string[] args) {
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
				Console.WriteLine("Proper use of program is [FindParent.exe node1 node2] where node1 and node2 are integers");
				return 1;
			}
		}
				
		Console.WriteLine("Node 1 is {0} and Node 2 is {0}", n1, n2);
		Console.ReadLine();
		return 1;
	}
}