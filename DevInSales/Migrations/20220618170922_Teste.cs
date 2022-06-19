using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_Product_OrderProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Profile_ProfileId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "User",
                newName: "profile_id");

            migrationBuilder.RenameIndex(
                name: "IX_User_ProfileId",
                table: "User",
                newName: "IX_User_profile_id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Profile",
                newName: "role");

            migrationBuilder.AddColumn<int>(
                name: "permissao",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "shipping_Company",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "delivery_Date",
                table: "Delivery",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "permissao", "role" },
                values: new object[] { 1, "usuario" });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "id", "permissao", "role" },
                values: new object[] { 2, 2, "gerente" });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "id", "permissao", "role" },
                values: new object[] { 3, 3, "administrador" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "profile_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "profile_id",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_OrderId",
                table: "Order_Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_ProductId",
                table: "Order_Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_Order_OrderId",
                table: "Order_Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_Product_ProductId",
                table: "Order_Product",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profile_profile_id",
                table: "User",
                column: "profile_id",
                principalTable: "Profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_Order_OrderId",
                table: "Order_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_Product_ProductId",
                table: "Order_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Profile_profile_id",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_Product_OrderId",
                table: "Order_Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_Product_ProductId",
                table: "Order_Product");

            migrationBuilder.DeleteData(
                table: "Profile",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profile",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "permissao",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "shipping_Company",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "User",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_User_profile_id",
                table: "User",
                newName: "IX_User_ProfileId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Profile",
                newName: "name");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delivery_Date",
                table: "Delivery",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Profile",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Cliente");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "ProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 3,
                column: "ProfileId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderProductId",
                table: "Order",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_Product_OrderProductId",
                table: "Order",
                column: "OrderProductId",
                principalTable: "Order_Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId",
                principalTable: "Order_Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profile_ProfileId",
                table: "User",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
