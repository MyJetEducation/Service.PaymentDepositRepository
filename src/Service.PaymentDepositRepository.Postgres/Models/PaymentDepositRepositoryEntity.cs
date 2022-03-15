using Service.PaymentDepositRepository.Domain.Models;

namespace Service.PaymentDepositRepository.Postgres.Models
{
	public class PaymentDepositRepositoryEntity
	{
		public Guid? TransactionId { get; set; }

		public string ExternalId { get; set; }

		public DateTime? Date { get; set; }

		public Guid? UserId { get; set; }

		public TransactionState State { get; set; }

		public string Provider { get; set; }

		public Guid? CardId { get; set; }

		#region Payment

		public decimal Amount { get; set; }

		public string Currency { get; set; }

		public string Country { get; set; }

		public string ServiceCode { get; set; }

		#endregion
	}
}