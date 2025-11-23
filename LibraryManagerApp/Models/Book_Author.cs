using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagerApp.Models
{
    public class Book_Author
    {
        [ForeignKey("Book")]
        [Column("id_ksiazki")]
        public int BookId { get; set; }

        [ForeignKey("Author")]
        [Column("id_autora")]
        public int AuthorId { get; set; }

        //wlasciwosci nawigacyjne dla EF Core

        public Book? Book { get; set; }
        public Author? Author { get; set; }
    }
}
