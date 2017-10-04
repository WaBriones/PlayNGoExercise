using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace PlayNGoExercise.WebApi.Controllers
{
	public class OrderController : ApiController
    {
		private readonly IOrdersApiService _orderApiService;

		public OrderController(IOrdersApiService orderApiService)
		{
			_orderApiService = orderApiService;
		}

		public ICollection<OrdersDto> Get(int id)
		{
			return _orderApiService.GetOrdersByOffice(id);
		}

		[HttpPost]
		public void PlaceOrder([FromBody] OrdersDto order)
		{
			_orderApiService.PlaceOrder(order);
		}

		public IEnumerable<OrdersDto> GetAllOrders()
		{
			return _orderApiService.GetAggregatedOrders();
		}
	}
}
