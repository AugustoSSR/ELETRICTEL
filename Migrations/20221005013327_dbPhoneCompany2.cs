using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELETRICTEL.Migrations
{
    public partial class dbPhoneCompany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phoone",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Phoone",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
