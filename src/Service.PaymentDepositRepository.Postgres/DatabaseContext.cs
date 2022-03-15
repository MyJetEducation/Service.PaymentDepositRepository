using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyJetWallet.Sdk.Postgres;
using MyJetWallet.Sdk.Service;
using Service.PaymentDepositRepository.Postgres.Models;

namespace Service.PaymentDepositRepository.Postgres
{
	public class DatabaseContext : MyDbContext
	{
		public const string Schema = "education";
		private const string PaymentDepositRepositoryTableName = "payment_deposit";

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<PaymentDepositRepositoryEntity> PaymentDeposits { get; set; }

		public static DatabaseContext Create(DbContextOptionsBuilder<DatabaseContext> options)
		{
			MyTelemetry.StartActivity($"Database context {Schema}")?.AddTag("db-schema", Schema);

			return new DatabaseContext(options.Options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Schema);

			SetUserInfoEntityEntry(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private static void SetUserInfoEntityEntry(ModelBuilder modelBuilder)
		{
			EntityTypeBuilder<PaymentDepositRepositoryEntity> builder = modelBuilder.Entity<PaymentDepositRepositoryEntity>();

			builder.ToTable(PaymentDepositRepositoryTableName);

			builder.Property(e => e.TransactionId).IsRequired();
			builder.Property(e => e.ExternalId);
			builder.Property(e => e.Date).IsRequired();
			builder.Property(e => e.UserId).IsRequired();
			builder.Property(e => e.State).IsRequired().HasConversion<string>();
			builder.Property(e => e.Provider).IsRequired();

			builder.Property(e => e.Amount).IsRequired();
			builder.Property(e => e.Currency).IsRequired();
			builder.Property(e => e.Country).IsRequired();
			builder.Property(e => e.ServiceCode).IsRequired();

			builder.Property(e => e.CardNumberName).IsRequired();
			builder.Property(e => e.CardNumberHash).IsRequired();

			builder.HasKey(e => e.TransactionId);
			
			builder.HasIndex(e => e.ExternalId);
			builder.HasIndex(e => e.UserId);
			builder.HasIndex(e => e.TransactionId).IsUnique();
		}
	}
}