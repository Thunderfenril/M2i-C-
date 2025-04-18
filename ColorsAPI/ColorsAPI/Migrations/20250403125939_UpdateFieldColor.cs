﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Colors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Colors");
        }
    }
}
