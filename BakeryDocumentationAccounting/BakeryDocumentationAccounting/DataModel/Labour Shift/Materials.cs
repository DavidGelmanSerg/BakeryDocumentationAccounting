using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryDocumentationAccounting.DataModel.Labour_Shift
{
	public class Materials
	{
		public int Id { get; set; }
		public Flour? flour { get; set; }
		public List <Ingridient> ingridients { get; set;} = new List<Ingridient>();
		public List <Production> productions { get; set; } = new List<Production>();
	}
}
