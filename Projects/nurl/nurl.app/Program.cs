using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nurl.app
{
    static class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("-NURL PROJECT- https://github.com/joeybronner/CSharpProjectsExercices.git \n");
			Console.WriteLine("Starting...\n");
			
			// calling the start method (file: Nurl.cs)
			// disable once SuggestUseVarKeywordEvident
			Nurl app = new Nurl(args);
			
			Console.Read();
        }
    }
}
