using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bankingapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountNoToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_RecieverId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_RecieverId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                table: "Transactions",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "RecieverId",
                table: "Transactions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RecieverId",
                table: "Transactions",
                column: "RecieverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_RecieverId",
                table: "Transactions",
                column: "RecieverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
