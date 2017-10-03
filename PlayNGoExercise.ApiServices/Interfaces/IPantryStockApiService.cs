using PlayNGoExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercise.ApiServices.Interfaces
{
	public interface IPantryStockApiService
	{
		ICollection<PantryStockDto> GetStocksByOffice(int officeId);

		ICollection<PantryStockDto> GetAllStocks();
	}
}
