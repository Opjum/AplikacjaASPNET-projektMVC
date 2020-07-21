using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacjaASPNET.Migrations.AppDbContextSQLServerMigrations
{
    public partial class nowyContrller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "StudentDB",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompetitionDB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Organiser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionDB", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentDB_CompetitionDB_CompetitionId",
                table: "StudentDB");

            migrationBuilder.DropTable(
                name: "CompetitionDB");

            migrationBuilder.DropIndex(
                name: "IX_StudentDB_CompetitionId",
                table: "StudentDB");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "StudentDB");
        }
    }
}
