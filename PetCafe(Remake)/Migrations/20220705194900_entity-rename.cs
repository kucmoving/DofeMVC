using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCafe_Remake_.Migrations
{
    public partial class entityrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SharingName",
                table: "Events",
                newName: "EventName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "SharingName");
        }
    }
}
