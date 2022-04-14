using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.OrdersModule.Data.Migrations
{
    public partial class AddLoyaltyOperationInformationToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LoyaltyPointsAmount",
                table: "CustomerOrder",
                type: "Money",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsOperationId",
                table: "CustomerOrder",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyPointsAmount",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "PointsOperationId",
                table: "CustomerOrder");
        }
    }
}
