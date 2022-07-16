using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCafe_Remake_.Migrations
{
    public partial class addkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTimeId",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs",
                column: "VisitTimeId",
                principalTable: "VisitTimes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTimeId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs",
                column: "VisitTimeId",
                principalTable: "VisitTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
