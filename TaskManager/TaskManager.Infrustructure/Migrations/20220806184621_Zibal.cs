using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrustructure.Migrations
{
    public partial class Zibal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dutration",
                table: "Activities",
                newName: "Duration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Activities",
                newName: "Dutration");
        }
    }
}
