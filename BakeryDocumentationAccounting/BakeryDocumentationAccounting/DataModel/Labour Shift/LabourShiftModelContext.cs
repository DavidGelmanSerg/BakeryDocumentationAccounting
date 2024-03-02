using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BakeryDocumentationAccounting.DataModel.Labour_Shift
{
	public class LabourShiftModelContext : DbContext
	{
		//Таблицы с данными. Их описания находятся в других файлах этой же директории
		public DbSet<Production> production { get; set; } = null!;
		public DbSet<Materials> materials { get; set; } = null!;
		public DbSet<Flour> flours { get; set; } = null!;
		public DbSet<Ingridient> ingridients { get; set; } = null!;
		public DbSet<EconomicParameter> economics { get; set; } = null!;
		//--------------------------------------------------------------------------------------------------------------------------------

		//Метод конфигурации подключения к БД
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=bakeryAccountingdb;Trusted_Connection=True;");
		}

		//Инициализация БД. Заполнение БД значениями
		public void Init()
		{
			//Удаление и создание БД
			Database.EnsureDeleted();
			Database.EnsureCreated();

			//Добавление данных в таблицу Flours
			flours.AddRange(
				new Flour { name = "Ржаная", humidity = 12.9M },
				new Flour { name = "Высший сорт", humidity = 14.3M },
				new Flour { name = "Первый сорт", humidity = 14M },
				new Flour { name = "Второй сорт", humidity = 12.8M }
				);
			SaveChanges();
		}
		
		//Получение суммы всей продукции по всем полям
		public Production getProductSum()
		{
			Production result = new Production();

			result.economicParameteres.Add(new EconomicParameter { name = "План", value = 0 });
			result.economicParameteres.Add(new EconomicParameter { name = "Факт", value = 0 });
			result.economicParameteres.Add(new EconomicParameter { name = "Норма трудоемкости", value = 0 });

			foreach (Production p in production)
			{
				result.weight += p.weight;
				result.restAfterShift += p.restAfterShift;
				result.prodAmount += p.prodAmount;
				result.restBeforeShift += p.restBeforeShift;
				result.prodKg += p.prodKg;
				result.defectAmount += p.defectAmount;
				result.defectKg += p.defectKg;
				result.output += p.output;

				result.economicParameteres.FirstOrDefault(Li => Li.name == "Норма трудоемкости").value += p.economicParameteres.FirstOrDefault(Li => Li.name == "Норма трудоемкости").value;
				result.economicParameteres.FirstOrDefault(pl => pl.name == "План").value += p.economicParameteres.FirstOrDefault(pl => pl.name == "План").value;
				result.economicParameteres.FirstOrDefault(f => f.name == "Факт").value += p.economicParameteres.FirstOrDefault(f => f.name == "Факт").value;
			}
			return result;
		}
		
		//Метод, возвращающий сводную таблицу в виде объекта DataTable (Для привязки к DataGridView как источника данных)
		public DataTable getSummary()
		{
			//Создание результирующего объекта
			Production? result = production.FirstOrDefault(p => p.name == "Всего");

			//Если он не null, удаляем
			if (result != null)
			{
				production.Remove(result);
				SaveChanges();
			}
			
			//Создаем новый и вставляем в продукты
			result = getProductSum();
			result.name = "Всего";

			production.Add(result);
			SaveChanges();

			//Объект таблицы
			DataTable summary = new DataTable();

			//Добавление столбцов в таблицу
			summary.Columns.Add("№", typeof(int));
			summary.Columns.Add("Название", typeof(string));
			summary.Columns.Add("Вес", typeof(string));
			summary.Columns.Add("Выработано (шт.)", typeof(int));
			summary.Columns.Add("Выработано (кг.)", typeof(decimal));
			summary.Columns.Add("Брак (шт.)", typeof(int));
			summary.Columns.Add("Брак (кг.)", typeof(decimal));
			summary.Columns.Add("Норма трудоемкости", typeof(decimal));
			summary.Columns.Add("План", typeof(decimal));
			summary.Columns.Add("Факт", typeof(decimal));

			int i = 0;

			//Добавление строк в таблицу по всем продуктам
			foreach (Production p in production)
			{
				summary.Rows.Add(new object[] {
				++i,
				p.name,
				p.weight,
				p.prodAmount,
				p.prodKg,
				p.defectAmount,
				p.defectKg,
				p.economicParameteres.FirstOrDefault(l => l.name == "Норма трудоемкости").value,
				p.economicParameteres.FirstOrDefault(pl => pl.name == "План").value,
				p.economicParameteres.FirstOrDefault(f => f.name == "Факт").value
			});
			}
			return summary;
		}
		
		//Проверка наличия продукта
		public bool isProduct(string pname)
		{
			return (production.FirstOrDefault(p => p.name == pname) == null) ? false:true ;
		}
		
		//Метод, возвращающий таблицу с информацией о составе продукта.
		public DataTable getProductInfo(string name)
		{
			DataTable Info = new DataTable();

			//Добавление столбцов
			Info.Columns.Add("Свойство");
			Info.Columns.Add("Значение");

			//Поиск продукта по Id
			Production product = production.FirstOrDefault(p => p.name == name);
			if (product != null) {
				Info.Rows.Add(new object[]
				{
					"Мука общая (кг)",
					product.materials.ingridients.FirstOrDefault(i => i.name == "Мука общая").value.ToString()
				}) ;

				//Добавление строк по каждому ингридиенту продукта
				foreach (Ingridient i in product.materials.ingridients)
				{
					//Предполагаем, что если ингридиент = 0, то его нет в составе
					if (i.value != 0)
					{
						Info.Rows.Add(new object[]
						{
						i.name + " (кг)",
						i.value
						});
					}
				}
			}
			return Info;
		}
	
		//Получить таблицу с отчетом в виде объекта DataTable
		public DataTable getReportTable()
		{
			//Объект таблицы
			DataTable report = new DataTable();

			//Добавление столбцов в таблицу
			report.Columns.Add("№", typeof(int));
			report.Columns.Add("Название", typeof(string));
			report.Columns.Add("Остаток на начало", typeof(string));
			report.Columns.Add("Выработано (шт.)", typeof(int));
			report.Columns.Add("Выработано (кг.)", typeof(decimal));
			report.Columns.Add("Брак (шт.)", typeof(int));
			report.Columns.Add("Сдано в экспедицию", typeof(decimal));
			report.Columns.Add("Остаток на конец", typeof(decimal));

			//Добавление строк в таблицу по всем продуктам
			foreach (Production p in production)
			{
				report.Rows.Add(new object[] {
				p.Id+1,
				p.name,
				p.restBeforeShift,
				p.prodAmount,
				p.prodKg,
				p.defectAmount,
				p.output,
				p.restAfterShift
			});
			}
			return report;
		}
	}
}

