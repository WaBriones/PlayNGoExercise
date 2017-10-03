using System.Collections.Generic;
using PlayNGoExercise.Model;
using PlayNGoExercice.Data.Repositories;
using AutoMapper;
using PlayNGoExercice.Data.Entities;
using PlayNGoExercise.ApiServices.Interfaces;
using System;

namespace PlayNGoExercise.ApiServices.Services
{
	public class OfficeApiService : IOfficeApiService
	{
		private readonly IOfficeRepository _officeRepository;

		public OfficeApiService(IOfficeRepository officeRepository)
		{
			_officeRepository = officeRepository;
		}

		public OfficeDto AddOffice(OfficeDto officeDto)
		{
			var office = Mapper.Map<OfficeDto, Office>(officeDto);

			return Mapper.Map<Office, OfficeDto>(_officeRepository.AddOffice(office));
		}

		public OfficeDto GetById(int id)
		{
			return Mapper.Map<Office, OfficeDto>(_officeRepository.GetById(id));
		}

		public ICollection<OfficeDto> GetMany()
		{
			return Mapper.Map<ICollection<Office>, ICollection<OfficeDto>>(_officeRepository.GetMany());
		}
	}
}
