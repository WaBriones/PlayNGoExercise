using PlayNGoExercice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Repositories
{
	public interface IPantryStockRepository
	{
		void UpdatePantryStocks(int drinkId, int officeId);

		void ReplenishStock(int officeId);

		ICollection<PantryStock> GetStocksByOffice(int officeId);

		ICollection<PantryStock> GetAllStocks();
	}
}
