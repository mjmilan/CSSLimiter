/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 27/02/2014
 * Time: 00:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using CommandLine;
namespace CSSLimiter
{
	/// <summary>
	/// Description of Arguments.
	/// </summary>
	public class Arguments
	{
	
		
		#region Constructor
		public Arguments()
		{
			ContainingClass = string.Empty;
			ContainingID = string.Empty;
			ContainingType = string.Empty;
		}
		#endregion
		
		#region Properties
		[CommandLine.Option('t',"type")]
		public string ContainingType {get; set;}
		
		[CommandLine.Option('c',"class")]
		public string ContainingClass {get; set;}
		
		[CommandLine.Option('i',"id")]
		public string ContainingID {get;set;}
		
		[CommandLine.Option('f',"filename")]
		public string CSSFilename {get; set;}
		#endregion
		
		
	}
}
