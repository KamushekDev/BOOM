using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM {
	class Program {
		static void Main(string[] args) {
			
			Console.Write("Номер теста: ");
			int number = int.Parse(Console.ReadLine());

			Minimizer minimizer = new Minimizer("../../Tests/Test"+number+".in");

			Console.WriteLine("Функция от {0} переменных с {1} определёнными мидтермами.", minimizer.Length, minimizer.True.Count+minimizer.False.Count);

			minimizer.CD_Search();

			Console.WriteLine("Содержит {0} импликант. Различных из них {1}", minimizer.H.Count, minimizer.H.GetElements().Distinct().Count());

			Console.ReadKey();
		}
	}
}
