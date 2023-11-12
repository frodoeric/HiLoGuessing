using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HiLoGuess",
                columns: table => new
                {
                    HiLoGuessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedMysteryNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiLoGuess", x => x.HiLoGuessId);
                });

            migrationBuilder.CreateTable(
                name: "Attempts",
                columns: table => new
                {
                    AttemptsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfAttempts = table.Column<int>(type: "int", nullable: false),
                    HiLoGuessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HiLoGuessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_HiLoGuess_HiLoGuessId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Players_HiLoGuessId",
                table: "Players",
                column: "HiLoGuessId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attempts");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "HiLoGuess");
        }
    }
}
