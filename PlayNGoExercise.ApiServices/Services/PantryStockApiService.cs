using PlayNGoExercise.ApiServices.Interfaces;
using System.Collections.Generic;
using PlayNGoExercise.Model;
using AutoMapper;
using PlayNGoExercice.Data.Entities;
using PlayNGoExercice.Data.Repositories;

namespace PlayNGoExercise.ApiServices.Services
{
	public class PantryStockApiService : IPantryStockApiService
	{
		private readonly IPantryStockRepository _pantryStockRepository;

		public PantryStockApiService(IPantryStockRepository pantryStockRepository)
		{
			_pantryStockRepository = pantryStockRepository;
		}

		public ICollection<PantryStockDto> GetAllStocks()
		{
			return Mapper.Map<ICollection<PantryStock>, ICollection<PantryStockDto>>(_pantryStockRepository.GetAllStocks());
		}

		public ICollection<PantryStockDto> GetStocksByOffice(int officeId)
		{
			return Mapper.Map<ICollection<PantryStock>, ICollection<PantryStockDto>>(_pantryStockRepository.GetStocksByOffice(officeId));
		}
	}
}
