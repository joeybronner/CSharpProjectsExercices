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
using nurl.app.nurl.feature.get;

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
		private String 		savepath;		// 3th 
		private String 		time;		// 4th
		private String 		avgtime; 	// 5th
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
					{ "url=",  		u => url 		= u.ToLower() 	},
					{ "save=", 	s => savepath 	= s.ToLower() 	},
				   	{ "time=", 	t => time 		= t				},
					{ "avg",		a => avgtime	= a.ToLower() 	}
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
							var get = new NurlGet(url, savepath);
					        break;
					    case "test":
					        Console.WriteLine("TEST process loading:\n");
							Console.WriteLine("Development in progress...");
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
