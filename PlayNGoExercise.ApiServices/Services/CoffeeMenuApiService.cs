using PlayNGoExercise.ApiServices.Interfaces;
using System.Collections.Generic;
using PlayNGoExercise.Model;
using PlayNGoExercice.Data.Repositories;
using AutoMapper;
using PlayNGoExercice.Data.Entities;

namespace PlayNGoExercise.ApiServices.Services
{
	public class CoffeeMenuApiService : ICoffeeMenuApiService
	{
		private readonly ICoffeeMenuRepository _coffeeMenuRepository;

		public CoffeeMenuApiService(ICoffeeMenuRepository coffeeMenuRepository)
		{
			_coffeeMenuRepository = coffeeMenuRepository;
		}

		public ICollection<CoffeeMenuDto> GetAll()
		{
			return Mapper.Map< ICollection<CoffeeMenu>, ICollection<CoffeeMenuDto>>(_coffeeMenuRepository.GetAll());
		}
	}
}
