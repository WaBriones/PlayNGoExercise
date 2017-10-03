using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Entities
{
	[Table("CofeeMenu")]
	public class DrinkMenu
	{
		public DrinkMenu()
		{
			DrinkCosts = new HashSet<DrinkCost>();
			Orders = new HashSet<Orders>();
		}

		[Key]
		public int DrinkId { get; set; }

		[StringLength(300)]
		public string DrinkName	 { get; set; }

		public virtual ICollection<DrinkCost> DrinkCosts { get; set; }

		public virtual ICollection<Orders> Orders { get; set; }
	}
}
