using System;
using System.Collections.Generic;
using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using PlayNGoExercice.Data.Repositories;
using AutoMapper;
using PlayNGoExercice.Data.Entities;

namespace PlayNGoExercise.ApiServices.Services
{
	public class OfficeApiService : IOfficeApiService
	{
		private readonly IOfficeRepository _officeRepository;

		public OfficeApiService(IOfficeRepository officeRepository)
		{
			_officeRepository = officeRepository;
		}

		public OfficeDto GetById(int id)
		{
			return Mapper.Map<Office, OfficeDto>(_officeRepository.GetById(id));
		}

		public ICollection<OfficeDto> GetMany()
		{
			throw new NotImplementedException();
		}
	}
}
