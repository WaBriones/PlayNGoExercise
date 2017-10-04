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
			CreateMap<Orders, OrdersDto>();
			CreateMap<CoffeeMenu, CoffeeMenuDto>();
			CreateMap<PantryStock, PantryStockDto>()
				.ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Ingredient.IngredientName))
				.ForMember(dest => dest.OfficeName, opt => opt.MapFrom(src => src.Office.OfficeName));
			CreateMap<CustomOrderObject, OrdersDto>();

			// DTO -> Entity
			CreateMap<OfficeDto, Office>();
			CreateMap<PantryDto, Pantry>();
			CreateMap<OrdersDto, Orders>();
			CreateMap<CoffeeMenuDto, CoffeeMenu>();
			CreateMap<PantryStockDto, PantryStock>();
		}
	}
}
