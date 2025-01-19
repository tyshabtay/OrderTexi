using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderTexi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tstatus",
                table: "Texis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XgoogleMaps",
                table: "Texis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YgoogleMaps",
                table: "Texis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tstatus",
                table: "Texis");

            migrationBuilder.DropColumn(
                name: "XgoogleMaps",
                table: "Texis");

            migrationBuilder.DropColumn(
                name: "YgoogleMaps",
                table: "Texis");
        }
    }
}
