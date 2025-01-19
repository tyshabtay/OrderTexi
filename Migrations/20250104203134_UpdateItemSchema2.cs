using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderTexi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Texis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Texis_DriverId",
                table: "Texis",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Texis_Drivers_DriverId",
                table: "Texis",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "driver",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texis_Drivers_DriverId",
                table: "Texis");

            migrationBuilder.DropIndex(
                name: "IX_Texis_DriverId",
                table: "Texis");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Texis");
        }
    }
}
