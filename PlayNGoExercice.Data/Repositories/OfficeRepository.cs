using System.Linq;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using EntityFramework.DbContextScope;

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

		public Office AddOffice(Office office)
		{
			using (var context = _contextScopeFactory.Create(DbContextScopeOption.ForceCreateNew))
			{
				_contextLocator.Get<DataContext>().Offices.Add(office);
				context.SaveChanges();
			}

			return office;
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

		public ICollection<Office> GetMany()
		{
			ICollection<Office> officeList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				officeList = _contextLocator.Get<DataContext>().Offices.ToList();
			}

			return officeList;
		}

		
	}
}
