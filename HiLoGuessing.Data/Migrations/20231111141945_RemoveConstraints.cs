using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfAttempts",
                table: "HiLoGuess");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfAttempts",
                table: "HiLoGuess",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
