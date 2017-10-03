using System.Collections.Generic;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;
using System.Linq;
using EntityFramework.DbContextScope;

namespace PlayNGoExercice.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public OrderRepository(IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public ICollection<Orders> GetByOffice(int officeId)
		{
			ICollection<Orders> orders;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				orders = _contextLocator.Get<DataContext>().Orders.Where(x => x.OfficeId == officeId).ToList();
			}

			return orders;
		}

		public Orders PlaceOrder(Orders order)
		{
			using (var context = _contextScopeFactory.Create(DbContextScopeOption.ForceCreateNew))
			{
				_contextLocator.Get<DataContext>().Orders.Add(order);
				context.SaveChanges();
			}

			return order;
		}
	}
}
