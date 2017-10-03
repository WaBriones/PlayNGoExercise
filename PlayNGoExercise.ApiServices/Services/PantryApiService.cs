using System;
using System.Collections.Generic;
using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using PlayNGoExercice.Data.Repositories;
using AutoMapper;
using PlayNGoExercice.Data.Entities;

namespace PlayNGoExercise.ApiServices.Services
{
	public class PantryApiService : IPantryApiService
	{
		private readonly IPantryRepository _pantryRepository;

		public PantryApiService(IPantryRepository pantryRepository)
		{
			_pantryRepository = pantryRepository;
		}

		public PantryDto AddPantryToOffice(PantryDto pantryDto)
		{
			var pantry = Mapper.Map<PantryDto, Pantry>(pantryDto);

			return Mapper.Map<Pantry, PantryDto>(_pantryRepository.AddPantryToOffice(pantry));
		}

		public PantryDto GetById(int id)
		{
			return Mapper.Map<Pantry, PantryDto>(_pantryRepository.GetById(id));
		}

		public ICollection<PantryDto> GetByOffice(int officeId)
		{
			return Mapper.Map<ICollection<Pantry>, ICollection<PantryDto>>(_pantryRepository.GetByOffice(officeId));
		}
	}
}
