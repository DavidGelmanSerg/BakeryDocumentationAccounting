namespace BakeryDocumentationAccounting.Forms
{
	partial class MaterialsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialsForm));
			infoTable = new DataGridView();
			((System.ComponentModel.ISupportInitialize)infoTable).BeginInit();
			SuspendLayout();
			
			// 
			// infoTable
			// 
			infoTable.BackgroundColor = SystemColors.Control;
			infoTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			infoTable.Dock = DockStyle.Fill;
			infoTable.Location = new Point(0, 0);
			infoTable.Name = "infoTable";
			infoTable.RowHeadersWidth = 51;
			infoTable.RowTemplate.Height = 29;
			infoTable.Size = new Size(582, 753);
			infoTable.TabIndex = 1;
			infoTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			infoTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			// 
			// MaterialsForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(582, 753);
			Controls.Add(infoTable);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "MaterialsForm";
			Text = "MaterialsForm";
			((System.ComponentModel.ISupportInitialize)infoTable).EndInit();
			ResumeLayout(false);
		}

		#endregion
		public DataGridView infoTable;
	}
}