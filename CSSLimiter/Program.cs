/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 27/02/2014
 * Time: 00:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;
namespace CSSLimiter
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			bool flag = true;
			// Gather the arguments from the command line.
			Arguments commandLineArgs = GetArguments(args);
			
			// Get an object representing the stylesheet.
			ExCSS.StyleSheet sheet = null;
			try{
				 sheet = GetStyleSheet("");
			}
			catch (System.IO.IOException){
				Console.WriteLine("Unable to open file \"{0}\".", commandLineArgs.CSSFilename);
				flag = false;
				return;
			}
			
			if (flag)
			{
				
			}
			
			Console.ReadKey(true);
		}
		
		private static Arguments GetArguments(string[] args)
		{
			Arguments result = new Arguments();
			CommandLine.Parser parser = new CommandLine.Parser();
			parser.ParseArguments(args, result);
			return result;
			
		}
		
		private static ExCSS.StyleSheet	GetStyleSheet(string cssFilePath)
		{
			ExCSS.StyleSheet result;
			result = new ExCSS.Parser().Parse(new System.IO.FileStream(cssFilePath, System.IO.FileMode.Open));
			return result;
		}
	}
}