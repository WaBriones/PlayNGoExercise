using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Entities
{
	public class CustomOrderObject
	{
		public int OfficeId { get; set; }
		public string OfficeName { get; set; }

		public int DrinkCount { get; set; }
		public string DrinkName { get; set; }
	}
}
