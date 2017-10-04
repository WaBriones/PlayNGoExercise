using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayNGoExercise.WebApi.Controllers
{
    public class CoffeeMenuController : ApiController
    {
		private readonly ICoffeeMenuApiService _coffeeMenuApiService;

		public CoffeeMenuController(ICoffeeMenuApiService coffeeMenuApiService)
		{
			_coffeeMenuApiService = coffeeMenuApiService;
		}

		public ICollection<CoffeeMenuDto> GetAll()
		{
			return _coffeeMenuApiService.GetAll();
		}
	}
}
