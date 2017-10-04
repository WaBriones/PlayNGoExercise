using PlayNGoExercise.Model;
using System.Collections.Generic;

namespace PlayNGoExercise.ApiServices.Interfaces
{
	public interface IOrdersApiService
	{
		void PlaceOrder(OrdersDto order);

		ICollection<OrdersDto> GetOrdersByOffice(int officeId);

		IEnumerable<OrdersDto> GetAggregatedOrders();
	}
}
