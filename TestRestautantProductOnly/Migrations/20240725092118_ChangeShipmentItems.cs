using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestRestautantProductOnly.Migrations
{
    /// <inheritdoc />
    public partial class ChangeShipmentItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItems_Shipments_ShipmentId",
                table: "ShipmentItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItems_Shipments_ShipmentId",
                table: "ShipmentItems",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "ShipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItems_Shipments_ShipmentId",
                table: "ShipmentItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItems_Shipments_ShipmentId",
                table: "ShipmentItems",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
