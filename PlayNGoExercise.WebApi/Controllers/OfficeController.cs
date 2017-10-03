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
    public class OfficeController : ApiController
    {
		private readonly IOfficeApiService _officeApiService;

		public OfficeController(IOfficeApiService officeApiService)
		{
			_officeApiService = officeApiService;
		}

		public OfficeDto Get(int id)
		{
			return _officeApiService.GetById(id);
		}

		public ICollection<OfficeDto> GetMany()
		{
			return _officeApiService.GetMany();
		}

		[HttpPost]
		public OfficeDto AddOffice([FromBody] OfficeDto office)
		{
			return _officeApiService.AddOffice(office);
		}
	}
}
