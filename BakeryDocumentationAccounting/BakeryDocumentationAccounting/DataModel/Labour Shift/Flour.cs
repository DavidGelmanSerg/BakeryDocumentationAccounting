using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryDocumentationAccounting.DataModel.Labour_Shift
{
	public class Flour
	{
		public int Id { get; set; }
		public string? name { get; set; }
		public decimal? humidity { get; set; }
		public List <Materials> materials { get; set; } = new List <Materials> ();
	}
}
