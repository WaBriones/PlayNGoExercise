using PlayNGoExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercise.ApiServices.Interfaces
{
	public interface IPantryApiService
	{
		Pantry GetById(int id);
		ICollection<Pantry> GetManyByOffice(int officeId);
	}
}
