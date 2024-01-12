using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelingExperience.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelID",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Travels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserID",
                table: "Travels",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_AspNetUsers_UserID",
                table: "Travels",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_AspNetUsers_UserID",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserID",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Travels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TravelID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
