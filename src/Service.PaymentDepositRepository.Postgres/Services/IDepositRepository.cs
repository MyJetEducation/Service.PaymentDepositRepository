using Service.PaymentDepositRepository.Domain.Models;
using Service.PaymentDepositRepository.Postgres.Models;

namespace Service.PaymentDepositRepository.Postgres.Services
{
	public interface IDepositRepository
	{
		ValueTask<Guid?> Register(Guid? userId, string provider, decimal amount, string currency, string country, string serviceCode, Guid? cardId);

		ValueTask<bool> SetState(Guid? transactionId, TransactionState state, string externalId = null);

		ValueTask<bool> Update(PaymentDepositRepositoryEntity entity);

		ValueTask<PaymentDepositRepositoryEntity> Get(Guid? transactionId);
		ValueTask<PaymentDepositRepositoryEntity> Get(string externalId);
	}
}