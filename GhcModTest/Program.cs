using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhcModTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(GhcMod.GhcMod.GetType(@"C:\Users\Luka\Documents\Haskell\evolutionary-programming\Tests.hs", 7, 1).Type);
			Console.WriteLine(GhcMod.GhcMod.Check(@"C:\Users\Luka\Documents\Haskell\evolutionary-programming\Genetics.hs"));
			Console.ReadLine();
		}
	}
}
