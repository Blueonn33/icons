using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace icons.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserProfilePictureUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfilePicture",
                table: "Icons",
                newName: "UserProfilePictureUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfilePictureUrl",
                table: "Icons",
                newName: "UserProfilePicture");
        }
    }
}
