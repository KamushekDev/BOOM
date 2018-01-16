using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOM_Minimizer_Test {
	public partial class Form1: Form {
		public Form1() {
			InitializeComponent();
		}

		static TimeSpan ellapsedTime;
		static bool isWorking = false;

		public void UpdateFI(int count) {
			lblFirstImplicants.Text="Сгенерировано первичных импликант: "+count;
		}

		public void UpdatePI(int count) {
			lblPrimeImplicants.Text="Сгенерировано простых импликант: "+count;
		}

		private void StartTest(object sender, MouseEventArgs e) {
			if (!isWorking) {
				string filePath = "../../Tests/"+(string)lbTests.SelectedItem;
				Minimizer expression = new Minimizer(filePath, this, tbCDTime.Value, cbMultiExpansion.Checked);
				ellapsedTime=TimeSpan.Zero;
				timer1.Start();
				isWorking=true;
				lblFileName.Text=(string)lbTests.SelectedItem;
				UpdateFI(0);
				UpdatePI(0);
				tbAnswer.Text="";
				lblTime.Text=ellapsedTime.ToString(@"hh\:mm\:ss");

				Task.Run(() => {
					string result = expression.StartAsync().Result;
					timer1.Stop();
					isWorking=false;
					this.Invoke((Action)delegate {
						tbAnswer.Text=result;
					});
				});
			}
		}

		private void timer1_Tick(object sender, EventArgs e) {
			ellapsedTime=ellapsedTime.Add(new TimeSpan(0, 0, 1));
			lblTime.Text=ellapsedTime.ToString(@"hh\:mm\:ss");
		}

		private void tbCDTime_Scroll(object sender, EventArgs e) {
			lblTBTime.Text=tbCDTime.Value+" секунд.";
		}

		private void LoadFiles() {

			string[] tests = (from i in Directory.EnumerateFiles("../../Tests", "*.in", SearchOption.AllDirectories) select i.Split('\\').Last()).ToArray();

			lbTests.Items.AddRange(tests);
		}

		private void Form1_Load(object sender, EventArgs e) {
			lblTBTime.Location=new Point(tbCDTime.Location.X, lblTBTime.Location.Y);
			lblTBTime.Width=tbCDTime.Width;
			LoadFiles();
		}

		private void lbTests_SelectedValueChanged(object sender, EventArgs e) {
			string[] info = new string[3];
			StreamReader sr = new StreamReader("../../Tests/"+lbTests.SelectedItem);
			lblFunction.Text="Функция: "+sr.ReadLine();
			lblVariables.Text="Количество переменных: "+sr.ReadLine();
			lblSost.Text="Количество важных состояний: "+sr.ReadLine();
			sr.Close();
		}
	}
}
