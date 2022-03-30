using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.OrdersModule.Data.Migrations
{
    public partial class AddLoyaltyCalculatedToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>("LoyaltyCalculated", "CustomerOrder", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<string>("Discriminator", "CustomerOrder", maxLength: 128, nullable: false, defaultValue: "TrainingOrderEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Discriminator", "CustomerOrder");
            migrationBuilder.DropColumn("LoyaltyCalculated", "CustomerOrder");
        }
    }
}
