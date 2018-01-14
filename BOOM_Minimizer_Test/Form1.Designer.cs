namespace BOOM_Minimizer_Test {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.lblPath = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblTime = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblFirstImplicants = new System.Windows.Forms.Label();
			this.lblPrimeImplicants = new System.Windows.Forms.Label();
			this.lblResult = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.AutoSize = true;
			this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblPath.Location = new System.Drawing.Point(324, 249);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(260, 24);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "Перетащите файл на форму";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblTime.Location = new System.Drawing.Point(372, 9);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(212, 55);
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "00:00:00";
			// 
			// lblFileName
			// 
			this.lblFileName.AutoSize = true;
			this.lblFileName.Location = new System.Drawing.Point(12, 12);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(64, 13);
			this.lblFileName.TabIndex = 2;
			this.lblFileName.Text = "Имя файла";
			// 
			// lblFirstImplicants
			// 
			this.lblFirstImplicants.AutoSize = true;
			this.lblFirstImplicants.Location = new System.Drawing.Point(12, 42);
			this.lblFirstImplicants.Name = "lblFirstImplicants";
			this.lblFirstImplicants.Size = new System.Drawing.Size(212, 13);
			this.lblFirstImplicants.TabIndex = 3;
			this.lblFirstImplicants.Text = "Сгенерировано первичных импликант: 0";
			// 
			// lblPrimeImplicants
			// 
			this.lblPrimeImplicants.AutoSize = true;
			this.lblPrimeImplicants.Location = new System.Drawing.Point(12, 68);
			this.lblPrimeImplicants.Name = "lblPrimeImplicants";
			this.lblPrimeImplicants.Size = new System.Drawing.Size(200, 13);
			this.lblPrimeImplicants.TabIndex = 5;
			this.lblPrimeImplicants.Text = "Сгенерировано простых импликант: 0";
			// 
			// lblResult
			// 
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(12, 96);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(46, 13);
			this.lblResult.TabIndex = 6;
			this.lblResult.Text = "Ответ: -";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 123);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(552, 150);
			this.label1.TabIndex = 7;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 282);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.lblPrimeImplicants);
			this.Controls.Add(this.lblFirstImplicants);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.lblTime);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "BOOM минимизация";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblFirstImplicants;
		private System.Windows.Forms.Label lblPrimeImplicants;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Label label1;
	}
}

