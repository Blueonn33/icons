using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icons.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserProfilePic_On_Icons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfilePicture",
                table: "Icons",
                type: "nvarchar(900)",
                maxLength: 900,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserProfilePicture",
                table: "Icons");
        }
    }
}
