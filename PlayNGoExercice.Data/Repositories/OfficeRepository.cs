using System.Linq;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;

namespace PlayNGoExercice.Data.Repositories
{
	public class OfficeRepository : IOfficeRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public OfficeRepository(
			IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public Office GetById(int id)
		{
			Office office;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				office = _contextLocator.Get<DataContext>().Offices.FirstOrDefault(x => x.OfficeId == id);
			}

			return office;
		}
	}
}
