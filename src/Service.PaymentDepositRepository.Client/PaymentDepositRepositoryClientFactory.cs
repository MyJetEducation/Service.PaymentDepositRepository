using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.PaymentDepositRepository.Grpc;
using Service.Grpc;

namespace Service.PaymentDepositRepository.Client
{
	[UsedImplicitly]
	public class PaymentDepositRepositoryClientFactory : GrpcClientFactory
	{
		public PaymentDepositRepositoryClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
		{
		}

		public IGrpcServiceProxy<IPaymentDepositRepositoryService> GetPaymentDepositRepositoryService() => CreateGrpcService<IPaymentDepositRepositoryService>();
	}
}
