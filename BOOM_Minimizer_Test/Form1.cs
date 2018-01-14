using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

		private void Form1_DragDrop(object sender, DragEventArgs e) {
			if (!isWorking)
				if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move) {
					string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
					Minimizer expression = new Minimizer(files[0], this, 20);
					ellapsedTime=TimeSpan.Zero;
					timer1.Start();
					isWorking=true;
					lblFileName.Text=((string[])e.Data.GetData(DataFormats.FileDrop))[0];
					UpdateFI(0);
					UpdatePI(0);
					lblResult.Text="Ответ: -";
					lblTime.Text=ellapsedTime.ToString(@"hh\:mm\:ss");

					Task.Run(() => {
						string result = expression.StartAsync().Result;
						timer1.Stop();
						isWorking=false;
						this.Invoke((Action)delegate {
							lblResult.Text="Ответ: "+result;
						});
					});

				}
		}

		private void Form1_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
					((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
				e.Effect=DragDropEffects.Move;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			ellapsedTime=ellapsedTime.Add(new TimeSpan(0, 0, 1));
			lblTime.Text=ellapsedTime.ToString(@"hh\:mm\:ss");
		}
	}
}
