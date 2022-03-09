﻿using System;
using System.Runtime.Serialization;

namespace Service.PaymentDepositRepository.Grpc.Models
{
	[DataContract]
	public class GetDepositGrpcRequest
	{
		[DataMember(Order = 1)]
		public Guid? TransactionId { get; set; }
	}
}