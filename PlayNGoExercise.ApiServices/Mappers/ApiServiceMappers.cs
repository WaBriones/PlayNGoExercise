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
				.ForMember(dest => dest.OfficeName, opt => opt.MapFrom(src => src.Office.OfficeName))
				.ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount / 15m));
			CreateMap<CustomOrderObject, OrdersDto>();
			CreateMap<Orders, OrderHistoryDto>()
				.ForMember(dest => dest.DrinkName, opt => opt.MapFrom(src => src.CoffeeMenu.DrinkName));

			// DTO -> Entity
			CreateMap<OfficeDto, Office>();
			CreateMap<PantryDto, Pantry>();
			CreateMap<OrdersDto, Orders>();
			CreateMap<CoffeeMenuDto, CoffeeMenu>();
			CreateMap<PantryStockDto, PantryStock>();
			CreateMap<OrderHistoryDto, Orders>();
			
		}
	}
}
