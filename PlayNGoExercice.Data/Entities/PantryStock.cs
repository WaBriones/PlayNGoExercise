using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Entities
{
	[Table("PantryStock")]
	public class PantryStock
	{
		[Key]
		public int PantryStockId { get; set; }

		[ForeignKey("Office")]
		public int OfficeId { get; set; }

		[ForeignKey("Ingredient")]
		public int IngredientId { get; set; }

		public int Amount { get; set; }

		public virtual Office Office { get; set; }

		public virtual Ingredient Ingredient { get; set; }
	}
}
