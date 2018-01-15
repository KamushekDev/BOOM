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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFirstImplicants = new System.Windows.Forms.Label();
            this.lblPrimeImplicants = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.tbCDTime = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTBTime = new System.Windows.Forms.Label();
            this.cbMultiExpansion = new System.Windows.Forms.CheckBox();
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.lblVariables = new System.Windows.Forms.Label();
            this.lblSost = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lbTests = new System.Windows.Forms.ListBox();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.lblVariablesCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbCDTime)).BeginInit();
            this.gbTestInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.lblTime.Location = new System.Drawing.Point(496, 11);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(262, 69);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "00:00:00";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(17, 15);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(82, 17);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "Имя файла";
            // 
            // lblFirstImplicants
            // 
            this.lblFirstImplicants.AutoSize = true;
            this.lblFirstImplicants.Location = new System.Drawing.Point(17, 44);
            this.lblFirstImplicants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstImplicants.Name = "lblFirstImplicants";
            this.lblFirstImplicants.Size = new System.Drawing.Size(275, 17);
            this.lblFirstImplicants.TabIndex = 3;
            this.lblFirstImplicants.Text = "Сгенерировано первичных импликант: 0";
            // 
            // lblPrimeImplicants
            // 
            this.lblPrimeImplicants.AutoSize = true;
            this.lblPrimeImplicants.Location = new System.Drawing.Point(17, 76);
            this.lblPrimeImplicants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrimeImplicants.Name = "lblPrimeImplicants";
            this.lblPrimeImplicants.Size = new System.Drawing.Size(258, 17);
            this.lblPrimeImplicants.TabIndex = 5;
            this.lblPrimeImplicants.Text = "Сгенерировано простых импликант: 0";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(16, 127);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(67, 20);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Ответ:";
            // 
            // tbCDTime
            // 
            this.tbCDTime.Location = new System.Drawing.Point(628, 271);
            this.tbCDTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCDTime.Maximum = 120;
            this.tbCDTime.Minimum = 10;
            this.tbCDTime.Name = "tbCDTime";
            this.tbCDTime.Size = new System.Drawing.Size(139, 56);
            this.tbCDTime.TabIndex = 8;
            this.tbCDTime.Value = 20;
            this.tbCDTime.Scroll += new System.EventHandler(this.tbCDTime_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 271);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ограничение времени на CD-поиск";
            // 
            // lblTBTime
            // 
            this.lblTBTime.Location = new System.Drawing.Point(628, 310);
            this.lblTBTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTBTime.Name = "lblTBTime";
            this.lblTBTime.Size = new System.Drawing.Size(139, 16);
            this.lblTBTime.TabIndex = 10;
            this.lblTBTime.Text = "20 секунд.";
            this.lblTBTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMultiExpansion
            // 
            this.cbMultiExpansion.AutoSize = true;
            this.cbMultiExpansion.Location = new System.Drawing.Point(384, 335);
            this.cbMultiExpansion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMultiExpansion.Name = "cbMultiExpansion";
            this.cbMultiExpansion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbMultiExpansion.Size = new System.Drawing.Size(296, 21);
            this.cbMultiExpansion.TabIndex = 11;
            this.cbMultiExpansion.Text = "Множественное расширение импликант";
            this.cbMultiExpansion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbMultiExpansion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cbMultiExpansion.UseVisualStyleBackColor = true;
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.lblVariables);
            this.gbTestInfo.Controls.Add(this.lblSost);
            this.gbTestInfo.Controls.Add(this.lblFunction);
            this.gbTestInfo.Location = new System.Drawing.Point(384, 159);
            this.gbTestInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTestInfo.Size = new System.Drawing.Size(391, 105);
            this.gbTestInfo.TabIndex = 13;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "Информация о тесте";
            // 
            // lblVariables
            // 
            this.lblVariables.AutoSize = true;
            this.lblVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVariables.Location = new System.Drawing.Point(8, 49);
            this.lblVariables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.Size = new System.Drawing.Size(226, 20);
            this.lblVariables.TabIndex = 2;
            this.lblVariables.Text = "Количество переменных: ";
            // 
            // lblSost
            // 
            this.lblSost.AutoSize = true;
            this.lblSost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSost.Location = new System.Drawing.Point(8, 76);
            this.lblSost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSost.Name = "lblSost";
            this.lblSost.Size = new System.Drawing.Size(279, 20);
            this.lblSost.TabIndex = 1;
            this.lblSost.Text = "Количество важных состояний: ";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFunction.Location = new System.Drawing.Point(8, 22);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(92, 20);
            this.lblFunction.TabIndex = 0;
            this.lblFunction.Text = "Функция: ";
            // 
            // lbTests
            // 
            this.lbTests.FormattingEnabled = true;
            this.lbTests.ItemHeight = 16;
            this.lbTests.Location = new System.Drawing.Point(16, 159);
            this.lbTests.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbTests.Name = "lbTests";
            this.lbTests.Size = new System.Drawing.Size(359, 196);
            this.lbTests.TabIndex = 14;
            this.lbTests.SelectedValueChanged += new System.EventHandler(this.lbTests_SelectedValueChanged);
            this.lbTests.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StartTest);
            // 
            // tbAnswer
            // 
            this.tbAnswer.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tbAnswer.BackColor = System.Drawing.SystemColors.Window;
            this.tbAnswer.Location = new System.Drawing.Point(92, 126);
            this.tbAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.ReadOnly = true;
            this.tbAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbAnswer.Size = new System.Drawing.Size(681, 22);
            this.tbAnswer.TabIndex = 15;
            // 
            // lblVariablesCount
            // 
            this.lblVariablesCount.AutoSize = true;
            this.lblVariablesCount.Location = new System.Drawing.Point(17, 102);
            this.lblVariablesCount.Name = "lblVariablesCount";
            this.lblVariablesCount.Size = new System.Drawing.Size(247, 17);
            this.lblVariablesCount.TabIndex = 16;
            this.lblVariablesCount.Text = "Количество переменных в ответе: 0";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 369);
            this.Controls.Add(this.lblVariablesCount);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.lbTests);
            this.Controls.Add(this.gbTestInfo);
            this.Controls.Add(this.cbMultiExpansion);
            this.Controls.Add(this.lblTBTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCDTime);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblPrimeImplicants);
            this.Controls.Add(this.lblFirstImplicants);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BOOM минимизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbCDTime)).EndInit();
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblFirstImplicants;
		private System.Windows.Forms.Label lblPrimeImplicants;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.TrackBar tbCDTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTBTime;
		private System.Windows.Forms.CheckBox cbMultiExpansion;
		private System.Windows.Forms.GroupBox gbTestInfo;
		private System.Windows.Forms.Label lblVariables;
		private System.Windows.Forms.Label lblSost;
		private System.Windows.Forms.Label lblFunction;
		private System.Windows.Forms.ListBox lbTests;
		private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.Label lblVariablesCount;
    }
}

