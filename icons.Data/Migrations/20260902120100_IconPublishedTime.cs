using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icons.Data.Migrations
{
    /// <inheritdoc />
    public partial class IconPublishedTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedTime",
                table: "Icons",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedTime",
                table: "Icons");
        }
    }
}
