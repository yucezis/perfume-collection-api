using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perfume.Migrations
{
    /// <inheritdoc />
    public partial class YeniIliski : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                column: "UserId",
                unique: true);
        }
    }
}
