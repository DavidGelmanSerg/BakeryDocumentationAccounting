using BakeryDocumentationAccounting.DataModel.Labour_Shift;
using BakeryDocumentationAccounting.Forms;
namespace BakeryDocumentationAccounting
{
	internal static class Program
	{
		public static LabourShiftModelContext DataBase; // Объект контекста БД
		public static MainForm main;										//глобальная ссылка на форму ввода
		[STAThread]
		static void Main()
		{
			//Создание и инициализация БД
			DataBase = new LabourShiftModelContext();
			DataBase.Init();
			
			//Конфигурация и запуск приложения
			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
		}
	}
}