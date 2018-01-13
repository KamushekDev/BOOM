using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BOOM {
	class Minimizer {

		public List<string> True { get; set; }
		public List<string> False { get; set; }

		public long Length { get; set; }

		private string MergeTerms(string first, string second){
			throw new NotImplementedException();
		}

		public void ReadFunction(string path) {
			long length = 0;
			foreach (string line in File.ReadAllLines(path)) {
				if (length != 0 && length != line.Length - 2)
					throw new ArgumentException("Ошибка во входных данных.");
				else
					length = line.Length - 2;
				if (line[0] == '0')
					False.Add(line.Substring(2));
				else if (line[0] == '1')
					True.Add(line.Substring(2));
			}
			Length = length;
		}

		//private string MostFrequentLiteral(List<string> TrueReduced) {
		//	long[,] varAccuracy = new long[2, Length];//0-инверсии 1-инверсии
		//	for (int i = 0; i < Length; i++)
		//		for (int k = 0; k < True.Count; k++) {
		//			if ()
		//		}

		//}

		public void CD_search() {
			string t;
			List<string> H = new List<string>();
			List<string> TrueReduced = new List<string>();
			do {
				TrueReduced = True;
				t = Enumerable.Repeat("-", (int)Length).ToString();

				//todo
				/*do
				{
							//todo
				} while ();*/
			} while (False.Count > 0);
			//todo вернуть H (сгенерированные импликанты)
		}

		public Minimizer() {
			True = new List<string>();
			False = new List<string>();
		}

	}
}
