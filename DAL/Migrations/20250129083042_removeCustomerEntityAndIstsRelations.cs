using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeCustomerEntityAndIstsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_ShopCarts_ShopCartId",
                table: "ShopCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCarts_Customers_CustomerId",
                table: "ShopCarts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_ShopCarts_CustomerId",
                table: "ShopCarts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShopCarts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShopCarts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCarts_UserId",
                table: "ShopCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_ShopCarts_ShopCartId",
                table: "ShopCartItems",
                column: "ShopCartId",
                principalTable: "ShopCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCarts_AspNetUsers_UserId",
                table: "ShopCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_ShopCarts_ShopCartId",
                table: "ShopCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCarts_AspNetUsers_UserId",
                table: "ShopCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopCarts_UserId",
                table: "ShopCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShopCarts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ShopCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCarts_CustomerId",
                table: "ShopCarts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Products_ProductId",
                table: "ShopCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_ShopCarts_ShopCartId",
                table: "ShopCartItems",
                column: "ShopCartId",
                principalTable: "ShopCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCarts_Customers_CustomerId",
                table: "ShopCarts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
