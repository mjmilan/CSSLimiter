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
			
			Arguments commandLineArgs = GetArguments(args);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static Arguments GetArguments(string[] args)
		{
			Arguments result = new Arguments();
			CommandLine.Parser parser = new CommandLine.Parser();
			parser.ParseArguments(args, result);
			
			
			return result;
			
		}
	}
}