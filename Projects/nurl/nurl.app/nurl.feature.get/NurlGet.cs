/*
 * Created by SharpDevelop.
 * User: Joey
 * Date: 30/05/2014
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;

namespace nurl.app.nurl.feature.get
{
	/// <summary>
	/// Description of NurlGet.
	/// </summary>
	public class NurlGet
	{
		/* private variables */
		private String 		url;		
		private String 		savepath;	
		/* ----------------- */
		
		public NurlGet()
		{
			// not used.
		}
		
		public NurlGet(String u, String p)
		{
			// check if url is valide, 
			if (!IsntUrlEmpty(u) || !IsUrlValide())
			{
				Console.WriteLine("Erreur: l'URL est vide ou invalide.");
			}
			else
			{
				Console.WriteLine("URL:" + url);
				
				// check if savepath is empty or not
				if (!IsSavePathOption(p))
				{
					Console.WriteLine("L'utilisateur souhaite juste afficher le contenu");
					
				}
				else if (isFilePathExist())
				{
					// file is existing, want to erase it ?
					if (eraseFile())
					{
						Console.WriteLine("L'utilisateur souhaite ecraser le fichier existant");
					}
					else
					{
						Console.WriteLine("L'utilisateur ne souhaite pas écraser le fichier. FIN");
					}
				}
				else if (!isFilePathExist())
				{
					Console.WriteLine("Le fichier n'existe pas encore");
				}
				else
				{
					Console.WriteLine("Le chemin de sauvegarde n'est pas correct, vérifiez puis réessayez.");
				}
				
			}
			
			
		}
		
		/* test methods */
		
		private bool IsntUrlEmpty(String u)
		{
			if (String.IsNullOrEmpty(u)) 
			{
				return false;
			}
			else
			{
				url = u;
				return true;
			}
		}
		
		private bool IsUrlValide()
		{
			WebResponse webResponse;
			var webRequest = WebRequest.Create(url);  
			
			try 
			{
				webResponse = webRequest.GetResponse();
				return true;
			}
			catch
			{
			  return false;
			} 
			
		}
	
		private bool IsSavePathOption(String p)
		{
			if (String.IsNullOrEmpty(p)) 
			{
				return false;
			}
			else
			{
				savepath = p;
				return true;
			}
		}
	
		/*private bool isSavePathValide()
		{
			// get the file attributes for file or directory
			//FileAttributes attr = File.GetAttributes(savepath);
			//return ((attr & FileAttributes.Directory) == FileAttributes.Directory);
			//return Uri.IsWellFormedUriString(savepath, );
		}*/
		
		private bool isFilePathExist()
		{
			return File.Exists(savepath);
		}
	
		private bool eraseFile()
		{
			Console.WriteLine("Voulez-vous écraser ce fichier ? (Y/N)");
	        Console.ReadLine();
	        string rep = Console.ReadLine();
			return (rep.Equals("Y"));
		}
	}
}
