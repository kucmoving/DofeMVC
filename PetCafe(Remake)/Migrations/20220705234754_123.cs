using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCafe_Remake_.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VisitTime_VisitTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_VisitTime_VisitTimeId",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitTime",
                table: "VisitTime");

            migrationBuilder.RenameTable(
                name: "VisitTime",
                newName: "VisitTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitTimes",
                table: "VisitTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VisitTimes_VisitTimeId",
                table: "AspNetUsers",
                column: "VisitTimeId",
                principalTable: "VisitTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs",
                column: "VisitTimeId",
                principalTable: "VisitTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VisitTimes_VisitTimeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_VisitTimes_VisitTimeId",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitTimes",
                table: "VisitTimes");

            migrationBuilder.RenameTable(
                name: "VisitTimes",
                newName: "VisitTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitTime",
                table: "VisitTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VisitTime_VisitTimeId",
                table: "AspNetUsers",
                column: "VisitTimeId",
                principalTable: "VisitTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_VisitTime_VisitTimeId",
                table: "Dogs",
                column: "VisitTimeId",
                principalTable: "VisitTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
