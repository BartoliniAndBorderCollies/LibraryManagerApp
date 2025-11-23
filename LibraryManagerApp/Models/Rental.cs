using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Rental
    {
        [Key]
        [Column("id_wypozyczenia")]
        public int RentalId { get; set; }

        [ForeignKey("Czytelnik")]
        [Column("id_czytelnika")]
        public int ReaderId { get; set; }

        [ForeignKey("Book")]
        [Column("id_ksiazki")]
        public int BookId { get; set; }

        [Column("data_wypozyczenia")]
        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; }

        [Column("data_terminu")]
        [DataType(DataType.Date)]
        public DateTime DeadlineTime { get; set; }

        [Column("data_zwrotu")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; } //wypozyczenie moze nie byc jeszccze zwrocone, wiec powinno buc tu nullable

        [Column("oplata")]
        public double Fee { get; set; }

        //nawigacyjna właściwość dla EF Core
        public Reader? Reader { get; set; }
        public Book? Book { get; set; }
    }
}
