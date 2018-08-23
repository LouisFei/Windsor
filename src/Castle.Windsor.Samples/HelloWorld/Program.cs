using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace HelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			// application starts...
			var container = new WindsorContainer();

			// adds and configures all components using WindsorInstallers from executing assembly
			container.Install(FromAssembly.This());

			// instansiate and configure root component and all its dependencies and their dependencies and...
			var king = container.Resolve<IKing>();
			king.RuleTheCastle();

			// clean up, application exits
			container.Dispose();

			Console.Read();

		}
	}

	public interface IKing
	{
		void RuleTheCastle();
	}

	public class King : IKing
	{
		public void RuleTheCastle()
		{
			Console.WriteLine($"国王规则.{DateTime.Now.ToString()}");
		}
	}

	public class RepositoriesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
									.Where(Component.IsInSameNamespaceAs<King>())
									.WithService.DefaultInterfaces()
									.LifestyleTransient());
		}
	}
}
