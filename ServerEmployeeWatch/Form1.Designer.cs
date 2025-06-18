namespace ServerEmployeeWatch
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBoxClients = new System.Windows.Forms.ListBox();
			this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
			this.buttonSendScreen = new System.Windows.Forms.Button();
			this.labelInfo = new System.Windows.Forms.Label();
			this.labelClients = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// listBoxClients
			// 
			this.listBoxClients.FormattingEnabled = true;
			this.listBoxClients.Location = new System.Drawing.Point(12, 38);
			this.listBoxClients.Name = "listBoxClients";
			this.listBoxClients.Size = new System.Drawing.Size(245, 641);
			this.listBoxClients.TabIndex = 0;
			this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
			// 
			// pictureBoxScreen
			// 
			this.pictureBoxScreen.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pictureBoxScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxScreen.InitialImage = null;
			this.pictureBoxScreen.Location = new System.Drawing.Point(263, 119);
			this.pictureBoxScreen.Name = "pictureBoxScreen";
			this.pictureBoxScreen.Size = new System.Drawing.Size(625, 560);
			this.pictureBoxScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxScreen.TabIndex = 1;
			this.pictureBoxScreen.TabStop = false;
			// 
			// buttonSendScreen
			// 
			this.buttonSendScreen.Location = new System.Drawing.Point(263, 90);
			this.buttonSendScreen.Name = "buttonSendScreen";
			this.buttonSendScreen.Size = new System.Drawing.Size(624, 23);
			this.buttonSendScreen.TabIndex = 2;
			this.buttonSendScreen.Text = "Get Screen";
			this.buttonSendScreen.UseVisualStyleBackColor = true;
			this.buttonSendScreen.Click += new System.EventHandler(this.buttonSendScreen_Click);
			// 
			// labelInfo
			// 
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new System.Drawing.Point(264, 19);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(35, 13);
			this.labelInfo.TabIndex = 3;
			this.labelInfo.Text = "label1";
			// 
			// labelClients
			// 
			this.labelClients.AutoSize = true;
			this.labelClients.Location = new System.Drawing.Point(12, 19);
			this.labelClients.Name = "labelClients";
			this.labelClients.Size = new System.Drawing.Size(41, 13);
			this.labelClients.TabIndex = 4;
			this.labelClients.Text = "Clients:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 689);
			this.Controls.Add(this.labelClients);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.buttonSendScreen);
			this.Controls.Add(this.pictureBoxScreen);
			this.Controls.Add(this.listBoxClients);
			this.Name = "MainForm";
			this.Text = "Main Form";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxClients;
		private System.Windows.Forms.PictureBox pictureBoxScreen;
		private System.Windows.Forms.Button buttonSendScreen;
		private System.Windows.Forms.Label labelInfo;
		private System.Windows.Forms.Label labelClients;
	}
}

