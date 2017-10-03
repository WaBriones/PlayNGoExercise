using AutoMapper;
using PlayNGoExercice.Data.Entities;
using PlayNGoExercise.Model;

namespace PlayNGoExercise.ApiServices.Mappers
{
	public class ApiServiceMappers : Profile
	{
		public ApiServiceMappers()
		{
			CreateMap<Office, OfficeDto>();
			CreateMap<Pantry, PantryDto>();
		}
	}
}
