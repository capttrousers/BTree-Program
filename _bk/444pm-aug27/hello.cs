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
		int maxNode = (int)Math.Pow(2, 5) - 1;
		
		/// convert to BTree
        Node[] tree = new Node[maxNode];
        
		tree = makeTree((int)Math.Log((double)(maxNode + 1), (double)2));
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
                string str = "", text = "", pad = "", afterStr = "_";
                int nodeCount = (int)(Math.Pow((double)2, (double)(i / 2)));
                int strLength = 48 / nodeCount;
                
				int j = (strLength - 3 - 1) / 2;
				
				
				if(i == 8)
				{
					afterStr = "";
				}

				/// j = padLength
                /// on row 1 (index = 0), nodeCount = 1, strLength = 48, j = 22
                /// on row 2 (index = 2), nodeCount = 2,  strLength = 24, 48/2 = 8, j = 10
                /// on row 5 (index = 8), nodeCount = 16, strLength = 3, 48/16 = 3, j = -1
                while (j > 0) 
                {
                    pad += '_';
                    j--;
                }
				
                while (nodeCount > 0)
                {
					if(tree[treeCount].myValue.Length < 2)
					{
						str =  "__" + tree[treeCount].myValue ;
					}
					else
					{
						str = "_" + tree[treeCount].myValue;
					}                        
					text += pad + str + afterStr + pad;
					treeCount++;
                    nodeCount--;
                }
                Console.WriteLine(text);
            }

        }

        Console.WriteLine("Please enter something:");
        Console.ReadLine();
		return 1;
	}




	/// convert to makeBTree
    private static Node[] makeTree(int depth)
    {
        int max = (int)(Math.Pow(((double)2), ((double) depth)) - 1);
        Node[] tree = new Node[max];
        int i = max;
        while(i > 0)
        {
            tree[i - 1] = new Node(i - 1);
            i--;
        }
        return tree;
    }
}



class Node 
{
	public string myValue;
	
	/// these are indexes in the binary tree, must be checked as < depth and not null
	/// index is 0 based, depth is 1 based    => depth starts at 1, index starts at 0 for root
	
	/*
	  TO IMPLEMENT
	public int leftChild, rightChild, Parent, index, depth;
	public bool hasChildren = false;
	
	*/
	
	public int index;
	
	
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

