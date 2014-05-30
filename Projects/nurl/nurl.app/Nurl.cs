/*
 * Created by SharpDevelop.
 * User: Joey
 * Date: 29/05/2014
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NDesk.Options;

namespace nurl.app
{
	/// <summary>
	/// Description of Nurl.
	/// </summary>
	public class Nurl
	{
		
		/* private variables */
		private String 		context;	// 1st
		private String 		url;		// 2nd
		private String 		option;		// 3th 
		private String 		time;		// 4th
		private String 		avgtime; 	// 5th
		private const int	minargs=3;	// min number of args
		private const int	maxargs=6;	// max number of args
		/* ----------------- */
		
		public Nurl()
		{
			// not used.
		}
		
		public Nurl(string[] args)
		{
			if (!hasArguments(args))
			{
				Console.WriteLine("Erreur: Les arguments sont manquants.");
			}
			else
			{	
				// get the context (get or test)	
				context = args[0].ToLower();
				// parsing the command line using ndesk.options
				new OptionSet()
				{
					{ "url=",  		v => url 		= v.ToLower() 	},
					{ "-save=", 	v => option 	= v.ToLower() 	},
				   	{ "-time=", 	v => time 		= v 			},
					{ "avg",		v => avgtime	= v.ToLower() 	}
				}.Parse(args);

				if (!IsValidContext())
				{
					Console.WriteLine("Erreur: Contexte inconnu (get ou test attendu)");
				}
				else
				{
					switch (context)
					{
					    case "get":
					        Console.WriteLine("GET process loading:\n");
					        break;
					    case "test":
					        Console.WriteLine("TEST process loading:\n");
					        break;
					}
				}
			}
		}
		
		/* test methods */
		private bool IsValidContext()
        {
            if (this.context == "get" || this.context == "test")
			{
                return true;
			}
            else
			{
                return false;
			}
        }
		
		private bool hasArguments(string[] a)
		{
			if(a.Length==0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
