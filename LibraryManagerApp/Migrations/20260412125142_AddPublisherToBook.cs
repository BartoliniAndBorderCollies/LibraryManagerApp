using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dostepna",
                table: "Books",
                newName: "dostepna");

            migrationBuilder.AddColumn<string>(
                name: "wydawca",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wydawca",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "dostepna",
                table: "Books",
                newName: "Dostepna");
        }
    }
}
