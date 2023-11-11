using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HiLoGuess",
                columns: table => new
                {
                    HiLoGuessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GeneratedMysteryNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiLoGuess", x => x.HiLoGuessId);
                });

            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    AttemptsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfAttempts = table.Column<int>(type: "INTEGER", nullable: false),
                    HiLoGuessId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attempts", x => x.AttemptsId);
                    table.ForeignKey(
                        name: "FK_Attempts_HiLoGuess_HiLoGuessId",
                        column: x => x.HiLoGuessId,
                        principalTable: "HiLoGuess",
                        principalColumn: "HiLoGuessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attempts_HiLoGuessId",
                table: "Attempts",
                column: "HiLoGuessId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropTable(
                name: "HiLoGuess");
        }
    }
}
