using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneBackend.Migrations
{
    public partial class addedDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Requestlines",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "decimal(11,2",
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Requestlines",
                type: "decimal(11,2",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
