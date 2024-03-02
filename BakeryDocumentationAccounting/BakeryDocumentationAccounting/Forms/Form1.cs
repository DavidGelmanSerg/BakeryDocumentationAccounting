using Microsoft.EntityFrameworkCore.Storage;
using System.Windows.Forms;
using BakeryDocumentationAccounting.DataModel.Labour_Shift;
using System.Numerics;
using System.Data;
using System.Drawing.Printing;

namespace BakeryDocumentationAccounting.Forms
{
	public partial class MainForm : Form
	{
		//����������� �����
		public MainForm()
		{
			Program.main = this; //��������� ���������� ������ �� �����
			InitializeComponent();
		}

		//��������� ������� ������� �� ������ "��������". ��������� ����� ����� ������
		private void AddBtn_Click(object sender, EventArgs e)
		{
			InputForm INPUT = new InputForm(InputForm.Action.ADD);
			INPUT.Show();
		}

		//��������� ������� ������� �� ������ "��������". ��������� ����� ����� ������. ��������� ���� ������� �������
		private void EditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				InputForm EDIT = new InputForm(InputForm.Action.EDIT);

				//�������� ������ ������ ������� � ��������� �� ������������
				int SelectedIndex = SummaryTable.SelectedCells[0].RowIndex;
				string? SelectedCellValue = SummaryTable[1, SelectedIndex].Value.ToString();
				if (SelectedCellValue != "" && SelectedCellValue != null && SelectedIndex != SummaryTable.RowCount)
				{
					//��������� �������� �� ������������ �� ��
					Production p = Program.DataBase.production.FirstOrDefault(p => p.name == SelectedCellValue);

					if (p != null)
					{
						EDIT.clearInput();
						
						//��������� ���������� ����� �����
						EDIT.NameTb.Text = p.name;
						EDIT.WeightTb.Text = p.weight.ToString();
						EDIT.ProductionTb.Text = p.prodAmount.ToString();
						EDIT.DefeciveTb.Text = p.defectAmount.ToString();
						EDIT.laborIntensityTb.Text = p.economicParameteres.FirstOrDefault(li => li.name == "����� ������������").value.ToString();
						EDIT.PlanTb.Text = p.economicParameteres.FirstOrDefault(pl => pl.name == "����").value.ToString();
						EDIT.FactTb.Text = p.economicParameteres.FirstOrDefault(f => f.name == "����").value.ToString();
						EDIT.restBeforeShiftTb.Text = p.restBeforeShift.ToString();
						EDIT.OutputProfitTb.Text = p.output.ToString();

						EDIT.FlourTypeCmb.Text = p.materials.flour.name;

						EDIT.FlourGeneralTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "���� �����").value.ToString();
						EDIT.oilTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "����� ������������").value.ToString();
						EDIT.YeastsTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "������ ����.").value.ToString();
						EDIT.SaultTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "����").value.ToString();
						EDIT.SugarTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�����").value.ToString();
						EDIT.StreumixTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "Streumix").value.ToString();
						EDIT.SeedmixTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "Seedmix").value.ToString();
						EDIT.WortTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�����").value.ToString();
						EDIT.CuminTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "����").value.ToString();
						EDIT.MolassesTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "������").value.ToString();
						EDIT.MaltTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�����").value.ToString();
						EDIT.HopsTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�����").value.ToString();
						EDIT.CorianderTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "���������").value.ToString();
						EDIT.PrunesTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "���������").value.ToString();
						EDIT.RaisinTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "����").value.ToString();
						EDIT.QuinceTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "����").value.ToString();
						EDIT.ProtectorTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "���������").value.ToString();
						EDIT.BelpanCleoTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "Belpan Cleo").value.ToString();
						EDIT.BelpanTransTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "Belpan Trans").value.ToString();
						EDIT.WasteTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "������").value.ToString();
						EDIT.VaselineTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�������").value.ToString();
						EDIT.SeedsTb.Text = p.materials.ingridients.FirstOrDefault(i => i.name == "�������").value.ToString();
						EDIT.Show();
					}
				}
			}
			catch (NullReferenceException ex) { }
		}

		//��������� ������� ������� �� ������ "�������". ������� ��������� �� ������ �����
		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				//��������� ������� � ������������ ��������
				int SelectedIndex = SummaryTable.SelectedCells[0].RowIndex;
				string? SelectedCellValue = SummaryTable.SelectedCells[0].Value.ToString();
				if (SelectedCellValue != "" && SelectedCellValue != null && SelectedIndex != SummaryTable.RowCount)
				{
					//�������� �������� �� ��. ���������� ���������. ���������� ������� �������
					Program.DataBase.production.Remove(Program.DataBase.production.FirstOrDefault(p => p.Id == SelectedIndex + 1));
					Program.DataBase.SaveChanges();
					SummaryTable.DataSource = Program.DataBase.getSummary();
				}
			}
			catch (NullReferenceException nrex){}
		}

		//������� ���� �� ������ ������� � ����������� � ������ �����. ����� ���������� � ������� ���������
		private void SummaryTable_CellDoubleClick(object sender, EventArgs e)
		{
			try
			{
				//�������� ������ ������ ������� ������ � ��������
				int SelectedIndex = SummaryTable.SelectedCells[0].RowIndex;
				string? SelectedCellValue = SummaryTable[1, SelectedIndex].Value.ToString();
				if (SelectedCellValue != "" && SelectedCellValue != null && SelectedIndex != SummaryTable.RowCount)
				{
					//�������� ������� � �������� ���������
					DataTable Info = Program.DataBase.getProductInfo(SelectedCellValue);

					//������� ����� � �������� ��������
					MaterialsForm infoForm = new MaterialsForm();
					infoForm.infoTable.DataSource = Info;
					infoForm.Show();
				}
			}
			catch (NullReferenceException ex) { }
		}

		//��������� ������� ������� �� ������ "������". ���������� ����� � ������� ��� � ���� ������
		private void PrintDocBtn_Click(object sender, EventArgs e)
		{
			ppd.ShowDialog();
		}

		//��������� ������� ������ ������
		private void reportDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			//�������� ������� ������� � �������
			DataGridView report = new DataGridView
			{
				DataSource = Program.DataBase.getReportTable(),
				AllowUserToAddRows = false,
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
				BackgroundColor = Color.White,
				CellBorderStyle = DataGridViewCellBorderStyle.Raised,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				GridColor = SystemColors.Control,
				RowHeadersVisible = false,
				RowHeadersWidth = 51,
				Width = 900,
				Height = 50
			};
			report.RowTemplate.Height = 29;
			this.Controls.Add(report);
			int Height = (report.Rows.Count * report.RowTemplate.Height * 2) - 7;
			report.Height = (Height == 0) ? report.Height: Height;

			//�������� ����������� ������� ��� ������
			Bitmap bmp = new Bitmap(report.Width, report.Height);
			report.DrawToBitmap(bmp, new Rectangle (0,0,report.Width, report.Height));

			e.Graphics.DrawString("�������� � ��������� ������� ���������", new Font("Times New Roman",16,FontStyle.Bold),Brushes.Black,new Point(200,20));
			e.Graphics.DrawString("1. �������� ������� ���������", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(250, 40));

			e.Graphics.DrawImage(bmp, 50, 155);
		}
	}
}