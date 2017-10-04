using AutoMapper;
using PlayNGoExercice.Data.Entities;
using PlayNGoExercice.Data.Repositories;
using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using System.Collections.Generic;

namespace PlayNGoExercise.ApiServices.Services
{
	public class OrdersApiService : IOrdersApiService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IPantryStockRepository _pantryStockRepository;

		public OrdersApiService(IOrderRepository orderRepository,
			IPantryStockRepository pantryStockRepository)
		{
			_orderRepository = orderRepository;
			_pantryStockRepository = pantryStockRepository;
		}

		public ICollection<OrderHistoryDto> GetOrdersByOffice(int officeId)
		{
			return Mapper.Map<ICollection<Orders>, ICollection<OrderHistoryDto>>(_orderRepository.GetByOffice(officeId));
		}

		public void PlaceOrder(OrderHistoryDto order)
		{
			// Save to Orders
			_orderRepository.PlaceOrder(Mapper.Map<OrderHistoryDto, Orders>(order));

			// Deduct from inventory
			_pantryStockRepository.UpdatePantryStocks(order.DrinkId, order.OfficeId);

		}

		public IEnumerable<OrdersDto> GetAggregatedOrders()
		{
			var allOrders = _orderRepository.GetAllOrders();

			return Mapper.Map<IEnumerable<CustomOrderObject>, IEnumerable<OrdersDto>>(allOrders);
		}
	}
}
