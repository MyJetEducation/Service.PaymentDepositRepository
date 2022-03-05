using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using Service.PaymentDepositRepository.Client;

namespace TestApp
{
	public class Program
	{
		private static async Task Main(string[] args)
		{
			GrpcClientFactory.AllowUnencryptedHttp2 = true;
			var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

			Console.Write("Press enter to start");
			Console.ReadLine();

			var factory = new PaymentDepositRepositoryClientFactory("http://localhost:5001", logger);
			var serviceProxy = factory.GetPaymentDepositRepositoryService();
			var client = serviceProxy.Service;

			//var resp = await client.SayHelloAsync(new RegisterGrpcRequest {Name = "Alex"});
			//Console.WriteLine(resp?.Message);

			Console.WriteLine("End");
			Console.ReadLine();
		}
	}
}
