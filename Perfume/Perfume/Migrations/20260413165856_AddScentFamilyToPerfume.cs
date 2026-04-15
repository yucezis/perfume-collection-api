using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perfume.Migrations
{
    /// <inheritdoc />
    public partial class AddScentFamilyToPerfume : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Family",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Family",
                table: "Perfumes");
        }
    }
}
