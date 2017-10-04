using System;

namespace PlayNGoExercise.Model
{
	public class OrdersDto
	{
		public int OfficeId { get; set; }

		public int DrinkId { get; set; }

		public string DrinkName { get; set; }

		public string OfficeName { get; set; }

		public int DrinkCount { get; set; }
	}

	public class OrderHistoryDto
	{
		public int OfficeId { get; set; }
		public int DrinkId { get; set; }
		public string CustomerName { get; set; }
		public string DrinkName { get; set; }
		public DateTime? DateOrdered { get; set; }
	}
}
