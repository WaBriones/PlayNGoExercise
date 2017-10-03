using PlayNGoExercice.Data.Entities;
using System.Collections.Generic;

namespace PlayNGoExercice.Data.Repositories
{
	public interface IOfficeRepository
	{
		Office GetById(int id);

		ICollection<Office> GetMany();

		void AddOffice(Office office);
	}
}
