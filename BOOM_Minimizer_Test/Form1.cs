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

		private void Form1_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				Minimizer expression = new Minimizer(files[0]);
				Task.Run(() => MessageBox.Show(Task.Run(() => {
					var buffer= expression.StartAsync();
					buffer.Wait();
					timer1.Stop();
					return buffer;
				}).Result));
				ellapsedTime=TimeSpan.Zero;
				timer1.Start();
				lblTime.Text=ellapsedTime.ToString(@"hh\:mm\:ss");
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
