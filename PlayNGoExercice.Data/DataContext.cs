using EntityFramework.DbContextScope.Interfaces;
using PlayNGoExercice.Data.Entities;
using System.Data.Entity;

namespace PlayNGoExercice.Data
{
	public class DataContext : DbContext, IDbContext
	{
		public DataContext() : base("name=DataContext")
		{

		}
		public DbSet<Office> Offices { get; set; }
		public DbSet<Pantry> Pantry { get; set; }
	}
}
