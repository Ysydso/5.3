using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedDBSetToGymGoer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workouts_GymGoerEntity_GymGoerId",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymGoerEntity",
                table: "GymGoerEntity");

            migrationBuilder.RenameTable(
                name: "GymGoerEntity",
                newName: "gymGoer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gymGoer",
                table: "gymGoer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_gymGoer_GymGoerId",
                table: "workouts",
                column: "GymGoerId",
                principalTable: "gymGoer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workouts_gymGoer_GymGoerId",
                table: "workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gymGoer",
                table: "gymGoer");

            migrationBuilder.RenameTable(
                name: "gymGoer",
                newName: "GymGoerEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymGoerEntity",
                table: "GymGoerEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_GymGoerEntity_GymGoerId",
                table: "workouts",
                column: "GymGoerId",
                principalTable: "GymGoerEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
