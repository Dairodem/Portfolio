using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class setup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectLanguages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "ProjectLanguages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLanguages_LanguageId",
                table: "ProjectLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLanguages_ProjectId",
                table: "ProjectLanguages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguages_Languages_LanguageId",
                table: "ProjectLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLanguages_Projects_ProjectId",
                table: "ProjectLanguages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguages_Languages_LanguageId",
                table: "ProjectLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLanguages_Projects_ProjectId",
                table: "ProjectLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLanguages_LanguageId",
                table: "ProjectLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLanguages_ProjectId",
                table: "ProjectLanguages");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProjectLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "ProjectLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
