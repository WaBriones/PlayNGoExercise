﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using PlayNGoExercice.Data.Entities;
using EntityFramework.DbContextScope.Interfaces;

namespace PlayNGoExercice.Data.Repositories
{
	public class PantryStockRepository : IPantryStockRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;
		private readonly IDbContextScopeFactory _contextScopeFactory;

		public PantryStockRepository(IAmbientDbContextLocator contextLocator,
			IDbContextScopeFactory contextScopeFactory)
		{
			_contextLocator = contextLocator;
			_contextScopeFactory = contextScopeFactory;
		}

		public void UpdatePantryStocks(int drinkId, int officeId)
		{
			using (var context = _contextScopeFactory.Create())
			{
				var drinkCosts = _contextLocator.Get<DataContext>().DrinkCosts.Where(x => x.DrinkId == drinkId).ToList();
				var stockList = _contextLocator.Get<DataContext>().PantryStocks.Where(x => x.OfficeId == officeId).ToList();

				foreach (var drinkCost in drinkCosts)
				{
					var stockToDeduct = stockList.FirstOrDefault(x => x.IngredientId == drinkCost.IngredientId);

					if (stockToDeduct != null)
					{
						stockToDeduct.Amount -= drinkCost.Cost;
					}
				}
				
				context.SaveChanges();
			}
		}

		public ICollection<PantryStock> GetStocksByOffice(int officeId)
		{
			ICollection<PantryStock> stockList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				stockList = _contextLocator.Get<DataContext>()
					.PantryStocks
					.Include(x => x.Office)
					.Include(x => x.Ingredient)
					.Where(x => x.OfficeId == officeId).ToList();
			}

			return stockList;
		}

		public ICollection<PantryStock> GetAllStocks()
		{
			ICollection<PantryStock> stockList;
			using (var context = _contextScopeFactory.CreateReadOnly())
			{
				stockList = _contextLocator.Get<DataContext>()
					.PantryStocks
					.Include(x => x.Office)
					.Include(x => x.Ingredient)
					.ToList();
			}

			return stockList;
		}

		public void ReplenishStock(int officeId)
		{
			using (var context = _contextScopeFactory.Create())
			{
				var ingredients = _contextLocator.Get<DataContext>().Ingredients.ToList();
				var pantryStocks = new List<PantryStock>();

				foreach (var ingredient in ingredients)
				{
					pantryStocks.Add(
						new PantryStock
						{
							IngredientId = ingredient.IngredientId,
							OfficeId = officeId,
							Amount = 45
						});
				}

				_contextLocator.Get<DataContext>().PantryStocks.AddRange(pantryStocks);

				context.SaveChanges();
			}
		}
	}
}
