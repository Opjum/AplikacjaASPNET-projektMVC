using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacjaASPNET.Migrations.AppDbContextSQLServerMigrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDB_CompetitionDB_CompetitionId",
                table: "StudentDB");

            migrationBuilder.DropIndex(
                name: "IX_StudentDB_CompetitionId",
                table: "StudentDB");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "StudentDB");

            migrationBuilder.CreateTable(
                name: "CompetitionStudentsDB",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CompetitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionStudentsDB", x => new { x.StudentId, x.CompetitionId });
                    table.ForeignKey(
                        name: "FK_CompetitionStudentsDB_CompetitionDB_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "CompetitionDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionStudentsDB_StudentDB_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionStudentsDB_CompetitionId",
                table: "CompetitionStudentsDB",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionStudentsDB");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "StudentDB",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentDB_CompetitionId",
                table: "StudentDB",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDB_CompetitionDB_CompetitionId",
                table: "StudentDB",
                column: "CompetitionId",
                principalTable: "CompetitionDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
