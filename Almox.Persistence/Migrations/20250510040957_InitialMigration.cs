using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Almox.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(35)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => new { x.CategoriesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CategoryItem_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Item_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionLog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Observations = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<short>(type: "SMALLINT", nullable: false, defaultValue: (short)1),
                    Observations = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryItem",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryItem", x => new { x.ItemId, x.DeliveryId });
                    table.ForeignKey(
                        name: "FK_DeliveryItem_Delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestItem",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    FulfilledQuantity = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItem", x => new { x.ItemId, x.RequestId });
                    table.ForeignKey(
                        name: "FK_RequestItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestItem_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLog_UserId",
                table: "ActionLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemsId",
                table: "CategoryItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_UserId",
                table: "Delivery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_DeliveryId",
                table: "DeliveryItem",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId",
                table: "Request",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItem_RequestId",
                table: "RequestItem",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLog");

            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "DeliveryItem");

            migrationBuilder.DropTable(
                name: "RequestItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
