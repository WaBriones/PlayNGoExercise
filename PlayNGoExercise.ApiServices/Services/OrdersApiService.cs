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

		public ICollection<OrdersDto> GetOrdersByOffice(int officeId)
		{
			return Mapper.Map<ICollection<Orders>, ICollection<OrdersDto>>(_orderRepository.GetByOffice(officeId));
		}

		public void PlaceOrder(OrdersDto order)
		{
			// Save to Orders
			_orderRepository.PlaceOrder(Mapper.Map<OrdersDto, Orders>(order));

			// Deduct from inventory
			_pantryStockRepository.UpdatePantryStocks(order.DrinkId, order.OfficeId);

		}
	}
}
