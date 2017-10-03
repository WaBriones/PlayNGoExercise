using PlayNGoExercice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Repositories
{
	public interface IPantryRepository
	{
		Pantry GetById(int id);

		ICollection<Pantry> GetByOffice(int officeId);

		Pantry AddPantryToOffice(Pantry pantry);
	}
}
