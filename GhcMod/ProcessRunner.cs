using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GhcMod
{
	class ProcessRunner
	{
		public static string RunCommand(string command, string cwd)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo("cmd")
				{
					Arguments = "/C " + command,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					WorkingDirectory = cwd,
					CreateNoWindow = true
				}
			};
			var output = "";
			process.OutputDataReceived += delegate(object o, DataReceivedEventArgs args)
			{
				if (args.Data == null) return;
				output += args.Data;
				if (args.Data[args.Data.Length - 1] != '\n') output += '\n';
			};
			process.ErrorDataReceived += delegate(object o, DataReceivedEventArgs args)
			{
				output += args.Data;
			};
			process.Start();
			process.BeginErrorReadLine();
			process.BeginOutputReadLine();
			while (!process.HasExited) Thread.Sleep(10);
			return output;
		}
	}
}
