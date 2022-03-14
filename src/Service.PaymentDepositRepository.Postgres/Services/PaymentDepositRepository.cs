using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Core.Client.Services;
using Service.PaymentDepositRepository.Domain.Models;
using Service.PaymentDepositRepository.Postgres.Models;

namespace Service.PaymentDepositRepository.Postgres.Services
{
	public class PaymentDepositRepository : IPaymentDepositRepository
	{
		private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;
		private readonly ILogger<PaymentDepositRepository> _logger;
		private readonly ISystemClock _systemClock;
		private readonly IEncoderDecoder _encoderDecoder;

		public PaymentDepositRepository(DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder, ILogger<PaymentDepositRepository> logger, ISystemClock systemClock, IEncoderDecoder encoderDecoder)
		{
			_dbContextOptionsBuilder = dbContextOptionsBuilder;
			_logger = logger;
			_systemClock = systemClock;
			_encoderDecoder = encoderDecoder;
		}

		public async ValueTask<Guid?> Register(Guid? userId, string provider, decimal amount, string currency, string country, string serviceCode, string number, string holder, string month, string year, string cvv)
		{
			DatabaseContext context = GetContext();
			Guid? transactionId = Guid.NewGuid();

			try
			{
				await context
					.PaymentDeposits
					.AddAsync(new PaymentDepositRepositoryEntity
					{
						TransactionId = transactionId,
						Date = _systemClock.Now,
						UserId = userId,
						State = TransactionState.Registered,
						Provider = provider,
						Amount = amount,
						Currency = currency,
						Country = country,
						ServiceCode = serviceCode,
						CardNumber = EncodeString(number),
						CardHolder = EncodeString(holder),
						CardMonth = EncodeString(month),
						CardYear = EncodeString(year),
						CardCvv = EncodeString(cvv)
					});

				await context.SaveChangesAsync();

				return transactionId;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return await ValueTask.FromResult<Guid?>(null);
		}

		public async ValueTask<bool> SetState(Guid? transactionId, TransactionState state, string externalId = null)
		{
			DatabaseContext context = GetContext();

			PaymentDepositRepositoryEntity entity = await Get(context, transactionId);
			if (entity == null)
			{
				_logger.LogError("Can't find deposit entity by transactionId: {transactionId}.", transactionId);
				return false;
			}

			if (externalId != null)
				entity.ExternalId = externalId;

			if (entity.State != state)
				entity.Date = _systemClock.Now;

			entity.State = state;

			return await UpdateEntity(entity, context);
		}

		public async ValueTask<PaymentDepositRepositoryEntity> Get(Guid? transactionId)
		{
			PaymentDepositRepositoryEntity entity = await Get(GetContext(), transactionId);

			DecodeEntity(entity);

			return entity;
		}

		public async ValueTask<PaymentDepositRepositoryEntity> Get(string externalId)
		{
			PaymentDepositRepositoryEntity entity = await Get(GetContext(), externalId);

			DecodeEntity(entity);

			return entity;
		}

		public async ValueTask<bool> Update(PaymentDepositRepositoryEntity entity) => await UpdateEntity(entity, GetContext());

		private async ValueTask<PaymentDepositRepositoryEntity> Get(DatabaseContext context, Guid? transactionId)
		{
			try
			{
				return await context
					.PaymentDeposits
					.FirstOrDefaultAsync(entity => entity.TransactionId == transactionId);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return await ValueTask.FromResult<PaymentDepositRepositoryEntity>(null);
		}

		private async ValueTask<PaymentDepositRepositoryEntity> Get(DatabaseContext context, string externalId)
		{
			try
			{
				return await context
					.PaymentDeposits
					.FirstOrDefaultAsync(entity => entity.ExternalId == externalId);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return await ValueTask.FromResult<PaymentDepositRepositoryEntity>(null);
		}

		private async ValueTask<bool> UpdateEntity(PaymentDepositRepositoryEntity entity, DatabaseContext context)
		{
			try
			{
				context
					.PaymentDeposits
					.Update(entity);

				await context.SaveChangesAsync();
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);

				return false;
			}

			return true;
		}

		private DatabaseContext GetContext() => DatabaseContext.Create(_dbContextOptionsBuilder);

		private void DecodeEntity(PaymentDepositRepositoryEntity entity)
		{
			entity.CardNumber = DecodeString(entity.CardNumber);
			entity.CardHolder = DecodeString(entity.CardHolder);
			entity.CardMonth = DecodeString(entity.CardMonth);
			entity.CardYear = DecodeString(entity.CardYear);
			entity.CardCvv = DecodeString(entity.CardCvv);
		}

		private string EncodeString(string number) => _encoderDecoder.Encode(number);
		private string DecodeString(string number) => _encoderDecoder.Decode(number);
	}
}