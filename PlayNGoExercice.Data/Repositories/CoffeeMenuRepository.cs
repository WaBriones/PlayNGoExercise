using System.Collections.Generic;
using System.Linq;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;

namespace PlayNGoExercice.Data.Repositories
{
	public class CoffeeMenuRepository : ICoffeeMenuRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public CoffeeMenuRepository(
			IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public ICollection<CoffeeMenu> GetAll()
		{
			ICollection<CoffeeMenu> drinkCostList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				drinkCostList = _contextLocator.Get<DataContext>().CoffeeMenu.ToList();
			}

			return drinkCostList;
		}
	}
}
