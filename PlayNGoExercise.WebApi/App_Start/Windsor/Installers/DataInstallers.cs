using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PlayNGoExercice.Data.Repositories;
using EntityFramework.DbContextScope.Interfaces;
using EntityFramework.DbContextScope;

namespace PlayNGoExercise.WebApi.App_Start.Windsor.Installers
{
	public class DataInstallers : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//Repositories
			container.Register(Component.For<IOfficeRepository>().ImplementedBy<OfficeRepository>());
			container.Register(Component.For<IPantryRepository>().ImplementedBy<PantryRepository>());
			container.Register(Component.For<ICoffeeMenuRepository>().ImplementedBy<CoffeeMenuRepository>());
			container.Register(Component.For<IDrinkCostRepository>().ImplementedBy<DrinkCostRepository>());
			container.Register(Component.For<IPantryStockRepository>().ImplementedBy<PantryStockRepository>());
			container.Register(Component.For<IOrderRepository>().ImplementedBy<OrderRepository>());

			// EF Installers
			container.Register(Component.For<IAmbientDbContextLocator>().ImplementedBy<AmbientDbContextLocator>());
			container.Register(Component.For<IDbContextScopeFactory>().ImplementedBy<DbContextScopeFactory>());
		}
	}
}