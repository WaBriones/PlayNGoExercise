using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Entities
{
	[Table("Ingredient")]
	public class Ingredient
	{
		public Ingredient()
		{
			DrinkCosts = new HashSet<DrinkCost>();
			PantryStocks = new HashSet<PantryStock>();
		}

		[Key]
		public int IngredientId { get; set; }

		[StringLength(300)]
		public string IngredientName { get; set; }

		public virtual ICollection<DrinkCost> DrinkCosts { get; set; }

		public virtual ICollection<PantryStock> PantryStocks { get; set; }

	}
}
