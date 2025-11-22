using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Wypozyczenie
    {
        [Key]
        [Column("id_wypozyczenia")]
        public int IdWypozyczenia { get; set; }

        [ForeignKey("Czytelnik")]
        [Column("id_czytelnika")]
        public int IdCzytelnika { get; set; }

        [ForeignKey("Ksiazka")]
        [Column("id_ksiazki")]
        public int IdKsiazki { get; set; }

        [Column("data_wypozyczenia")]
        [DataType(DataType.Date)]
        public DateTime DataWypozyczenia { get; set; }

        [Column("data_terminu")]
        [DataType(DataType.Date)]
        public DateTime DataTerminu { get; set; }

        [Column("data_zwrotu")]
        [DataType(DataType.Date)]
        public DateTime? DataZwrotu { get; set; } //wypozyczenie moze nie byc jeszccze zwrocone, wiec powinno buc tu nullable

        [Column("oplata")]
        public double Oplata { get; set; }

        //nawigacyjna właściwość dla EF Core
        public Czytelnik Czytelnik { get; set; }
        public Ksiazka Ksiazka { get; set; }
    }
}
