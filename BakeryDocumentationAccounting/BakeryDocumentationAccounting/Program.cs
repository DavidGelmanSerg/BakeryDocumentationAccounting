using BakeryDocumentationAccounting.DataModel.Labour_Shift;
using BakeryDocumentationAccounting.Forms;
namespace BakeryDocumentationAccounting
{
	internal static class Program
	{
		public static LabourShiftModelContext DataBase; // ������ ��������� ��
		public static MainForm main;										//���������� ������ �� ����� �����
		[STAThread]
		static void Main()
		{
			//�������� � ������������� ��
			DataBase = new LabourShiftModelContext();
			DataBase.Init();
			
			//������������ � ������ ����������
			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
		}
	}
}