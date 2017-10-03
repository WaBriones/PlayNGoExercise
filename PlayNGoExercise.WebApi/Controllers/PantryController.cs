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
    public class PantryController : ApiController
    {
		private readonly IPantryApiService _pantryApiService;

		public PantryController(IPantryApiService pantryApiService)
		{
			_pantryApiService = pantryApiService;
		}

		public PantryDto Get(int id)
		{
			return _pantryApiService.GetById(id);
		}

		[Route("api/pantry/getbyoffice/{officeId}")]
		public ICollection<PantryDto> GetByOffice(int officeId)
		{
			return _pantryApiService.GetByOffice(officeId);
		}
	}
}
