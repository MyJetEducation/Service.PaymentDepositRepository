using System;
using System.Runtime.Serialization;

namespace Service.PaymentDepositRepository.Grpc.Models
{
	[DataContract]
	public class RegisterGrpcResponse
	{
		[DataMember(Order = 1)]
		public Guid? TransactionId { get; set; }
	}
}
