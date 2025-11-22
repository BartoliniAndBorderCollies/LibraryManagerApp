using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Ksiazka_Autor
    {
        [ForeignKey("Ksiazka")]
        [Column("id_ksiazki")]
        public int IdKsiazki { get; set; }

        [ForeignKey("Autor")]
        [Column("id_autora")]
        public int IdAutora { get; set; }

        //wlasciwosci nawigacyjne dla EF Core

        public Ksiazka Ksiazka { get; set; }
        public Autor Autor { get; set; }
    }
}
