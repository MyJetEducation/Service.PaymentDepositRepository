using System;
using System.Runtime.Serialization;
using Service.PaymentDepositRepository.Domain.Models;

namespace Service.PaymentDepositRepository.Grpc.Models
{
	[DataContract]
	public class SetStateGrpcRequest
	{
		[DataMember(Order = 1)]
		public Guid? TransactionId { get; set; }

		[DataMember(Order = 2)]
		public string ExternalId { get; set; }

		[DataMember(Order = 3)]
		public TransactionState State { get; set; }
	}
}