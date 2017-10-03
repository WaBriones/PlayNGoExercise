using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;

namespace PlayNGoExercice.Data.Repositories
{
	public class DrinkCostRepository : IDrinkCostRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public DrinkCostRepository(
			IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public IEnumerable<DrinkCost> GetByDrinkId(int drinkId)
		{
			IEnumerable<DrinkCost> drinkCostList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				drinkCostList = _contextLocator.Get<DataContext>().DrinkCosts.Where(x => x.DrinkId == drinkId).ToList();
			}

			return drinkCostList;
		}
	}
}
