using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PlayNGoExercise.ApiServices.Interfaces;
using PlayNGoExercise.ApiServices.Services;

namespace PlayNGoExercise.WebApi.App_Start.Windsor.Installers
{
	public class ApiServicesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IOfficeApiService>().ImplementedBy<OfficeApiService>());
			container.Register(Component.For<IPantryApiService>().ImplementedBy<PantryApiService>());
		}
	}
}