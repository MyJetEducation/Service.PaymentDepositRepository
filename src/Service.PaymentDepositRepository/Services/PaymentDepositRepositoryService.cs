using System;
using System.Threading.Tasks;
using Service.Core.Client.Models;
using Service.PaymentDepositRepository.Grpc;
using Service.PaymentDepositRepository.Grpc.Models;
using Service.PaymentDepositRepository.Postgres.Services;

namespace Service.PaymentDepositRepository.Services
{
	public class PaymentDepositRepositoryService : IPaymentDepositRepositoryService
	{
		private readonly IPaymentDepositRepository _depositRepository;

		public PaymentDepositRepositoryService(IPaymentDepositRepository depositRepository) => _depositRepository = depositRepository;

		public async ValueTask<RegisterGrpcResponse> RegisterAsync(RegisterGrpcRequest request)
		{
			Guid? transactionId = await _depositRepository.Register(
				request.UserId,
				request.Provider,
				request.Amount,
				request.Currency,
				request.Country,
				request.Number,
				request.Holder,
				request.Month,
				request.Year,
				request.Cvv
				);

			return new RegisterGrpcResponse
			{
				TransactionId = transactionId
			};
		}

		public async ValueTask<CommonGrpcResponse> SetStateAsync(SetStateGrpcRequest request)
		{
			bool result = await _depositRepository.SetState(request.TransactionId, request.State, request.ExternalId);

			return CommonGrpcResponse.Result(result);
		}
	}
}