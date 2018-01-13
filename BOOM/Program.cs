using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM {
	class Program {
		static void Main(string[] args) {

			Minimizer minimizer = new Minimizer();
			minimizer.ReadFunction("../../Test1.in");

			Console.WriteLine("Функция от {0} переменных с {1} определёнными мидтермами.",minimizer.Length, minimizer.True.Count+minimizer.False.Count);

			Console.ReadKey();
		}
	}
}
