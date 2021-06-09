using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstDB.Migrations
{
    public partial class FKrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Books_BookID",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Books_BookID",
                table: "Votes",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Books_BookID",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Books_BookID",
                table: "Votes",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
