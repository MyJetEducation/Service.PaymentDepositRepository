using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.PaymentDepositRepository.Postgres.Migrations
{
    public partial class AddServiceCodeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceCode",
                schema: "education",
                table: "payment_deposit",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceCode",
                schema: "education",
                table: "payment_deposit");
        }
    }
}
