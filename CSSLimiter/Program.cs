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
			bool flag = true;
			// Gather the arguments from the command line.
			Arguments commandLineArgs = GetArguments(args);
			
			// Get an object representing the stylesheet.
			ExCSS.StyleSheet sheet = null;
			try{
				 sheet = GetStyleSheet(commandLineArgs.CSSFilename);
			}
			catch (System.IO.IOException){
				Console.WriteLine("Unable to open file \"{0}\".", commandLineArgs.CSSFilename);
				flag = false;
				return;
			}
			
			if (flag)
			{
				// Ok, at this point, we have the sheet, and we have the arguments.
				// Let's get processing.
				string newCss = ProcessSheet(sheet, commandLineArgs);
				Console.WriteLine(newCss);
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
		
		private static string ProcessSheet(ExCSS.StyleSheet sheet, Arguments commandLineArgs)
		{
			string result = string.Empty;
			foreach (var ruleset in sheet.Rulesets)
			{
				string[] selectors = ruleset.Value.Split(',');
				for (int i = 0; i < selectors.Length; i++)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					sb.Append(commandLineArgs.ContainingType);
					if (!string.IsNullOrWhiteSpace(commandLineArgs.ContainingClass))
					{
						sb.Append(".");
						sb.Append(commandLineArgs.ContainingClass);
					}
					if (!string.IsNullOrWhiteSpace(commandLineArgs.ContainingID))
					{
						sb.Append("#");
						sb.Append(commandLineArgs.ContainingID);
					}
					
					if (sb.Length > 0){
						selectors[i] = string.Concat(sb.ToString()," ", selectors[i]);
					}
				}
				
				
				ruleset.Value = string.Join(",", selectors);
			}
			
			result = sheet.ToString(true);
			
			return result;
			
		}
	}
}