using AutoMapper;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PlayNGoExercise.ApiServices.Mappers;
using PlayNGoExercise.WebApi.App_Start.Windsor;
using System.Web.Http;

namespace PlayNGoExercise.WebApi.App_Start
{
	public static class IoCStartup
	{

		private static IWindsorContainer _container;

		public static void Setup(HttpConfiguration configuration)
		{
			_container = new WindsorContainer();
			_container.Install(FromAssembly.This());
			_container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
			var dependencyResolver = new WindsorDependencyResolver(_container);
			configuration.DependencyResolver = dependencyResolver;

			Mapper.Initialize(cfg =>
				cfg.AddProfiles(new[] {
					typeof(ApiServiceMappers)
				})
			);
		}

	}
}