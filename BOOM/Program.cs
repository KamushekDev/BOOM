using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace BOOM {
	class Program {
		static void Main(string[] args) {

			Console.Write("Номер теста: ");
			int number = int.Parse(Console.ReadLine());
			Minimizer minimizer = new Minimizer("../../Tests/Test"+number+".in");
			

			Task<string> min = Task.Run(minimizer.StartAsync);

			min.Wait();
			string result = min.Result;




			Console.ForegroundColor=ConsoleColor.Green;
			Console.WriteLine(result);
			Console.ReadKey();
		}
	}
}
