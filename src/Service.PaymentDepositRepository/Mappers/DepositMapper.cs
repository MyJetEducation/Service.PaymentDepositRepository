using Service.PaymentDepositRepository.Grpc.Models;
using Service.PaymentDepositRepository.Postgres.Models;

namespace Service.PaymentDepositRepository.Mappers
{
	public static class DepositMapper
	{
		public static DepositGrpcResponse ToGrpcModel(this PaymentDepositRepositoryEntity entity) => new DepositGrpcResponse
		{
			Deposit = entity == null
				? null
				: new DepositGrpcModel
				{
					TransactionId = entity.TransactionId,
					ExternalId = entity.ExternalId,
					Date = entity.Date,
					UserId = entity.UserId,
					State = entity.State,
					Provider = entity.Provider,
					Amount = entity.Amount,
					Currency = entity.Currency,
					Country = entity.Country,
					ServiceCode = entity.ServiceCode,
					CardNumber = entity.CardNumber,
					CardHolder = entity.CardHolder,
					CardMonth = entity.CardMonth,
					CardYear = entity.CardYear,
					CardCvv = entity.CardCvv
				}
		};
	}
}