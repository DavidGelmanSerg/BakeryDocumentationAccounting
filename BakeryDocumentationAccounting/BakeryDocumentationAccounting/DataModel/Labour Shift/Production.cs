using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryDocumentationAccounting.DataModel.Labour_Shift
{
	public class Production
	{
		public int Id { get; set; }
		public string? name { get; set; }
		public decimal weight { get; set; }
		public int restBeforeShift { get; set; }
		public int prodAmount { get; set; }
		public decimal prodKg { get; set; }
		public int defectAmount { get; set; }
		public decimal defectKg { get; set; }
		public int output { get; set; }
		public int restAfterShift { get; set; }
		public Materials? materials { get; set; }
		public List<EconomicParameter> economicParameteres { get; set; } = new List<EconomicParameter> { };

		public static Production copyOf(Production from)
		{
			return new Production
			{
				Id = from.Id,
				name = from.name,
				weight = from.weight,
				restBeforeShift = from.restBeforeShift,
				prodAmount = from.prodAmount,
				prodKg = from.prodKg,
				defectAmount = from.defectAmount,
				defectKg = from.defectKg,
				output = from.output,
				restAfterShift = from.restAfterShift,
				materials = from.materials,
				economicParameteres = from.economicParameteres,
			};
		}
	}
}
