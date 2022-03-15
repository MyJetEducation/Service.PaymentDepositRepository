using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.PaymentDepositRepository.Postgres.Migrations
{
    public partial class RemoveCardFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardCvv",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.DropColumn(
                name: "CardHolder",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.DropColumn(
                name: "CardMonth",
                schema: "education",
                table: "payment_deposit");

            migrationBuilder.RenameColumn(
                name: "CardYear",
                schema: "education",
                table: "payment_deposit",
                newName: "CardNumberName");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                schema: "education",
                table: "payment_deposit",
                newName: "CardNumberHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardNumberName",
                schema: "education",
                table: "payment_deposit",
                newName: "CardYear");

            migrationBuilder.RenameColumn(
                name: "CardNumberHash",
                schema: "education",
                table: "payment_deposit",
                newName: "CardNumber");

            migrationBuilder.AddColumn<string>(
                name: "CardCvv",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardHolder",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardMonth",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
