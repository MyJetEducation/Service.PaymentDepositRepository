using Service.PaymentDepositRepository.Domain.Models;
using Service.PaymentDepositRepository.Postgres.Models;

namespace Service.PaymentDepositRepository.Postgres.Services
{
	public interface IPaymentDepositRepository
	{
		ValueTask<Guid?> Register(Guid? userId, string provider, decimal amount, string currency, string country, string number, string holder, string month, string year, string cvv);

		ValueTask<bool> SetState(Guid? transactionId, TransactionState state, string externalId = null);

		ValueTask<bool> Update(PaymentDepositRepositoryEntity entity);

		ValueTask<PaymentDepositRepositoryEntity> Get(Guid? transactionId);
		ValueTask<PaymentDepositRepositoryEntity> Get(string externalId);
	}
}