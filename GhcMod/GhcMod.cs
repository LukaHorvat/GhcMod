using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhcMod
{
    public class GhcMod
    {
		public static TypeInfo GetType(string path, int line, int column)
		{
			var info = new FileInfo(path);
			var res = ProcessRunner.RunCommand("ghc-mod type " + info.Name + " x " + line + " " + column, info.DirectoryName);
			if (res == "") return null;
			var reader = new StringReader(res);
			var lineStr = reader.ReadLine().Split(' ');
			var type = "";
			for (int i = 4; i< lineStr.Length; ++i)
			{
				type += lineStr[i] + " ";
			}
			type = type.Substring(0, type.IndexOf('"', 1));
			return new TypeInfo
			{
				StartLine = Int32.Parse(lineStr[0]),
				StartCol = Int32.Parse(lineStr[1]),
				EndLine = Int32.Parse(lineStr[2]),
				EndCol = Int32.Parse(lineStr[3]),
				Type = type.Substring(1, type.Length - 1)
			};
		}

		public static string Check(string path)
		{
			var info = new FileInfo(path);
			return ProcessRunner.RunCommand("ghc-mod check " + info.Name, info.DirectoryName);
		}
    }
}
