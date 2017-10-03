using AutoMapper;
using PlayNGoExercice.Data.Entities;
using PlayNGoExercise.Model;

namespace PlayNGoExercise.ApiServices.Mappers
{
	public class ApiServiceMappers : Profile
	{
		public ApiServiceMappers()
		{
			// Entity -> DTO
			CreateMap<Office, OfficeDto>();
			CreateMap<Pantry, PantryDto>();

			// DTO -> Entity
			CreateMap<OfficeDto, Office>();
			CreateMap<PantryDto, Pantry>();
		}
	}
}
