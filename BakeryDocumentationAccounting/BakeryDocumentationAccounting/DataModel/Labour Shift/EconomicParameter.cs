using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BakeryDocumentationAccounting.DataModel.Labour_Shift
{
	public class EconomicParameter
	{
		public int Id { get; set; }
		public string? name { get; set; }
		public decimal? value { get; set; }

		public List <Production> production { get; set; } = new List<Production> { };
	}
}
