using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;

namespace PlayNGoExercise.WebApi.App_Start.Windsor.Installers
{
	public class ApiInstallers : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
							.BasedOn<IHttpController>()
							.LifestylePerWebRequest());
		}
	}
}