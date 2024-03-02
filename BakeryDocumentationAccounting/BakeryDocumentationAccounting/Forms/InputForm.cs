using BakeryDocumentationAccounting.DataModel.Labour_Shift;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryDocumentationAccounting.Forms
{
	public partial class InputForm : Form
	{
		public enum Action
		{
			EDIT,
			ADD
		}
		public InputForm(Action action)
		{
			InitializeComponent();

			//Установка обработчика события для кнопки "Сохранить".
			if (action == Action.EDIT)
			{
				SaveInputBtn.Click += EditProductBtn_Click;
				NameTb.Enabled = false;
			}
			else if (action == Action.ADD)
			{
				SaveInputBtn.Click += AddProductBtn_Click;
			}
		}

		//Обработчик события нажатия на кнопку "Сохранить". Добавление продукции
		private void AddProductBtn_Click(object sender, EventArgs e)
		{
			try
			{
				//Получение параметров
				String pName = NameTb.Text;
				Production product = Program.DataBase.production.FirstOrDefault(pr => pr.name == pName);

				if (product != null)
				{
					MessageBox.Show("Продукция с таким названием уже добавлена в отчет смены");
					return;
				}

				decimal pWeight = (WeightTb.Text == "") ? 0 : decimal.Parse(WeightTb.Text);
				int productionAmount = (ProductionTb.Text == "") ? 0 : int.Parse(ProductionTb.Text);
				int defectiveAmount = (DefeciveTb.Text == "") ? 0 : int.Parse(DefeciveTb.Text);
				decimal laborIntensity = (laborIntensityTb.Text == "") ? 0 : decimal.Parse(laborIntensityTb.Text);
				decimal plan = (PlanTb.Text == "") ? 0 : decimal.Parse(PlanTb.Text);
				decimal fact = (FactTb.Text == "") ? 0 : decimal.Parse(FactTb.Text);
				decimal flourAmount = (FlourGeneralTb.Text == "") ? 0 : decimal.Parse(FlourGeneralTb.Text);
				int restBeforeShift = (restBeforeShiftTb.Text == "") ? 0 : int.Parse(restBeforeShiftTb.Text);
				int outputProfit = (OutputProfitTb.Text == "") ? 0 : int.Parse(OutputProfitTb.Text);

				Flour? flourType = Program.DataBase.flours.FirstOrDefault(f => f.name == FlourTypeCmb.SelectedItem.ToString());

				List<Ingridient> ingridients = new List<Ingridient>();

				ingridients.Add(new Ingridient { name = "Масло Растительное", value = (oilTb.Text == "") ? 0 : decimal.Parse(oilTb.Text) });
				ingridients.Add(new Ingridient { name = "Дрожжи прес.", value = (YeastsTb.Text == "") ? 0 : decimal.Parse(YeastsTb.Text) });
				ingridients.Add(new Ingridient { name = "Соль", value = (SaultTb.Text == "") ? 0 : decimal.Parse(SaultTb.Text) });
				ingridients.Add(new Ingridient { name = "Сахар", value = (SugarTb.Text == "") ? 0 : decimal.Parse(SugarTb.Text) });
				ingridients.Add(new Ingridient { name = "Streumix", value = (StreumixTb.Text == "") ? 0 : decimal.Parse(StreumixTb.Text) });
				ingridients.Add(new Ingridient { name = "Seedmix", value = (SeedmixTb.Text == "") ? 0 : decimal.Parse(SeedmixTb.Text) });
				ingridients.Add(new Ingridient { name = "Сусло", value = (WortTb.Text == "") ? 0 : decimal.Parse(WortTb.Text) });
				ingridients.Add(new Ingridient { name = "Тмин", value = (CuminTb.Text == "") ? 0 : decimal.Parse(CuminTb.Text) });
				ingridients.Add(new Ingridient { name = "Патока", value = (MolassesTb.Text == "") ? 0 : decimal.Parse(MolassesTb.Text) });
				ingridients.Add(new Ingridient { name = "Солод", value = (MaltTb.Text == "") ? 0 : decimal.Parse(MaltTb.Text) });
				ingridients.Add(new Ingridient { name = "Хмель", value = (HopsTb.Text == "") ? 0 : decimal.Parse(HopsTb.Text) });
				ingridients.Add(new Ingridient { name = "Кориандер", value = (CorianderTb.Text == "") ? 0 : decimal.Parse(CorianderTb.Text) });
				ingridients.Add(new Ingridient { name = "Чернослив", value = (PrunesTb.Text == "") ? 0 : decimal.Parse(PrunesTb.Text) });
				ingridients.Add(new Ingridient { name = "Изюм", value = (RaisinTb.Text == "") ? 0 : decimal.Parse(RaisinTb.Text) });
				ingridients.Add(new Ingridient { name = "Айва", value = (QuinceTb.Text == "") ? 0 : decimal.Parse(QuinceTb.Text) });
				ingridients.Add(new Ingridient { name = "Протектор", value = (ProtectorTb.Text == "") ? 0 : decimal.Parse(ProtectorTb.Text) });
				ingridients.Add(new Ingridient { name = "Вазелин", value = (VaselineTb.Text == "") ? 0 : decimal.Parse(VaselineTb.Text) });
				ingridients.Add(new Ingridient { name = "Belpan Cleo", value = (BelpanCleoTb.Text == "") ? 0 : decimal.Parse(BelpanCleoTb.Text) });
				ingridients.Add(new Ingridient { name = "Belpan Trans", value = (BelpanTransTb.Text == "") ? 0 : decimal.Parse(BelpanTransTb.Text) });
				ingridients.Add(new Ingridient { name = "Отходы", value = decimal.Parse(WasteTb.Text) });
				ingridients.Add(new Ingridient { name = "Мука общая", value = decimal.Parse(FlourGeneralTb.Text) });
				ingridients.Add(new Ingridient { name = "Семечки", value = (SeedsTb.Text == "") ? 0 : decimal.Parse(SeedsTb.Text) });

				Materials materials = new Materials
				{
					flour = flourType,

					ingridients = ingridients
				};

				List<EconomicParameter> economicParameteres = new List<EconomicParameter>();

				economicParameteres.Add(new EconomicParameter { name = "План", value = decimal.Parse(PlanTb.Text) });
				economicParameteres.Add(new EconomicParameter { name = "Факт", value = decimal.Parse(FactTb.Text) });
				economicParameteres.Add(new EconomicParameter { name = "Норма трудоемкости", value = decimal.Parse(laborIntensityTb.Text) });

				//Создание продукта с полученными параметрами
				Production p = new Production
				{
					name = pName,
					weight = pWeight,
					restBeforeShift = restBeforeShift,
					prodAmount = productionAmount,
					defectAmount = defectiveAmount,
					prodKg = productionAmount * pWeight,
					defectKg = defectiveAmount * pWeight,
					output = outputProfit,
					restAfterShift = restBeforeShift + productionAmount - outputProfit,
					materials = materials,
					economicParameteres = economicParameteres
				};

				//Добавление продукции в БД. Сохранение изменений
				Program.DataBase.production.Add(p);
				Program.DataBase.SaveChanges();

				//Переход на сводную таблицу
				Program.main.SummaryTable.Columns.Clear();
				Program.main.SummaryTable.DataSource = Program.DataBase.getSummary();

				//Закрытие формы ввода. Высвобождение ресурсов
				this.Close();
				this.Dispose();
			}
			catch (FormatException except)
			{
				MessageBox.Show("Какое-то из полей не заполнено или заполнено неверно");
			}
		}

		//Обработчик события нажатия на кнопку "Сохранить". Изменение продукции
		private void EditProductBtn_Click(object sender, EventArgs e)
		{
			try
			{
				//Получение параметров
				String pName = NameTb.Text;
				Production productToEdit = Program.DataBase.production.FirstOrDefault(pr => pr.name == pName);
				if (productToEdit != null)
				{
					decimal pWeight = (WeightTb.Text == "") ? 0 : decimal.Parse(WeightTb.Text);
					int productionAmount = (ProductionTb.Text == "") ? 0 : int.Parse(ProductionTb.Text);
					int defectiveAmount = (DefeciveTb.Text == "") ? 0 : int.Parse(DefeciveTb.Text);
					decimal laborIntensity = (laborIntensityTb.Text == "") ? 0 : decimal.Parse(laborIntensityTb.Text);
					decimal plan = (PlanTb.Text == "") ? 0 : decimal.Parse(PlanTb.Text);
					decimal fact = (FactTb.Text == "") ? 0 : decimal.Parse(FactTb.Text);
					decimal flourAmount = (FlourGeneralTb.Text == "") ? 0 : decimal.Parse(FlourGeneralTb.Text);
					int restBeforeShift = (restBeforeShiftTb.Text == "") ? 0 : int.Parse(restBeforeShiftTb.Text);
					int outputProfit = (OutputProfitTb.Text == "") ? 0 : int.Parse(OutputProfitTb.Text);

					Flour? flourType = Program.DataBase.flours.FirstOrDefault(f => f.name == FlourTypeCmb.SelectedItem.ToString());
					List<Ingridient> ingridients = new List<Ingridient>();

					ingridients.Add(new Ingridient { name = "Масло Растительное", value = (oilTb.Text == "") ? 0 : decimal.Parse(oilTb.Text) });
					ingridients.Add(new Ingridient { name = "Дрожжи прес.", value = (YeastsTb.Text == "") ? 0 : decimal.Parse(YeastsTb.Text) });
					ingridients.Add(new Ingridient { name = "Соль", value = (SaultTb.Text == "") ? 0 : decimal.Parse(SaultTb.Text) });
					ingridients.Add(new Ingridient { name = "Сахар", value = (SugarTb.Text == "") ? 0 : decimal.Parse(SugarTb.Text) });
					ingridients.Add(new Ingridient { name = "Streumix", value = (StreumixTb.Text == "") ? 0 : decimal.Parse(StreumixTb.Text) });
					ingridients.Add(new Ingridient { name = "Seedmix", value = (SeedmixTb.Text == "") ? 0 : decimal.Parse(SeedmixTb.Text) });
					ingridients.Add(new Ingridient { name = "Сусло", value = (WortTb.Text == "") ? 0 : decimal.Parse(WortTb.Text) });
					ingridients.Add(new Ingridient { name = "Тмин", value = (CuminTb.Text == "") ? 0 : decimal.Parse(CuminTb.Text) });
					ingridients.Add(new Ingridient { name = "Патока", value = (MolassesTb.Text == "") ? 0 : decimal.Parse(MolassesTb.Text) });
					ingridients.Add(new Ingridient { name = "Солод", value = (MaltTb.Text == "") ? 0 : decimal.Parse(MaltTb.Text) });
					ingridients.Add(new Ingridient { name = "Хмель", value = (HopsTb.Text == "") ? 0 : decimal.Parse(HopsTb.Text) });
					ingridients.Add(new Ingridient { name = "Кориандер", value = (CorianderTb.Text == "") ? 0 : decimal.Parse(CorianderTb.Text) });
					ingridients.Add(new Ingridient { name = "Чернослив", value = (PrunesTb.Text == "") ? 0 : decimal.Parse(PrunesTb.Text) });
					ingridients.Add(new Ingridient { name = "Изюм", value = (RaisinTb.Text == "") ? 0 : decimal.Parse(RaisinTb.Text) });
					ingridients.Add(new Ingridient { name = "Айва", value = (QuinceTb.Text == "") ? 0 : decimal.Parse(QuinceTb.Text) });
					ingridients.Add(new Ingridient { name = "Протектор", value = (ProtectorTb.Text == "") ? 0 : decimal.Parse(ProtectorTb.Text) });
					ingridients.Add(new Ingridient { name = "Вазелин", value = (VaselineTb.Text == "") ? 0 : decimal.Parse(VaselineTb.Text) });
					ingridients.Add(new Ingridient { name = "Belpan Cleo", value = (BelpanCleoTb.Text == "") ? 0 : decimal.Parse(BelpanCleoTb.Text) });
					ingridients.Add(new Ingridient { name = "Belpan Trans", value = (BelpanTransTb.Text == "") ? 0 : decimal.Parse(BelpanTransTb.Text) });
					ingridients.Add(new Ingridient { name = "Отходы", value = decimal.Parse(WasteTb.Text) });
					ingridients.Add(new Ingridient { name = "Мука общая", value = decimal.Parse(FlourGeneralTb.Text) });
					ingridients.Add(new Ingridient { name = "Семечки", value = (SeedsTb.Text == "") ? 0 : decimal.Parse(SeedsTb.Text) });

					Materials materials = new Materials
					{
						flour = flourType,

						ingridients = ingridients
					};

					List<EconomicParameter> economicParameteres = new List<EconomicParameter>();

					economicParameteres.Add(new EconomicParameter { name = "План", value = decimal.Parse(PlanTb.Text) });
					economicParameteres.Add(new EconomicParameter { name = "Факт", value = decimal.Parse(FactTb.Text) });
					economicParameteres.Add(new EconomicParameter { name = "Норма трудоемкости", value = decimal.Parse(laborIntensityTb.Text) });

					//Изменения продукта
					productToEdit.weight = pWeight;
					productToEdit.restBeforeShift = restBeforeShift;
					productToEdit.prodAmount = productionAmount;
					productToEdit.prodKg = productionAmount * pWeight;
					productToEdit.defectAmount = defectiveAmount;
					productToEdit.defectKg = defectiveAmount * pWeight;
					productToEdit.output = outputProfit;
					productToEdit.restAfterShift = restBeforeShift + productionAmount - outputProfit;
					productToEdit.materials = materials;
					productToEdit.economicParameteres = economicParameteres;

					//Сохранение изменений в БД
					Program.DataBase.Update(productToEdit);
					Program.DataBase.SaveChanges();

					//Переход на сводную таблицу
					Program.main.SummaryTable.Columns.Clear();
					Program.main.SummaryTable.DataSource = Program.DataBase.getSummary();

					//Закрытие формы ввода. Высвобождение ресурсов
					this.Close();
					this.Dispose();
				}
			}
			catch (FormatException ex)
			{
				MessageBox.Show("Какое-то из полей не заполнено или заполнено неверно");
			}
		}

		//Очистка полей ввода
		public void clearInput()
		{
			foreach (Control c in InputLayoutPanel.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					c.Text = "";
				}
			}
			FlourTypeCmb.Text = "";
		}
	}
}
