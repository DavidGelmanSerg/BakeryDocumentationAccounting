namespace BakeryDocumentationAccounting.Forms
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			MainPanels = new SplitContainer();
			SummaryTable = new DataGridView();
			Num = new DataGridViewTextBoxColumn();
			Production = new DataGridViewTextBoxColumn();
			Weight = new DataGridViewTextBoxColumn();
			ProductionAmount = new DataGridViewTextBoxColumn();
			ProductionKg = new DataGridViewTextBoxColumn();
			DefectAmount = new DataGridViewTextBoxColumn();
			DefectKg = new DataGridViewTextBoxColumn();
			labourIntensity = new DataGridViewTextBoxColumn();
			Plan = new DataGridViewTextBoxColumn();
			Fact = new DataGridViewTextBoxColumn();
			ButtonFlowLayout = new FlowLayoutPanel();
			AddBtn = new Button();
			EditBtn = new Button();
			DeleteBtn = new Button();
			GetInfoBtn = new Button();
			PrintDocBtn = new Button();
			ppd = new PrintPreviewDialog();
			reportDocument = new System.Drawing.Printing.PrintDocument();
			((System.ComponentModel.ISupportInitialize)MainPanels).BeginInit();
			MainPanels.Panel1.SuspendLayout();
			MainPanels.Panel2.SuspendLayout();
			MainPanels.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)SummaryTable).BeginInit();
			ButtonFlowLayout.SuspendLayout();
			SuspendLayout();
			// 
			// MainPanels
			// 
			MainPanels.Dock = DockStyle.Fill;
			MainPanels.Location = new Point(0, 0);
			MainPanels.Margin = new Padding(0);
			MainPanels.Name = "MainPanels";
			MainPanels.Orientation = Orientation.Horizontal;
			// 
			// MainPanels.Panel1
			// 
			MainPanels.Panel1.Controls.Add(SummaryTable);
			// 
			// MainPanels.Panel2
			// 
			MainPanels.Panel2.Controls.Add(ButtonFlowLayout);
			MainPanels.Size = new Size(1482, 753);
			MainPanels.SplitterDistance = 680;
			MainPanels.TabIndex = 0;
			// 
			// SummaryTable
			// 
			SummaryTable.AllowUserToAddRows = false;
			SummaryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			SummaryTable.BackgroundColor = Color.White;
			SummaryTable.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
			SummaryTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			SummaryTable.Columns.AddRange(new DataGridViewColumn[] { Num, Production, Weight, ProductionAmount, ProductionKg, DefectAmount, DefectKg, labourIntensity, Plan, Fact });
			SummaryTable.GridColor = SystemColors.Control;
			SummaryTable.Location = new Point(0, 0);
			SummaryTable.Margin = new Padding(0);
			SummaryTable.Name = "SummaryTable";
			SummaryTable.RowHeadersVisible = false;
			SummaryTable.RowHeadersWidth = 51;
			SummaryTable.RowTemplate.Height = 29;
			SummaryTable.Size = new Size(1482, 680);
			SummaryTable.TabIndex = 0;
			SummaryTable.CellDoubleClick += SummaryTable_CellDoubleClick;
			// 
			// Num
			// 
			Num.HeaderText = "№";
			Num.MinimumWidth = 6;
			Num.Name = "Num";
			Num.ReadOnly = true;
			// 
			// Production
			// 
			Production.HeaderText = "Продукция";
			Production.MinimumWidth = 6;
			Production.Name = "Production";
			Production.ReadOnly = true;
			// 
			// Weight
			// 
			Weight.HeaderText = "Вес";
			Weight.MinimumWidth = 6;
			Weight.Name = "Weight";
			Weight.ReadOnly = true;
			// 
			// ProductionAmount
			// 
			ProductionAmount.HeaderText = "Выработано (шт.)";
			ProductionAmount.MinimumWidth = 6;
			ProductionAmount.Name = "ProductionAmount";
			ProductionAmount.ReadOnly = true;
			// 
			// ProductionKg
			// 
			ProductionKg.HeaderText = "Выработано (кг.)";
			ProductionKg.MinimumWidth = 6;
			ProductionKg.Name = "ProductionKg";
			ProductionKg.ReadOnly = true;
			// 
			// DefectAmount
			// 
			DefectAmount.HeaderText = "Брак (шт.)";
			DefectAmount.MinimumWidth = 6;
			DefectAmount.Name = "DefectAmount";
			DefectAmount.ReadOnly = true;
			// 
			// DefectKg
			// 
			DefectKg.HeaderText = "Брак (кг.)";
			DefectKg.MinimumWidth = 6;
			DefectKg.Name = "DefectKg";
			DefectKg.ReadOnly = true;
			// 
			// labourIntensity
			// 
			labourIntensity.HeaderText = "Норма трудоемкости";
			labourIntensity.MinimumWidth = 6;
			labourIntensity.Name = "labourIntensity";
			labourIntensity.ReadOnly = true;
			// 
			// Plan
			// 
			Plan.HeaderText = "План";
			Plan.MinimumWidth = 6;
			Plan.Name = "Plan";
			Plan.ReadOnly = true;
			// 
			// Fact
			// 
			Fact.HeaderText = "Факт";
			Fact.MinimumWidth = 6;
			Fact.Name = "Fact";
			Fact.ReadOnly = true;
			// 
			// ButtonFlowLayout
			// 
			ButtonFlowLayout.Controls.Add(AddBtn);
			ButtonFlowLayout.Controls.Add(EditBtn);
			ButtonFlowLayout.Controls.Add(DeleteBtn);
			ButtonFlowLayout.Controls.Add(GetInfoBtn);
			ButtonFlowLayout.Controls.Add(PrintDocBtn);
			ButtonFlowLayout.Dock = DockStyle.Fill;
			ButtonFlowLayout.Location = new Point(0, 0);
			ButtonFlowLayout.Margin = new Padding(0);
			ButtonFlowLayout.Name = "ButtonFlowLayout";
			ButtonFlowLayout.Size = new Size(1482, 69);
			ButtonFlowLayout.TabIndex = 4;
			// 
			// AddBtn
			// 
			AddBtn.Location = new Point(0, 0);
			AddBtn.Margin = new Padding(0);
			AddBtn.MinimumSize = new Size(250, 50);
			AddBtn.Name = "AddBtn";
			AddBtn.Size = new Size(250, 50);
			AddBtn.TabIndex = 0;
			AddBtn.Text = "Добавить";
			AddBtn.UseVisualStyleBackColor = true;
			AddBtn.Click += AddBtn_Click;
			// 
			// EditBtn
			// 
			EditBtn.Location = new Point(250, 0);
			EditBtn.Margin = new Padding(0);
			EditBtn.MinimumSize = new Size(250, 50);
			EditBtn.Name = "EditBtn";
			EditBtn.Size = new Size(250, 50);
			EditBtn.TabIndex = 1;
			EditBtn.Text = "Изменить";
			EditBtn.UseVisualStyleBackColor = true;
			EditBtn.Click += EditBtn_Click;
			// 
			// DeleteBtn
			// 
			DeleteBtn.Location = new Point(500, 0);
			DeleteBtn.Margin = new Padding(0);
			DeleteBtn.MinimumSize = new Size(250, 50);
			DeleteBtn.Name = "DeleteBtn";
			DeleteBtn.Size = new Size(250, 50);
			DeleteBtn.TabIndex = 2;
			DeleteBtn.Text = "Удалить";
			DeleteBtn.UseVisualStyleBackColor = true;
			DeleteBtn.Click += DeleteBtn_Click;
			// 
			// GetInfoBtn
			// 
			GetInfoBtn.Dock = DockStyle.Left;
			GetInfoBtn.Location = new Point(750, 0);
			GetInfoBtn.Margin = new Padding(0);
			GetInfoBtn.MinimumSize = new Size(250, 50);
			GetInfoBtn.Name = "GetInfoBtn";
			GetInfoBtn.Size = new Size(250, 50);
			GetInfoBtn.TabIndex = 4;
			GetInfoBtn.Text = "Информация";
			GetInfoBtn.UseVisualStyleBackColor = true;
			GetInfoBtn.Click += SummaryTable_CellDoubleClick;
			// 
			// PrintDocBtn
			// 
			PrintDocBtn.Dock = DockStyle.Left;
			PrintDocBtn.Location = new Point(1000, 0);
			PrintDocBtn.Margin = new Padding(0);
			PrintDocBtn.MinimumSize = new Size(250, 50);
			PrintDocBtn.Name = "PrintDocBtn";
			PrintDocBtn.Size = new Size(250, 50);
			PrintDocBtn.TabIndex = 3;
			PrintDocBtn.Text = "Печать";
			PrintDocBtn.UseVisualStyleBackColor = true;
			PrintDocBtn.Click += PrintDocBtn_Click;
			// 
			// ppd
			// 
			ppd.AutoScrollMargin = new Size(0, 0);
			ppd.AutoScrollMinSize = new Size(0, 0);
			ppd.ClientSize = new Size(400, 300);
			ppd.Document = reportDocument;
			ppd.Enabled = true;
			ppd.Icon = (Icon)resources.GetObject("ppd.Icon");
			ppd.Name = "ppd";
			ppd.Visible = false;
			// 
			// reportDocument
			// 
			reportDocument.PrintPage += reportDocument_PrintPage;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1482, 753);
			Controls.Add(MainPanels);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Отчет смены";
			MainPanels.Panel1.ResumeLayout(false);
			MainPanels.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)MainPanels).EndInit();
			MainPanels.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)SummaryTable).EndInit();
			ButtonFlowLayout.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer MainPanels;
		private FlowLayoutPanel ButtonFlowLayout;
		private Button AddBtn;
		private Button EditBtn;
		private Button DeleteBtn;
		private Button PrintDocBtn;
		public DataGridView SummaryTable;
		private Button GetInfoBtn;
		private DataGridViewTextBoxColumn Num;
		private DataGridViewTextBoxColumn Production;
		private DataGridViewTextBoxColumn Weight;
		private DataGridViewTextBoxColumn ProductionAmount;
		private DataGridViewTextBoxColumn ProductionKg;
		private DataGridViewTextBoxColumn DefectAmount;
		private DataGridViewTextBoxColumn DefectKg;
		private DataGridViewTextBoxColumn labourIntensity;
		private DataGridViewTextBoxColumn Plan;
		private DataGridViewTextBoxColumn Fact;
		private PrintPreviewDialog ppd;
		private System.Drawing.Printing.PrintDocument reportDocument;
	}
}