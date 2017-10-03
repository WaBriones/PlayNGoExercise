using PlayNGoExercice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGoExercice.Data.Repositories
{
	public interface IOrderRepository
	{
		ICollection<Orders> GetByOffice(int officeId);

		Orders PlaceOrder(Orders order);
	}
}
