using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.PaymentDepositRepository.Postgres.Migrations
{
    public partial class RemoveCardFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumberHash",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.DropColumn(
                name: "CardNumberName",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                schema: "education",
                table: "payment_deposit",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_payment_deposit_CardId",
                schema: "education",
                table: "payment_deposit",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_payment_deposit_CardId",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.DropColumn(
                name: "CardId",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.AddColumn<string>(
                name: "CardNumberHash",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumberName",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
