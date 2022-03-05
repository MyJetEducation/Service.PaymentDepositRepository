using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.PaymentDepositRepository.Settings
{
	public class SettingsModel
	{
		[YamlProperty("PaymentDepositRepository.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("PaymentDepositRepository.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("PaymentDepositRepository.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("PaymentDepositRepository.PostgresConnectionString")]
		public string PostgresConnectionString { get; set; }
	}
}
