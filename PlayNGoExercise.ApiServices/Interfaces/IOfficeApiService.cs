using PlayNGoExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercise.ApiServices.Interfaces
{
	public interface IOfficeApiService
	{
		OfficeDto GetById(int id);
		ICollection<OfficeDto> GetMany();

		OfficeDto AddOffice(OfficeDto name);
	}
}
