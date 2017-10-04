using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Entities
{
	[Table("Orders")]
	public class Orders
	{
		[Key]
		public int OrderId { get; set; }

		[ForeignKey("CoffeeMenu")]
		public int DrinkId { get; set; }

		[ForeignKey("Office")]
		public int OfficeId { get; set; }

		[StringLength(300)]
		public string CustomerName { get; set; }

		public DateTime? DateOrdered { get; set; }

		public virtual CoffeeMenu CoffeeMenu { get; set; }

		public virtual Office Office { get; set; }
	}
}
