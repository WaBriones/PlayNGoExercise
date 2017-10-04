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
    public class PantryStockController : ApiController
    {
		private readonly IPantryStockApiService _iPantryStockService;

		public PantryStockController(IPantryStockApiService iPantryStockService)
		{
			_iPantryStockService = iPantryStockService;
		}

		[Route("api/pantrystock/getpantrystocks/{officeId}")]
		public ICollection<PantryStockDto> GetPantryStockByOffice(int officeId)
		{
			return _iPantryStockService.GetStocksByOffice(officeId);
		}
    }
}
