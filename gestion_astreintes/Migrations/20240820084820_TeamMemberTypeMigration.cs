using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestion_astreintes.Migrations
{
    /// <inheritdoc />
    public partial class TeamMemberTypeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TeamMembers");

            migrationBuilder.AddColumn<int>(
                name: "MemberTypeId",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TeamMembersMemberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembersMemberTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MemberTypeId",
                table: "TeamMembers",
                column: "MemberTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_TeamMembersMemberTypes_MemberTypeId",
                table: "TeamMembers",
                column: "MemberTypeId",
                principalTable: "TeamMembersMemberTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_TeamMembersMemberTypes_MemberTypeId",
                table: "TeamMembers");

            migrationBuilder.DropTable(
                name: "TeamMembersMemberTypes");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_MemberTypeId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "TeamMembers");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
