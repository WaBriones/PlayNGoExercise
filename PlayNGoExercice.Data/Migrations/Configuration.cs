namespace PlayNGoExercice.Data.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			context.Offices.AddOrUpdate(
			  p => p.OfficeId,
			  new Entities.Office { OfficeId = 1, OfficeName = "Manila" },
			  new Entities.Office { OfficeId = 2, OfficeName = "Makati" },
			  new Entities.Office { OfficeId = 3, OfficeName = "Singapore" }
			);

			context.Pantry.AddOrUpdate(
				p => p.PantryId,
					new Entities.Pantry { PantryId = 1, OfficeId = 1, PantryName = "Manila Pantry" },

					new Entities.Pantry { PantryId = 2, OfficeId = 2, PantryName = "Makati Pantry 1" },
					new Entities.Pantry { PantryId = 3, OfficeId = 2, PantryName = "Makati Pantry 2" },

					new Entities.Pantry { PantryId = 4, OfficeId = 3, PantryName = "Singapore Pantry 1" },
					new Entities.Pantry { PantryId = 5, OfficeId = 3, PantryName = "Singapore Pantry 2" }
				);
		}
    }
}
