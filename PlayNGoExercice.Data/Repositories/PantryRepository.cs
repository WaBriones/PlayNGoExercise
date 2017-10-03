using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;
using EntityFramework.DbContextScope;

namespace PlayNGoExercice.Data.Repositories
{
	public class PantryRepository : IPantryRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public PantryRepository(IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public Pantry AddPantryToOffice(Pantry pantry)
		{
			using (var context = _contextScopeFactory.Create(DbContextScopeOption.ForceCreateNew))
			{
				_contextLocator.Get<DataContext>().Pantry.Add(pantry);
				context.SaveChanges();
			}

			return pantry;
		}

		public Pantry GetById(int id)
		{
			Pantry pantry;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				pantry = _contextLocator.Get<DataContext>().Pantry.FirstOrDefault(x => x.OfficeId == id);
			}

			return pantry;
		}

		public ICollection<Pantry> GetByOffice(int officeId)
		{
			ICollection<Pantry> pantryList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				pantryList = _contextLocator.Get<DataContext>().Pantry.Where(x => x.OfficeId == officeId).ToList();
			}

			return pantryList;
		}
	}
}
