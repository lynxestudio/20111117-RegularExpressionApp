using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace Samples.TestGrep
{
	class Program
	{
		public static void Main(string[] args)
		{
			if(args.Length == 2)
			{
    			string pattern = args[0];
 				string file = args[1];
 				Regex regexp = new Regex(@pattern,RegexOptions.Multiline);
 				FileInfo fi = new FileInfo(file);
 			if(File.Exists(fi.FullName))
 			{
  			using(StreamReader sr = new StreamReader(file))
  			{
   				string line;
   				while((line = sr.ReadLine())!= null)
   				{
    				Match m = regexp.Match(line);
    				if(m.Success)
    				Console.WriteLine("{0}",line);
   				}
  			}
 			}
 			else
  				Console.WriteLine("File not found");
			}
			else
			Console.WriteLine("Usage: mono TestGrep [pattern] [file]");
		}
	}
}