using Autofac;
using Service.Core.Client.Services;
using Service.PaymentDepositRepository.Postgres.Services;

namespace Service.PaymentDepositRepository.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<SystemClock>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<DepositRepository>().AsImplementedInterfaces().SingleInstance();
		}
	}
}