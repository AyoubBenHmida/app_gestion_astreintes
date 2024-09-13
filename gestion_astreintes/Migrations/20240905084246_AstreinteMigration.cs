using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gestion_astreintes.Migrations
{
    /// <inheritdoc />
    public partial class AstreinteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Astreintes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astreintes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Astreintes_Statuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "Statuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nouveau" },
                    { 2, "Validée" },
                    { 3, "Rejetée" },
                    { 4, "En Cours" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Astreintes_StatutId",
                table: "Astreintes",
                column: "StatutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Astreintes");

            migrationBuilder.DropTable(
                name: "Statuts");
        }
    }
}
