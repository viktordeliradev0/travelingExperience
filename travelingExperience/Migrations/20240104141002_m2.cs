using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelingExperience.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelID",
                table: "Travels",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "Comments",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "TravelID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Travels",
                newName: "TravelID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comments",
                newName: "CommentID");
        }
    }
}
