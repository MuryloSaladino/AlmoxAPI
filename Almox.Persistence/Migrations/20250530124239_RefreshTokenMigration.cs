using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Almox.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "users",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_delivery_items_items_item_id",
                table: "delivery_items",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_items_item_id",
                table: "order_items",
                column: "item_id",
                principalTable: "items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_delivery_items_items_item_id",
                table: "delivery_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_items_item_id",
                table: "order_items");

            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "users");
        }
    }
}
