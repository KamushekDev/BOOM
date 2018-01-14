using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BOOM {
	class Minimizer {
		Random rand = new Random();

		bool _DEBUG_ = !true;

		public List<string> True { get; set; }
		public List<string> False { get; set; }
		public TernaryTree H { get; set; }

		public int Length { get; set; }

		private void ReadFunction(string path) {
			int length = 0;
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

		private bool IntersectFalse(string input) {
			for (int i = 0; i<False.Count; i++) {
				bool intersect = true;
				for (int k = 0; k<Length; k++) {
					if (input[k]=='-')
						continue;
					if (input[k]!=False[i][k]) {
						intersect=false;
						break;
					}
				}
				if (intersect)
					return true;
			}
			return false;
		}

		public void CD_Search(){
			long iteration = 0, ellapsedIterations = 0, lastChangeIteration=0, implicantsCount = 0;
			while (true) {
				if (ellapsedIterations==long.MaxValue||iteration==long.MaxValue)
					break;
				iteration++; ellapsedIterations++;
				CD_SearchOnce();
				if (H.Count!=implicantsCount){
					lastChangeIteration=iteration;
					ellapsedIterations=0;
					implicantsCount=H.Count;
					iteration=0;
				}
				if (ellapsedIterations/2>lastChangeIteration)
					break;
			}
		}

		private void CD_SearchOnce() {
			long[,] varFrequences = new long[2, Length];
			string t = new string(Enumerable.Repeat('-', Length).ToArray());///текущая импликанта

			List<string> trueReduced = True.ToList();///сокращённый истинный набор

			//------------------------------------------------------------------------------------------------------------------------------------------------Вывод в консоль
			if (_DEBUG_) {
				//Console.WriteLine(MostFrequenceVariable());
				for (int i = 0; i<2; i++) {
					for (int k = 0; k<Length; k++)
						Console.Write(varFrequences[i, k]);
					Console.WriteLine();
				}
			}
			//------------------------------------------------------------------------------------------------------------------------------------------------Вывод в консоль
			do {
				t=new string(Enumerable.Repeat('-', Length).ToArray());
				do {
					t = MostFrequenceVariable();

				} while (IntersectFalse(t));
				ReduceTrue(t);
				H.Add(t);
			} while (trueReduced.Count>0);
			//todo вернуть H (сгенерированные импликанты)

			void ReduceTrue(string implicant) {
				for (int i = 0; i<trueReduced.Count; i++)
					for (int k = 0; k<implicant.Length; k++) {
						if (implicant[k]!='-'&&implicant[k]!=trueReduced[i][k])
							break;
						if (k==implicant.Length-1)
							trueReduced.RemoveAt(i--);
					}
			}

			string MergeTerms(string first, string second) {
				if (first.Length!=second.Length)
					throw new ArgumentException("Строки разной длины.");
				StringBuilder sb = new StringBuilder("");
				for (int i = 0; i<first.Length; i++) {
					if (first[i]=='-'&&second[i]=='-')
						sb.Append('-');
					else if ((first[i]=='0'&&second[i]=='-')||(first[i]=='-'&&second[i]=='0')||(first[i]=='0'&&second[i]=='0'))
						sb.Append('0');
					else if ((first[i]=='1'&&second[i]=='-')||(first[i]=='-'&&second[i]=='1')||(first[i]=='1'&&second[i]=='1'))
						sb.Append('1');
					else
						throw new ArgumentException("Входные строки не соответствуют требованию");
				}
				return sb.ToString();
			}

			string MostFrequenceVariable() {
				long max = -1;
				int countMax = 0;
				if (t==new string(Enumerable.Repeat('-', Length).ToArray()))
					for (int i = 0; i<2; i++)
						for (int k = 0; k<Length; k++)
							varFrequences[i, k]=0;
				///Составление массива частоты вхождений переменных
				for (int i = 0; i<Length; i++)
					for (int k = 0; k<trueReduced.Count; k++) {
						if (t[i]=='-')
							if (trueReduced[k][i]=='0') {
								varFrequences[0, i]++;
								if (varFrequences[0, i]>max) {
									max=varFrequences[0, i];
									countMax=1;
								} else if (varFrequences[0, i]==max)
									countMax++;

							} else if (trueReduced[k][i]=='1') {
								varFrequences[1, i]++;
								if (varFrequences[1, i]>max) {
									max=varFrequences[1, i];
									countMax=1;
								} else if (varFrequences[1, i]==max)
									countMax++;
							}
					}

				///обработка массива частоты вхождений переменных
				List<string> mostFrequencesVariables = new List<string>(countMax); //Набор импликант
				StringBuilder sb = new StringBuilder(new string(Enumerable.Repeat('-', Length).ToArray()));
				int countImplicants = 0;
				for (int i = 0; i<2; i++)
					for (int k = 0; k<Length; k++)
						if (varFrequences[i, k]==max) {
							sb[k]=i.ToString()[0];
							string implicant = MergeTerms(t, sb.ToString());
							if (!IntersectFalse(implicant))
								countImplicants++;
							mostFrequencesVariables.Add(implicant);
							sb[k]='-';
						}
				//------------------------------------------------------------------------------------------------------------------------------------------------Вывод в консоль
				if (_DEBUG_) {
					PrintStringList(False);
					foreach (string line in mostFrequencesVariables)
						Console.WriteLine(line+" Intersect False? "+IntersectFalse(line));
				}
				//------------------------------------------------------------------------------------------------------------------------------------------------Вывод в консоль

				if (countImplicants>0) {
					for (int i = 0; i<mostFrequencesVariables.Count; i++)
						if (IntersectFalse(mostFrequencesVariables[i]))
							mostFrequencesVariables.RemoveAt(i--);
				}

				return mostFrequencesVariables[rand.Next(mostFrequencesVariables.Count)];
			}
		}

		private void PrintStringList(List<string> input) {

			foreach (string str in input)
				Console.WriteLine(str);
		}


		public Minimizer(string pathToFile) {
			True = new List<string>();
			False = new List<string>();
			ReadFunction(pathToFile);
			H=new TernaryTree(Length);
		}

	}
}
