namespace Service.PaymentDepositRepository.Domain.Models
{
	public enum TransactionState
	{
		Registered,
		Rejected,
		Accepted,
		Approved,
		Error
	}
}