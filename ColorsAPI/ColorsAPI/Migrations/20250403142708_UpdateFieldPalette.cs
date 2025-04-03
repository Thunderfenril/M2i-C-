using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldPalette : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ColorPalettes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ColorPalettes");
        }
    }
}
