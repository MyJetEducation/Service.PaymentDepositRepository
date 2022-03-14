using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.Core.Client.Models;
using Service.Grpc;
using Service.PaymentDepositRepository.Client;
using Service.PaymentDepositRepository.Domain.Models;
using Service.PaymentDepositRepository.Grpc;
using Service.PaymentDepositRepository.Grpc.Models;
using GrpcClientFactory = ProtoBuf.Grpc.Client.GrpcClientFactory;

namespace TestApp
{
	public class Program
	{
		private static async Task Main(string[] args)
		{
			GrpcClientFactory.AllowUnencryptedHttp2 = true;
			ILogger<Program> logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

			Console.Write("Press enter to start");
			Console.ReadLine();

			var factory = new PaymentDepositRepositoryClientFactory("http://localhost:5001", logger);
			IGrpcServiceProxy<IPaymentDepositRepositoryService> serviceProxy = factory.GetPaymentDepositRepositoryService();
			IPaymentDepositRepositoryService client = serviceProxy.Service;

			RegisterGrpcResponse registerResponse = await client.RegisterAsync(new RegisterGrpcRequest
			{
				Provider = "provider",
				Currency = "USD",
				Amount = 100,
				Country = "UA",
				ServiceCode = "mascote",
				Cvv = "123",
				Holder = "Ivanov Ivan",
				Month = "01",
				Year = "22",
				Number = "1234 1234 1234 1234",
				UserId = new Guid("c2ebe74f-202a-416f-89d1-9ccbe9ed2492")
			});

			Guid? id = registerResponse?.TransactionId;
			if (id == null)
				throw new Exception("Can't get transaction id");

			Console.WriteLine($"Transaction id: {id}");

			CommonGrpcResponse setResponse = await client.SetStateAsync(new SetStateGrpcRequest
			{
				TransactionId = id,
				State = TransactionState.Accepted,
				ExternalId = Guid.NewGuid().ToString()
			});

			if (setResponse?.IsSuccess == false)
				throw new Exception("Can't set state for deposit");

			DepositGrpcResponse response = await client.GetDepositAsync(new GetDepositGrpcRequest
			{
				TransactionId = id
			});

			if (response.Deposit == null)
				throw new Exception($"Can't get deposit by id {id}");

			Console.WriteLine(JsonConvert.SerializeObject(response));

			Console.WriteLine("End");
			Console.ReadLine();
		}
	}
}