namespace PlayNGoExercice.Data.Migrations
{
	using System;
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

			context.CoffeeMenu.AddOrUpdate(
				d => d.DrinkId,
					new Entities.CoffeeMenu { DrinkId = 1, DrinkName = "Double Americano" },
					new Entities.CoffeeMenu { DrinkId = 2, DrinkName = "Sweet Latte" },
					new Entities.CoffeeMenu { DrinkId = 3, DrinkName = "Flat White" }
				);

			context.Ingredients.AddOrUpdate(
				i => i.IngredientId,
					new Entities.Ingredient { IngredientId = 1, IngredientName = "Coffee Beans" },
					new Entities.Ingredient { IngredientId = 2, IngredientName = "Sugar" },
					new Entities.Ingredient { IngredientId = 3, IngredientName = "Milk" }
				);

			context.DrinkCosts.AddOrUpdate(
				d => d.DrinkCostId,				
					new Entities.DrinkCost { DrinkCostId = 1, DrinkId = 1, IngredientId = 1, Cost = 3},

					new Entities.DrinkCost { DrinkCostId = 2, DrinkId = 2, IngredientId = 1, Cost = 2 },
					new Entities.DrinkCost { DrinkCostId = 3, DrinkId = 2, IngredientId = 2, Cost = 5 },
					new Entities.DrinkCost { DrinkCostId = 4, DrinkId = 2, IngredientId = 3, Cost = 3 },

					new Entities.DrinkCost { DrinkCostId = 5, DrinkId = 3, IngredientId = 1, Cost = 2 },
					new Entities.DrinkCost { DrinkCostId = 6, DrinkId = 3, IngredientId = 2, Cost = 1 },
					new Entities.DrinkCost { DrinkCostId = 7, DrinkId = 3, IngredientId = 3, Cost = 4 }
				);

			context.PantryStocks.AddOrUpdate(
				p => p.PantryStockId,
					//Manila Pantry
					new Entities.PantryStock { PantryStockId = 1, OfficeId = 1, IngredientId = 1, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 2, OfficeId = 1, IngredientId = 2, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 3, OfficeId = 1, IngredientId = 3, Amount = 45 },

					//Makati Pantry
					new Entities.PantryStock { PantryStockId = 4, OfficeId = 2, IngredientId = 1, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 5, OfficeId = 2, IngredientId = 2, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 6, OfficeId = 2, IngredientId = 3, Amount = 45 },

					// Singapore Pantry
					new Entities.PantryStock { PantryStockId = 7, OfficeId = 3, IngredientId = 1, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 8, OfficeId = 3, IngredientId = 2, Amount = 45 },
					new Entities.PantryStock { PantryStockId = 9, OfficeId = 3, IngredientId = 3, Amount = 45 }
				);

			context.Orders.AddOrUpdate(
				p => p.OrderId,

					new Entities.Orders { OrderId = 1, OfficeId = 1, DrinkId = 1, CustomerName = "Warren", DateOrdered = DateTime.UtcNow },
					new Entities.Orders { OrderId = 2, OfficeId = 1, DrinkId = 2, CustomerName = "Karl", DateOrdered = DateTime.UtcNow },
					new Entities.Orders { OrderId = 3, OfficeId = 1, DrinkId = 3, CustomerName = "Jerome", DateOrdered = DateTime.UtcNow }
				);
		}
    }
}
