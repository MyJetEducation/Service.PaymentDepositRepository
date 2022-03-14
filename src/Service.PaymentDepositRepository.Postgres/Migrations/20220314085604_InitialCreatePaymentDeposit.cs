using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.PaymentDepositRepository.Postgres.Migrations
{
    public partial class InitialCreatePaymentDeposit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "education");

            migrationBuilder.CreateTable(
                name: "payment_deposit",
                schema: "education",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    CardHolder = table.Column<string>(type: "text", nullable: false),
                    CardMonth = table.Column<string>(type: "text", nullable: false),
                    CardYear = table.Column<string>(type: "text", nullable: false),
                    CardCvv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_deposit", x => x.TransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_deposit_ExternalId",
                schema: "education",
                table: "payment_deposit",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_deposit_TransactionId",
                schema: "education",
                table: "payment_deposit",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payment_deposit_UserId",
                schema: "education",
                table: "payment_deposit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_deposit",
                schema: "education");
        }
    }
}
