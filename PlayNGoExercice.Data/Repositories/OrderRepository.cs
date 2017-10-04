using System.Collections.Generic;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;
using System.Linq;
using EntityFramework.DbContextScope;
using System.Data.Entity;
using System.Text;

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
				orders = _contextLocator.Get<DataContext>().Orders
					.Include(x => x.CoffeeMenu)
					.Where(x => x.OfficeId == officeId).ToList();
			}

			return orders;
		}

		public IEnumerable<CustomOrderObject> GetAllOrders()
		{
			IEnumerable<CustomOrderObject> orders;
			var sqlQuery = new StringBuilder();
			sqlQuery.AppendLine("SELECT	query.OfficeId,")
					.AppendLine("		query.OfficeName,")
					.AppendLine("		COUNT(query.DrinkName) AS DrinkCount,")
					.AppendLine("		query.DrinkName")
					.AppendLine("FROM (")
					.AppendLine("		SELECT ROW_NUMBER() OVER (PARTITION BY o.officeId order by oe.officeName) AS rn,")
					.AppendLine("		oe.OfficeName,")
					.AppendLine("		oe.OfficeId,")
					.AppendLine("		cm.DrinkId,")
					.AppendLine("		cm.DrinkName")
					.AppendLine("FROM dbo.Orders o")
					.AppendLine("	JOIN dbo.Office oe ON o.OfficeId = oe.OfficeId")
					.AppendLine("	JOIN dbo.CoffeeMenu cm ON cm.DrinkId = o.DrinkId")
					.AppendLine(") as query")
					.AppendLine("GROUP BY query.drinkId, query.DrinkName, query.OfficeName, query.OfficeId");
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				orders = _contextLocator.Get<DataContext>().Database.SqlQuery<CustomOrderObject>(sqlQuery.ToString()).ToList();
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
