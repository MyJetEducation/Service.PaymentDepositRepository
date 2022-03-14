using System;
using System.Runtime.Serialization;
using Service.PaymentDepositRepository.Domain.Models;

namespace Service.PaymentDepositRepository.Grpc.Models
{
	[DataContract]
	public class DepositGrpcResponse
	{
		[DataMember(Order = 1)]
		public DepositGrpcModel Deposit { get; set; }
	}

	[DataContract]
	public class DepositGrpcModel
	{
		[DataMember(Order = 1)]
		public Guid? TransactionId { get; set; }

		[DataMember(Order = 2)]
		public string ExternalId { get; set; }

		[DataMember(Order = 3)]
		public DateTime? Date { get; set; }

		[DataMember(Order = 4)]
		public Guid? UserId { get; set; }

		[DataMember(Order = 5)]
		public TransactionState State { get; set; }

		[DataMember(Order = 6)]
		public string Provider { get; set; }

		#region Payment

		[DataMember(Order = 7)]
		public decimal Amount { get; set; }

		[DataMember(Order = 8)]
		public string Currency { get; set; }

		[DataMember(Order = 9)]
		public string Country { get; set; }

		[DataMember(Order = 10)]
		public string ServiceCode { get; set; }
		
		#endregion

		#region Card

		[DataMember(Order = 11)]
		public string CardNumber { get; set; }

		[DataMember(Order = 12)]
		public string CardHolder { get; set; }

		[DataMember(Order = 13)]
		public string CardMonth { get; set; }

		[DataMember(Order = 14)]
		public string CardYear { get; set; }

		[DataMember(Order = 15)]
		public string CardCvv { get; set; }

		#endregion
	}
}