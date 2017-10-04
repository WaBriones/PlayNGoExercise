using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using System;
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

		public ICollection<OrderHistoryDto> Get(int id)
		{
			return _orderApiService.GetOrdersByOffice(id);
		}

		[HttpPost]
		public void PlaceOrder([FromBody] OrderHistoryDto order)
		{
			order.DateOrdered = DateTime.UtcNow;
			_orderApiService.PlaceOrder(order);
		}

		public IEnumerable<OrdersDto> GetAllOrders()
		{
			return _orderApiService.GetAggregatedOrders();
		}
	}
}
