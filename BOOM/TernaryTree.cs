using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOM {

	public class TernaryTree {

		private TernaryNode root;

		private int length;

		public int Count { get; set; }

		/// <summary>
		/// Добавляет элемент в дерево
		/// </summary>
		/// <param name="input">Входная строка</param>
		/// <returns>true если элемент ранее не содержался</returns>
		public bool Add(string input) {
			if (input.Length!=length)
				throw new ArgumentException(String.Format("Строка имеет длинну {0}, а должна быть длинной в {1} символов.", input.Length, length));
			bool result = false;
			TernaryNode buffer = root;
			foreach (char a in input) {
				switch (a) {
				case '0':
					if (buffer.Left==null) {
						result=true;
						buffer.Left=new TernaryNode();
					}
					buffer=buffer.Left;
					break;
				case '-':
					if (buffer.Middle==null) {
						result=true;
						buffer.Middle=new TernaryNode();
					}
					buffer=buffer.Middle;
					break;
				case '1':
					if (buffer.Right==null) {
						result=true;
						buffer.Right=new TernaryNode();
					}
					buffer=buffer.Right;
					break;
				default:
					throw new ArgumentException("Строка иммет неверный символ.");
				}
			}
			Count++;
			return result;
		}

		public TernaryTree(int _length) {
			length=_length;
			Count=0;
			root=new TernaryNode();
		}

	}

	public class TernaryNode {

		public TernaryNode Left { get; set; }
		public TernaryNode Middle { get; set; }
		public TernaryNode Right { get; set; }

		public TernaryNode() {
			Left=null;
			Middle=null;
			Right=null;
		}


	}

}
