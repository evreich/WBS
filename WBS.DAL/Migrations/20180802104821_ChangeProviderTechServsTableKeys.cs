using Microsoft.EntityFrameworkCore.Migrations;

namespace WBS.DAL.Migrations
{
    public partial class ChangeProviderTechServsTableKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProvidersTechnicalServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProvidersTechnicalServices",
                nullable: false,
                defaultValue: 0);
        }
    }
}
