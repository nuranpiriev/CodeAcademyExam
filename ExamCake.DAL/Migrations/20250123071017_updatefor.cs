using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamCake.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatefor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chiefs_Designations_DesignationId",
                table: "Chiefs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chiefs",
                table: "Chiefs");

            migrationBuilder.RenameTable(
                name: "Chiefs",
                newName: "Chief");

            migrationBuilder.RenameIndex(
                name: "IX_Chiefs_DesignationId",
                table: "Chief",
                newName: "IX_Chief_DesignationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chief",
                table: "Chief",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chief_Designations_DesignationId",
                table: "Chief",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chief_Designations_DesignationId",
                table: "Chief");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chief",
                table: "Chief");

            migrationBuilder.RenameTable(
                name: "Chief",
                newName: "Chiefs");

            migrationBuilder.RenameIndex(
                name: "IX_Chief_DesignationId",
                table: "Chiefs",
                newName: "IX_Chiefs_DesignationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chiefs",
                table: "Chiefs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chiefs_Designations_DesignationId",
                table: "Chiefs",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
