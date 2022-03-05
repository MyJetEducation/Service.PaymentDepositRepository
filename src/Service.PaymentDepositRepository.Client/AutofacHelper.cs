using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentDepositRepository.Grpc;
using Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.PaymentDepositRepository.Client
{
	public static class AutofacHelper
	{
		public static void RegisterPaymentDepositRepositoryClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
		{
			var factory = new PaymentDepositRepositoryClientFactory(grpcServiceUrl, logger);

			builder.RegisterInstance(factory.GetPaymentDepositRepositoryService()).As<IGrpcServiceProxy<IPaymentDepositRepositoryService>>().SingleInstance();
		}
	}
}
