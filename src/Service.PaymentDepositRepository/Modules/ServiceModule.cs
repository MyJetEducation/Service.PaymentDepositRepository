using Autofac;
using Service.Core.Client.Services;

namespace Service.PaymentDepositRepository.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Postgres.Services.PaymentDepositRepository>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<SystemClock>().AsImplementedInterfaces().SingleInstance();
		}
	}
}