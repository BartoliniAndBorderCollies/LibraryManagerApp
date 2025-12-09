using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id_autora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id_autora);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id_kategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id_kategorii);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    id_czytelnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_rejestracji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    aktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.id_czytelnika);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id_ksiazki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rok_wydania = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liczba_stron = table.Column<int>(type: "int", nullable: false),
                    Dostepna = table.Column<bool>(type: "bit", nullable: false),
                    id_kategorii = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id_ksiazki);
                    table.ForeignKey(
                        name: "FK_Books_Categories_id_kategorii",
                        column: x => x.id_kategorii,
                        principalTable: "Categories",
                        principalColumn: "id_kategorii",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksAuthors",
                columns: table => new
                {
                    id_ksiazki = table.Column<int>(type: "int", nullable: false),
                    id_autora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAuthors", x => new { x.id_ksiazki, x.id_autora });
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Authors_id_autora",
                        column: x => x.id_autora,
                        principalTable: "Authors",
                        principalColumn: "id_autora",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksAuthors_Books_id_ksiazki",
                        column: x => x.id_ksiazki,
                        principalTable: "Books",
                        principalColumn: "id_ksiazki",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    id_wypozyczenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_czytelnika = table.Column<int>(type: "int", nullable: false),
                    id_ksiazki = table.Column<int>(type: "int", nullable: false),
                    data_wypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_terminu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_zwrotu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    oplata = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.id_wypozyczenia);
                    table.ForeignKey(
                        name: "FK_Rentals_Books_id_ksiazki",
                        column: x => x.id_ksiazki,
                        principalTable: "Books",
                        principalColumn: "id_ksiazki",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Readers_id_czytelnika",
                        column: x => x.id_czytelnika,
                        principalTable: "Readers",
                        principalColumn: "id_czytelnika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_id_kategorii",
                table: "Books",
                column: "id_kategorii");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAuthors_id_autora",
                table: "BooksAuthors",
                column: "id_autora");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_id_czytelnika",
                table: "Rentals",
                column: "id_czytelnika");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_id_ksiazki",
                table: "Rentals",
                column: "id_ksiazki");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksAuthors");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
