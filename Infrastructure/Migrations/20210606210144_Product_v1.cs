using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Product_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_OrderProducts_OrderProductId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_OrderProductId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Campaigns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Campaigns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderProductId",
                table: "Products",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_OrderProductId",
                table: "Campaigns",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_OrderProducts_OrderProductId",
                table: "Campaigns",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
