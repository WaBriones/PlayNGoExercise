using PlayNGoExercice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Repositories
{
	public interface IDrinkCostRepository
	{
		IEnumerable<DrinkCost> GetByDrinkId(int drinkId);
	}
}
