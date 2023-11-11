using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HiLoGuessing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attempts_MysteryNumbers_MysteryNumberId",
                table: "Attempts");

            migrationBuilder.DropTable(
                name: "MysteryNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Attempts_MysteryNumberId",
                table: "Attempts");

            migrationBuilder.RenameColumn(
                name: "AttemptedNumber",
                table: "Attempts",
                newName: "NumberOfAttempts");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Attempts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "HiLoGuessId",
                table: "Attempts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "HiLoGuess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneratedMysteryNumber = table.Column<int>(type: "INTEGER", maxLength: 100, nullable: false),
                    NumberOfAttempts = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiLoGuess", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_HiLoGuessId",
                table: "Attempts",
                column: "HiLoGuessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attempts_HiLoGuess_HiLoGuessId",
                table: "Attempts",
                column: "HiLoGuessId",
                principalTable: "HiLoGuess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attempts_HiLoGuess_HiLoGuessId",
                table: "Attempts");

            migrationBuilder.DropTable(
                name: "HiLoGuess");

            migrationBuilder.DropIndex(
                name: "IX_Attempts_HiLoGuessId",
                table: "Attempts");

            migrationBuilder.DropColumn(
                name: "HiLoGuessId",
                table: "Attempts");

            migrationBuilder.RenameColumn(
                name: "NumberOfAttempts",
                table: "Attempts",
                newName: "AttemptedNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Attempts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "MysteryNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratedMysteryNumber = table.Column<int>(type: "INTEGER", maxLength: 100, nullable: false),
                    NumberOfAttempts = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysteryNumbers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_MysteryNumberId",
                table: "Attempts",
                column: "MysteryNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attempts_MysteryNumbers_MysteryNumberId",
                table: "Attempts",
                column: "MysteryNumberId",
                principalTable: "MysteryNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
