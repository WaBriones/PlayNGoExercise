using PlayNGoExercise.Model;
using System.Collections.Generic;

namespace PlayNGoExercise.ApiServices.Interfaces
{
	public interface IOrdersApiService
	{
		void PlaceOrder(OrderHistoryDto order);

		ICollection<OrderHistoryDto> GetOrdersByOffice(int officeId);

		IEnumerable<OrdersDto> GetAggregatedOrders();
	}
}
