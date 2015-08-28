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
        int[] tree = new int[(int)Math.Pow(2, 5) - 2];
        tree = makeTree(5);
        int count = 0;
        for(int i = 0; i < 10; i++)
        {
            if(i % 2 != 0)
            {
                Console.WriteLine();
            }
            else
            {
                string str = "", text = "";
                int splits = (int)(Math.Pow((double)2, (double)((i / 2) + 1)));
                int strLength = 32 / splits;
                int j = 1;

                /// on row 1 (index = 0), splits = 2, strLength = 16, j < 16
                /// on row 2, splits = 4,  strLength = 8, 32/4 = 8, j < 4
                /// on row 5, splits = 32, strLength = 1, 32/32 = 1, j < 1
                while (j < strLength) 
                {
                    str += '_';
                    j++;
                }

                /// while j <= 2, splits/2 = 2
                /// on row 5, splits = 32, j <= 16
                j = 1;
                while (j <= splits / 2)
                {
                    if (count < 30)
                    {
                        if(tree[count] < 10)
                        {
                            text += str + '_' + tree[count] + '_' + str;
                        }
                        else
                        {
                            text += str + '_' + tree[count] + str;
                        }                        
                        count++;
                    }
                    j++;
                }
                Console.WriteLine(text);
            }

        }

        Console.WriteLine("Please enter something:");
        Console.ReadLine();
		return 1;
	}





    private static int[] makeTree(int depth)
    {
        int max = (int)(Math.Pow(((double)2), ((double) depth)) - 2);
        int[] tree = new int[max];
        int i = max - 1;
        while(i >= 0)
        {
            tree[i] = i;
            i--;
        }
        return tree;
    }
}