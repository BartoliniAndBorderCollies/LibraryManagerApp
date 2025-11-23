using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Book
    {
        [Key]
        [Column("id_ksiazki")]
        public int BookId { get; set; }

        [Required]
        [Column("tytul")]
        public string Title {  get; set; }

        [Column("rok_wydania")]
        public int PublishYear { get; set; }

        [Required]
        public string ISBN {  get; set; }

        [Column("liczba_stron")]
        public int PagesNumber {  get; set; }

        public bool Dostepna { get; set; }

        [ForeignKey("Category")]
        [Column("id_kategorii")]
        public int CategoryId { get; set; }

        //nawigacyjne właściwości dla EF Core
        public Category Category { get; set; }

        //historia wypozyczen
        public ICollection<Rental> RentalList { get; set; }
    }
}
