using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoExercice.Data.Entities
{
	[Table("DrinkCost")]
	public class DrinkCost
	{
		[Key]
		public int DrinkCostId { get; set; }

		[ForeignKey("DrinkMenu")]
		public int DrinkId { get; set; }

		[ForeignKey("Ingredient")]
		public int IngredientId { get; set; }

		public int Cost { get; set; }

		public virtual DrinkMenu DrinkMenu { get; set; }

		public virtual Ingredient Ingredient { get; set; }
	}
}
