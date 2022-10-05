using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELETRICTEL.Migrations
{
    public partial class dbPhoneCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phoone",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phoone",
                table: "Company");
        }
    }
}
