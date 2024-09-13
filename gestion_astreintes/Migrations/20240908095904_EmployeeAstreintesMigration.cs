using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_astreintes.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAstreintesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Astreintes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Astreintes_EmployeeId",
                table: "Astreintes",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Astreintes_TeamMembers_EmployeeId",
                table: "Astreintes",
                column: "EmployeeId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Astreintes_TeamMembers_EmployeeId",
                table: "Astreintes");

            migrationBuilder.DropIndex(
                name: "IX_Astreintes_EmployeeId",
                table: "Astreintes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Astreintes");
        }
    }
}
