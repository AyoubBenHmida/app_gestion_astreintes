using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gestion_astreintes.Migrations
{
    /// <inheritdoc />
    public partial class TeamMemberTypeMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TeamMembersMemberTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TeamLeader" },
                    { 2, "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamMembersMemberTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembersMemberTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
