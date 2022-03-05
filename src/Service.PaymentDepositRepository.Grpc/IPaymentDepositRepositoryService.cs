using System.ServiceModel;
using System.Threading.Tasks;
using Service.Core.Client.Models;
using Service.PaymentDepositRepository.Grpc.Models;

namespace Service.PaymentDepositRepository.Grpc
{
	[ServiceContract]
	public interface IPaymentDepositRepositoryService
	{
		[OperationContract]
		ValueTask<RegisterGrpcResponse> RegisterAsync(RegisterGrpcRequest request);

		[OperationContract]
		ValueTask<CommonGrpcResponse> SetStateAsync(SetStateGrpcRequest request);
	}
}